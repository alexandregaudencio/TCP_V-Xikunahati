using Ball;
using Character.Control;
using Character.StateMachine;
using System.Collections;
using System.Collections.Generic;
using Team;
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
            ballController.HeadOn += OnBallServed;
        }

        private void OnDisable()
        {
            ballController.HeadOn -= OnBallServed;

        }

        public void SetCharactersServePosition()
        {
            foreach (PriorityControl priorityControl in priorityControls)
            {
                priorityControl.SetInitialPosition();
            }
        }


        private void OnBallServed()
        {
            coreLoopController.TransitionToState(CoreLoopState.ROLLING_BALL);

          
        }

    }
}
