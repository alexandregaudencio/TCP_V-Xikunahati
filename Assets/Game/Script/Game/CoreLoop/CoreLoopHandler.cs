using Ball;
using Character.Control;
using Game;
using System;
using UnityEngine;
using UnityEngine.Events;
using Random = UnityEngine.Random;

namespace CoreLoop
{
    public enum CoreLoopState
    {
        SERVE,
        ROLLING_BALL,
        SCORING
    }

    [Serializable]
    public struct ThrowBallData
    {
        public BallState BallState;
        public PlayerInput PlayerTarget;
        public Vector3 finalPositionOffset;

        public ThrowBallData(BallState ballState, PlayerInput playerTarget)
        {
            finalPositionOffset = playerTarget.transform.position + new Vector3(Random.Range(-1, 1), 0, Random.Range(-1, 1));
            BallState = ballState;
            PlayerTarget = playerTarget;
        }
    }


    public class CoreLoopHandler : ViewHandler
    {
        [SerializeField] private CoreLoopState state;
        public CoreLoopState State { get => state; }

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

