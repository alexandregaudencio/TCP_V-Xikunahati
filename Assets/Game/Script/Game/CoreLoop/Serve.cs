using Ball;
using UnityEngine;

namespace CoreLoop
{
    public class Serve : MonoBehaviour
    {
        [SerializeField] private BallController ballController;
        private PriorityControl[] priorityControls;

        private CoreLoopController coreLoopController;
        private CharacterRestrictionOnServe restrictionOnServe;
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
            priorityControls = FindObjectsOfType<PriorityControl>();
            restrictionOnServe = GetComponent<CharacterRestrictionOnServe>();
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
