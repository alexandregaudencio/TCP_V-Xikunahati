using Game.Ball;
using Game.Character;
using System;
using UnityEngine;


namespace Game.CoreLoop
{
    public class TeamTurnHandler : MonoBehaviour
    {
        [SerializeField] private TEAM teamTurn;
        public event Action<TEAM> turnOver;
        //public event Action ballStopped;
        [SerializeField] private BallController ballController;
        [SerializeField] private ScoreRules scoreRules;
        public TEAM TeamTurn => teamTurn;
        private void Awake()
        {
            scoreRules = FindAnyObjectByType<ScoreRules>();
        }
        private void OnEnable()
        {
            scoreRules.point += turnOver;
            ballController.BallChangeFieldSide += UpdateTeamTurn;
        }
        private void OnDisable()
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
