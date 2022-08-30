using System;
using UnityEngine;

namespace Game
{
    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private StateHandler[] stateHandlers;
        [SerializeField] private StateHandler currentState;
        public static GameStateController instance;


        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            Restart();
        }
        public GameState nextGameState
        {
            get
            {
                int currentIndex = Array.IndexOf(stateHandlers, currentState);
                if (currentIndex < stateHandlers.Length - 1)
                {
                    return stateHandlers[currentIndex + 1].State;
                }
                return stateHandlers[0].State;

            }
        }
        public void TransitionToState(GameState state)
        {
            currentState.StateEnd();
            currentState = GetHandler(state);
            currentState.StateStart();
        }

        private StateHandler GetHandler(GameState state)
        {
            foreach(StateHandler handlers in stateHandlers)
            {
                if (handlers.State == state) 
                    return handlers;
            }
            return null;
        }

        public void Restart()
        {
            foreach (StateHandler handler in stateHandlers)
            {
                handler.Hide();
            }
            TransitionToState(GameState.STARTUP);
        }

        public void nextStep()
        {
            TransitionToState(nextGameState);
        }
        #region para fins de desenvolvimento
        private void Update()
        {
            //if (Input.GetKeyDown(KeyCode.F1)) TransitionToState(GameState.STARTUP);
            //if (Input.GetKeyDown(KeyCode.F2)) TransitionToState(GameState.GAMEPLAY);
            //if (Input.GetKeyDown(KeyCode.F3)) TransitionToState(GameState.ENDGAME);
        }
        #endregion
    }

}
