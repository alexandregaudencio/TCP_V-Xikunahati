using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class JumpState : State
    {

        public override void EnterState(CharacterControl controller)
        {
            controller.Animator.Jumping();
            controller.Behaviour.Jumping();
            controller.Particle.Jumping();
            controller.SoundControl.Jump();
        }
        public override void ExitState(CharacterControl controller)
        {
            controller.Particle.Fall();
        }
        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            if (LayerMask.LayerToName(collision.gameObject.layer) == "Field")
            {
                if (controller.Behaviour.isMoving)
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.movingState);
                }
                else
                {
                    stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
                }
                
            }

        }

        public override void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
        }

        public override void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();


            if (controller.Control.head())
            {
                controller.HeadControl.Head();
                controller.Animator.Head();
                controller.SoundControl.Head();
            }

        }
    }
}
