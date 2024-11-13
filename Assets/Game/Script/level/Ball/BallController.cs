using Game.AudioControl;
using Game.Character;
using Game.CoreLoop;
using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Ball
{

    public enum BallYPosition
    {
        DOWN,
        MIDDLE,
        UP
    }

    public enum BallVelocityMode
    {
        NORMAL,
        POWER
    }

    [Serializable]
    public struct BallState
    {
        public BallYPosition yPosition;
        public BallVelocityMode velocityMode;

        public BallState(BallYPosition yPosition, BallVelocityMode velocityMode)
        {
            this.yPosition = yPosition;
            this.velocityMode = velocityMode;
        }
    }


    public class BallController : MonoBehaviour
    {
        public int headCount = 0;
        public event Action<ThrowBallData> HeadedBall;
        public event Action ballOutField;
        public event Action<TEAM> BallChangeFieldSide;
        public event Action<TEAM> ballTouchFieldSide;
        public int ballTouchFieldSideCount = 0;
        public event Action<TEAM> ballContactBodyTeam;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        public float zPosition => transform.position.z;
        private TEAM lastTeamHead;
        public TEAM LastTeamHead => lastTeamHead;
        private TEAM lastSideBallFell;
        public TEAM LastSideBallFell => lastSideBallFell;
        [Tooltip("Indica o acréscimo no eixo Z na movimentação que bola fará durante o movimento em parábola.")]
        public float zMaxOffset = 2;
        public ThrowBallData throwBallData;

        private RandomAudioPlay randomAudioPlay;

        private void Awake()
        {
            randomAudioPlay = GetComponent<RandomAudioPlay>();
        }


        private void OnEnable()
        {
            ballTouchFieldSide += UpdateSideBallFell;
            StartCoroutine(UpdateBallFieldSide());
        }

        private void OnDisable()
        {
            ballTouchFieldSide -= UpdateSideBallFell;
            StopCoroutine(UpdateBallFieldSide());
        }

        private void OnCollisionEnter(Collision collision)
        {


            if (LayerMask.LayerToName(collision.gameObject.layer) == "Player")
            {
                TeamSelection contactBodyTeam = collision.gameObject.GetComponent<TeamSelection>();
                ballContactBodyTeam?.Invoke(contactBodyTeam.team);

                //collision.gameObject.GetComponent<BodyEffect>()?.DoBallContactEffect();
            }

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("FieldRange"))
            {
                ballOutField?.Invoke();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("TeamRedSide"))
            {
                ballTouchFieldSide?.Invoke(TEAM.Red);
            }

            if (other.CompareTag("TeamBlueSide"))
            {
                ballTouchFieldSide?.Invoke(TEAM.Blue);
            }

            if (other.CompareTag("Head"))
            {
                lastTeamHead = teamTurnHandler.TeamTurn;
                headCount++;
                throwBallData = GenerateThrowBallData();
                HeadedBall?.Invoke(throwBallData);
                randomAudioPlay.PlayRandomClip(SOUND_KEY.head, 0);

            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.black;
            Gizmos.DrawSphere(new Vector3(throwBallData.horizontalPositon.x, throwBallData.characterPosition.y, throwBallData.horizontalPositon.y), 0.5f);
            if (throwBallData.CharacterControl != null) Gizmos.DrawLine(throwBallData.CharacterControl.transform.position, throwBallData.CharacterControl.transform.position + throwBallData.CharacterControl.transform.forward);
        }

        public IEnumerator UpdateBallFieldSide()
        {
            while (true)
            {
                if (zPosition < 0.00f && teamTurnHandler.TeamTurn != TEAM.Blue)
                {
                    BallChangeFieldSide?.Invoke(TEAM.Blue);
                }
                if (zPosition > 0.00f && teamTurnHandler.TeamTurn != TEAM.Red)
                {
                    BallChangeFieldSide?.Invoke(TEAM.Red);
                }

                yield return new WaitForSeconds(0.1f);
            }

        }


        public void ResetHeadCount()
        {
            headCount = 0;
        }

        public void UpdateSideBallFell(TEAM teamSide)
        {
            lastSideBallFell = teamSide;
        }

        private ThrowBallData GenerateThrowBallData()
        {
            TEAM targetTeam = (TEAM)(((int)LastTeamHead + 1) % 2);
            CharacterControl character = PlayerControlHandler.Instance.GetRandomCharacter(targetTeam);
            return new ThrowBallData(GenerateBallState(), character, targetTeam, zMaxOffset);
        }

        private BallState GenerateBallState()
        {
            int yPosition = Random.Range(0, 3);
            //int velocity = Random.Range(0, 2);
            return new BallState(GetBallYPosition(), 0 /*(BallVelocityMode)velocity*/);
        }

        private BallYPosition GetBallYPosition()
        {
            return (BallYPosition)MathF.Ceiling(lastTeamHead.yAxis() + 1);
        }


    }



}