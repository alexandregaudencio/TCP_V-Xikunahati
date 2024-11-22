using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{


    public class GameStateController : MonoBehaviour
    {
        [SerializeField] private StateHandler[] stateHandlers;
        [SerializeField] private StateHandler currentState;
        public static GameStateController instance;

        public event Action<GameState> StateChange = delegate { };

        private void Awake()
        {
            instance = this;
        }
        private void Start()
        {
            Restart();
            TransitionToState(GameState.GAMEPLAY);
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
            StateChange?.Invoke(state);
        }

        private StateHandler GetHandler(GameState state)
        {
            foreach (StateHandler handlers in stateHandlers)
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


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.F1)) ReloadScene();
        }

        public void ReloadScene()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
