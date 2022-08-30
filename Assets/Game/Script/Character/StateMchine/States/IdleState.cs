
using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class IdleState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Animator.Idle();
            controller.Particle.Idle();
            controller.Behaviour.Idle();
        }

        public override void ExitState(CharacterControl controller)
        {
        }
        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            if (controller.Control.head())
            {
                controller.HeadControl.Head();
                controller.Animator.Head();
                controller.SoundControl.Head();
            }


            if (controller.Control.jump())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.jumpState);
            }
            if (controller.Control.dive())
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.diveState);
            }
            if (controller.Behaviour.isMoving)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.movingState);
            }
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
    }
}

