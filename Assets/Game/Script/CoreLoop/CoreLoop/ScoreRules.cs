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
        private void OnEnable()
        {

            redScore.ResetScore();
            blueScore.ResetScore();
            ballController.ballOutField += MarkPoint;
            point += ApplyScore;
            ballController.ballContactBodyTeam += OnBallContactBodyTeam;

        }

        private void OnDisable()
        {
            redScore.ResetScore();
            blueScore.ResetScore();
            point -= ApplyScore;
            ballController.ballOutField -= MarkPoint;
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

        public void MarkPoint(TEAM team)
        {
            Debug.Log("mark point: " + team);
            point?.Invoke(team);
            lastTeamMarkedPoint = team;

        }

        public void OnBallContactBodyTeam(TEAM team)
        {
            TEAM teamScored = (team == TEAM.Red) ? TEAM.Blue : TEAM.Red;
            MarkPoint(teamScored);
            //point?.Invoke(teamScored);
            //lastTeamMarkedPoint = teamScored;

        }


        private void ApplyScore(TEAM team)
        {
            Debug.Log("applying score");
            if (team == TEAM.Red) redScore.IncreaseScore();
            else blueScore.IncreaseScore();
        }

    }

}
