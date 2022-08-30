using Character;
using CoreLoop;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Ball
{
    public class BallController : MonoBehaviour
    {
        private Rigidbody ballRigidbody;
        private int headCount = 0;
        public event Action HeadOn;
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

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
        }


        private void OnEnable()
        {
            BallChangeFieldSide += ResetHeadsCount;
            ballTouchFieldSide += UpdateSideBallFell;
            StartCoroutine(UpdateBallFieldSide());
        }

        private void OnDisable()
        {
            BallChangeFieldSide -= ResetHeadsCount;
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
                IncreaseHeadCount();
            }
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

        public void UpdateSideBallFell(TEAM teamSide)
        {
            lastSideBallFell = teamSide;
        }

        private void IncreaseHeadCount()
        {

            headCount++;
            HeadOn?.Invoke();
        }

        private void ResetHeadsCount(TEAM t)
        {
            headCount = 0;
        }

    }
}