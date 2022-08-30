using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public class MovingState : State
    {
        public override void EnterState(CharacterControl controller)
        {
            controller.Behaviour.Moving();
            controller.Animator.Move();
            controller.Particle.Move();
        }

        public override void ExitState(CharacterControl controller)
        {
            controller.SoundControl.Stop();
        }
        public override void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine)
        {
            controller.Behaviour.Moving();

            if (!controller.Animator.Floor)
            {
                controller.Particle.Idle();
            }


        }

        public override void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            controller.Particle.Move();
        }

        public override void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine)
        {
            controller.SoundControl.Run(collision);
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
            if (!controller.Behaviour.isMoving)
            {
                stateMachine.TransitionToState(stateMachine.StateInstances.idleState);
            }

        }
    }
}
