using Game.Character;
using System;
using Team;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Ball
{

    [Serializable]
    public struct ThrowBallData
    {
        public BallState BallState;
        public CharacterControl CharacterControl;
        public Vector3 FinalPositionOffset;
        public TEAM TargetTeam;
        public ThrowBallData(BallState ballState, CharacterControl characterControl, TEAM targetTeam)
        {
            FinalPositionOffset = characterControl.transform.position + new Vector3(Random.Range(-1, 1), 4, Random.Range(-1, 1));
            BallState = ballState;
            CharacterControl = characterControl;
            this.TargetTeam = targetTeam;
        }
    }

}
