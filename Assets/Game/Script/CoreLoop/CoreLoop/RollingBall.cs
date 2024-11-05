using Game.Ball;
using Team;
using UnityEngine;

namespace Game.CoreLoop
{
    public class RollingBall : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private TeamTurnHandler teamTurnHandler;
        private CoreLoopController coreLoopController;
        private void Awake()
        {
            teamTurnHandler = GetComponent<TeamTurnHandler>();
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }


        private void OnEnable()
        {
            teamTurnHandler.turnOver += OnTurnOver;
        }
        private void OnDisable()
        {
            teamTurnHandler.turnOver -= OnTurnOver;
        }

        private void OnTurnOver(TEAM teamturn)
        {
            coreLoopController.NextStep();
        }




    }

}
