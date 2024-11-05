using Ball;
using Character.Control;
using Game;
using System;
using Team;
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
        public Vector3 FinalPositionOffset;
        public TEAM TargetTeam;
        public ThrowBallData(BallState ballState, PlayerInput playerTarget, TEAM targetTeam)
        {
            FinalPositionOffset = playerTarget.transform.position + new Vector3(Random.Range(-1, 1), 4, Random.Range(-1, 1));
            BallState = ballState;
            PlayerTarget = playerTarget;
            this.TargetTeam = targetTeam;
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

