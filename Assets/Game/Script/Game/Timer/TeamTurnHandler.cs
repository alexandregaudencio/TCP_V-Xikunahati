using Ball;
using System;
using System.Collections;
using Team;
using UnityEngine;


namespace CoreLoop
{
    public class TeamTurnHandler : MonoBehaviour
    {
        [SerializeField] private TEAM teamTurn;
        public event Action<TEAM> turnOver;
        //public event Action ballStopped;
        [SerializeField] private BallController ballController;
        [SerializeField] private float minBallSpeedLimit;
        [SerializeField] private ScoreRules scoreRules;
        public TEAM TeamTurn => teamTurn;

        private void Start()
        {
            scoreRules.point += turnOver;
            ballController.BallChangeFieldSide += UpdateTeamTurn;
        }
        private void OnDestroy()
        {
            scoreRules.point -= turnOver;
            ballController.BallChangeFieldSide -= UpdateTeamTurn;
        }

        private void UpdateTeamTurn(TEAM teamTurn)
        {
            this.teamTurn = teamTurn;
        }

    }

}
