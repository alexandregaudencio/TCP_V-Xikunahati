using Character.Control;
using System;
using UnityEngine;


namespace Character.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private State currentState;
        private CharacterControl characterController;
        private StateInstances stateInstances;
        // private void OnGUI()
        // {
        //     GUI.Label(new Rect(100, 1000, 1000, 100), currentState.ToString());
        // }

        public StateInstances StateInstances { get => stateInstances; }
        private void Awake()
        {
            characterController = GetComponent<CharacterControl>();
            stateInstances = new StateInstances();
        }
        void Start()
        {
            TransitionToState(StateInstances.idleState);
        }


        void Update()
        {
            currentState.UpdateState(characterController, this);
        }

        private void FixedUpdate()
        {
            currentState.FixedUpdateState(characterController, this);
        }

        public virtual void TransitionToState(State state)
        {
            currentState?.ExitState(characterController);
            currentState = state;
            currentState.EnterState(characterController);

        }
        private void OnCollisionEnter(Collision collision)
        {
            currentState.OnCollisionEnterState(characterController, collision, this);
        }
        private void OnCollisionStay(Collision collision)
        {
            currentState.OnCollisionStayState(characterController, collision, this);
        }

        public void GoServeState()
        {
            TransitionToState(stateInstances.serveState);
        }
        public void GoIdleState()
        {
            TransitionToState(stateInstances.idleState);
        }
    }
}


