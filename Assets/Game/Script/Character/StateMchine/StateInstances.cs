using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Character.StateMachine
{
    public class StateInstances
    { 
        public readonly IdleState idleState;
        public readonly MovingState movingState;
        public readonly JumpState jumpState;
        public readonly DiveState diveState;
        public readonly ServeState serveState;
        public StateInstances()
        {
            idleState = new IdleState();
            movingState = new MovingState();
            jumpState = new JumpState();
            diveState = new DiveState();
            serveState = new ServeState();
        }
    }
}


