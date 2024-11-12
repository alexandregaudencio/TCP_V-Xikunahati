using Game.Character;
using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Ball
{

    [Serializable]
    public struct ThrowBallData
    {
        public const float horizontalRandomRange = 2;
        public BallState BallState;
        public CharacterControl CharacterControl;

        public Vector3 characterPosition;
        public float zMaxOffset;
        public Vector3 HorizontalPosition => new Vector3(FinalPositionOffset.x, CharacterControl.transform.position.y, FinalPositionOffset.z) + Vector3.forward * zMaxOffset;
        public Vector2 horizontalPositon => new Vector3(FinalPositionOffset.x, characterPosition.y, FinalPositionOffset.z) + Vector3.forward * zMaxOffset;

        public Vector3 FinalPositionOffset => characterPosition + ballPositionYOffset() + Vector3.forward * zMaxOffset;
        public TEAM TargetTeam;

        public Vector3 ballPositionYOffset()
        {
            Vector3 characterForward = (CharacterControl != null) ? CharacterControl.initialForward : Vector3.zero;
            if (BallState.yPosition == BallYPosition.DOWN) return characterForward * 5;
            if (BallState.yPosition == BallYPosition.MIDDLE) return Vector3.up * 4;
            return Vector3.up * 7 + characterForward;
        }

        public ThrowBallData(BallState ballState, CharacterControl characterControl, TEAM targetTeam, float zMaxOffset)
        {

            BallState = ballState;
            CharacterControl = characterControl;
            this.TargetTeam = targetTeam;
            characterPosition = characterControl.transform.position;
            this.zMaxOffset = Random.Range(-zMaxOffset, zMaxOffset);




        }


    }

}
