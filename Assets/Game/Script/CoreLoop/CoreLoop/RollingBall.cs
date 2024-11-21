using Game.Ball;
using Game.Character;
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
            teamTurnHandler = FindObjectOfType<TeamTurnHandler>();
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
            Debug.Log("turn Over");
            coreLoopController.NextStep();
        }




    }

}
