using Ball;
using CoreLoop;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace CoreLoop
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
            ballController.ballOutField += MarkPoint;
            ballController.ballContactBodyTeam += OnTeamContactBall;
        }

        private void OnDisable()
        {
            ballController.ballOutField -= MarkPoint;
            ballController.ballContactBodyTeam -= OnTeamContactBall;

        }

        private TEAM GetTeamPointed()
        {
            if (ballController.LastTeamHead != ballController.LastSideBallFell)
            {
                return ballController.LastTeamHead;
            } else
            {
                return (ballController.LastTeamHead == TEAM.Blue) ? TEAM.Red : TEAM.Blue;
            }
            
        }

        public void MarkPoint()
        {
            point?.Invoke(GetTeamPointed());
            lastTeamMarkedPoint = GetTeamPointed();
            
        }

        public void OnTeamContactBall(TEAM team)
        {
            TEAM teamScored = (team == TEAM.Red) ? TEAM.Blue : TEAM.Red;
            point?.Invoke(teamScored);
            lastTeamMarkedPoint = teamScored;

        }



        private void Start()
        {
            teamTurnHandler.turnOver += ApplyScore;
        }

        private void OnDestroy()
        {
            teamTurnHandler.turnOver -= ApplyScore;
        }

        private void ApplyScore(TEAM team)
        {
            if (team == TEAM.Red) redScore.IncreaseScore();
            else blueScore.IncreaseScore();
        }

    }

}
