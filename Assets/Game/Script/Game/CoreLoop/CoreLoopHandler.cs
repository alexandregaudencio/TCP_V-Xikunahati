using Game;
using UnityEngine;
using UnityEngine.Events;

namespace CoreLoop
{
    public enum CoreLoopState
    {
        SERVE,
        ROLLING_BALL,
        SCORING
    }

    public class CoreLoopHandler : ViewHandler
    {
        [SerializeField] private CoreLoopState state;
        public CoreLoopState State { get => state;}
        
        public UnityEvent onStateStart;
        public UnityEvent onStateEnd;

        public  void StateStart()
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

