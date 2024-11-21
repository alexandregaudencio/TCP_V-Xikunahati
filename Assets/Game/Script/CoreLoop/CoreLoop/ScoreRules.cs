using Game.Ball;
using Game.Character;
using System;
using Team;
using UnityEngine;

namespace Game.CoreLoop
{
    public class ScoreRules : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        [SerializeField] private Score redScore;
        [SerializeField] private Score blueScore;
        public event Action<TEAM> point;
        private TEAM lastTeamMarkedPoint = TEAM.Blue;
        public TEAM LastTeamMarkedPoint => lastTeamMarkedPoint;

        private void Awake()
        {
            ballController = FindObjectOfType<BallController>();
        }
        private void OnEnable()
        {

            redScore.ResetScore();
            blueScore.ResetScore();
            ballController.ballOutField += BallOutField;
            point += ApplyScore;
            ballController.ballContactBodyTeam += OnBallContactBodyTeam;

        }

        private void OnDisable()
        {
            redScore.ResetScore();
            blueScore.ResetScore();
            point -= ApplyScore;
            ballController.ballOutField -= BallOutField;
            ballController.ballContactBodyTeam -= OnBallContactBodyTeam;

        }
        //private TEAM GetTeamPointed()
        //{
        //    if (ballController.LastTeamHead != ballController.LastSideBallFell)
        //    {
        //        return ballController.LastTeamHead;
        //    }
        //    else
        //    {
        //        return (ballController.LastTeamHead == TEAM.Blue) ? TEAM.Red : TEAM.Blue;
        //    }

        //}

        public void BallOutField(TEAM team)
        {
            TEAM pointTeam = team == TEAM.Blue ? TEAM.Red : TEAM.Blue;
            Debug.Log("mark point: " + pointTeam);
            lastTeamMarkedPoint = pointTeam;
            point?.Invoke(pointTeam);



        }


        public void OnBallContactBodyTeam(TEAM team)
        {
            TEAM teamScored = (team == TEAM.Red) ? TEAM.Blue : TEAM.Red;
            lastTeamMarkedPoint = teamScored;
            point?.Invoke(teamScored);

        }


        private void ApplyScore(TEAM team)
        {
            Debug.Log("applying score");
            if (team == TEAM.Red) redScore.IncreaseScore();
            else blueScore.IncreaseScore();
        }

    }

}
