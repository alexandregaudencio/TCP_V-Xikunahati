using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Character
{
    public class DisplacementLimiter : MonoBehaviour
    {
        //[SerializeField] private Transform forwardPoint;
        public float forwardOffset = 1.0f;

        [SerializeField] private SphereCollider fieldRangeCollider;
        [SerializeField] private bool outBounds;
        private TeamSelection teamSelection;
        public bool OutBounds => outBounds;
        public Vector3 forwardPointLimit => transform.position + transform.forward * forwardOffset;
        private Vector2 lastXZPositionInBounds;
        private void Awake()
        {
            teamSelection = GetComponent<TeamSelection>();
        }
        private void FixedUpdate()
        {
            if(!outBounds)
            {
                lastXZPositionInBounds = new Vector2(transform.position.x, transform.position.z);
            }

            if(outBounds)
            {
                transform.position = new Vector3(
                    lastXZPositionInBounds.x, 
                    transform.position.y, 
                    lastXZPositionInBounds.y
                );
            }
        }

        public void OnEnable()
        {
            StartCoroutine(VerifyPointOut());
        }

        public void OnDisable()
        {
            StopCoroutine(VerifyPointOut());
        }


        private IEnumerator VerifyPointOut()
        {
            while (true)
            {
                outBounds = (OutFieldRange() || OutTeamZone());
                yield return new WaitForSeconds(Time.fixedDeltaTime);
            }

        }

        private bool OutFieldRange()
        {
            if (Mathf.Abs(forwardPointLimit.magnitude) > fieldRangeCollider.radius) {
                return true;
            }
            return false;
            
        }

        //out if team blue is On negative zone: < (0,0,0)  //out if team red is on positive zone: > (0,0,0)
        private bool OutTeamZone()
        {
            if(teamSelection.team == TEAM.Blue )
            {
                return forwardPointLimit.z > 0 ? true : false;
            }
            return forwardPointLimit.z < 0 ? true : false;
        }


    }

}
