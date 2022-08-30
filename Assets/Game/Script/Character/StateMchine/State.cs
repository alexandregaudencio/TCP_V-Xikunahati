using Character.Control;
using UnityEngine;

namespace Character.StateMachine
{
    public abstract class State 
    {
        public abstract void EnterState(CharacterControl controller);
        public abstract void UpdateState(CharacterControl controller, PlayerStateMachine stateMachine);
        public abstract void FixedUpdateState(CharacterControl controller, PlayerStateMachine stateMachine);
        public abstract void OnCollisionEnterState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine);
        public abstract void OnCollisionStayState(CharacterControl controller, Collision collision, PlayerStateMachine stateMachine);
        public abstract void ExitState(CharacterControl controller);

    }
}

