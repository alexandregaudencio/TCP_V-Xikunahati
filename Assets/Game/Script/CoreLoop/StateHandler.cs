using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public enum GameState
    {
        STARTUP,
        GAMEPLAY,
        ENDGAME
    }

    public class StateHandler : ViewHandler
    {
        [SerializeField] private GameState state;
        public GameState State { get => state;}

        public UnityEvent onStateStart;
        public UnityEvent onStateEnd;

        public void StateStart()
        {
            onStateStart?.Invoke();
            Show();
        }

        public void StateEnd()
        {
            onStateEnd?.Invoke();
            Hide();
        }

    }


}

