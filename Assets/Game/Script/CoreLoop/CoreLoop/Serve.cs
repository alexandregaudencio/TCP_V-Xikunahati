using Game.Ball;
using UnityEngine;

namespace Game.CoreLoop
{
    public class Serve : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private PriorityControl[] priorityControls;

        private CoreLoopController coreLoopController;
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
            priorityControls = FindObjectsOfType<PriorityControl>();
        }



        private void OnEnable()
        {
            ballController.HeadedBall += OnBallServed;
        }

        private void OnDisable()
        {
            ballController.HeadedBall -= OnBallServed;

        }

        public void SetCharactersServePosition()
        {
            foreach (PriorityControl priorityControl in priorityControls)
            {
                priorityControl.SetInitialPosition();
            }
        }


        private void OnBallServed(ThrowBallData _)
        {
            coreLoopController.TransitionToState(CoreLoopState.ROLLING_BALL);


        }

    }
}
