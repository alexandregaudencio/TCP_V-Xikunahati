using UnityEngine;
using UnityEngine.Events;

namespace Game.CoreLoop
{
    public enum CoreLoopState
    {
        SERVE,
        ROLLING_BALL,
        SCORING
    }

    public class CoreLoopHandler : MonoBehaviour
    {
        [SerializeField] private CoreLoopState state;
        public CoreLoopState State { get => state; }

        public UnityEvent onStateStart;
        public UnityEvent onStateEnd;


        public void StateStart()
        {
            Debug.Log("starting: " + state.ToString());
            onStateStart?.Invoke();
        }

        public void StateEnd()
        {
            Debug.Log("Ending: " + state.ToString());
            onStateEnd?.Invoke();
        }

    }
}

