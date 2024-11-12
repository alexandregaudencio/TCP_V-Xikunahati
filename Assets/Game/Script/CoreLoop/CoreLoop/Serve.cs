using Game.Ball;
using Game.Character;
using Game.Level;
using UnityEngine;

namespace Game.CoreLoop
{
    public class Serve : MonoBehaviour
    {
        [SerializeField] private ServerPositions serverPositions;
        [SerializeField] private PlayerControlHandler playerControlHandler;
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

            foreach (CharacterControl cc in playerControlHandler.GetCharacters(TEAM.Red))
            {
                var servePosition = serverPositions.GetSevePosition(cc);
                cc.transform.position = servePosition.position;
            }

            foreach (CharacterControl cc in playerControlHandler.GetCharacters(TEAM.Blue))
            {
                var servePosition = serverPositions.GetSevePosition(cc);
                cc.transform.position = servePosition.position;
            }



            //foreach (PriorityControl priorityControl in priorityControls)
            //{
            //    priorityControl.SetInitialPosition();
            //}
        }


        private void OnBallServed(ThrowBallData _)
        {
            coreLoopController.TransitionToState(CoreLoopState.ROLLING_BALL);


        }

    }
}
