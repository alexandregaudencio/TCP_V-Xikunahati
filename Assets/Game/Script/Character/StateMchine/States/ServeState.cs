using Character.Control;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.StateMachine
{
    public class ServeState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.CharacterRigidbody.velocity = Vector3.zero;
            controller.Animator.Idle();
            controller.transform.rotation = controller.Behaviour.ForwardRotation;

        }

        public override void ExitState(CharacterControl controller)
        {
        }

        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            if(controller.Control.dive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
            }
        }
    }
}

