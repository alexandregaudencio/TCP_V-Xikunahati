using CoreLoop;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Ball
{
    public class BallServeHandler : MonoBehaviour
    {
        [SerializeField] private MeshCollider MiddleRedArea;
        [SerializeField] private MeshCollider MiddleBlueArea;
        [SerializeField] private float yServeOffset;
        [SerializeField] private ScoreRules scoreRules;
        private Rigidbody ballRigidbody;
        private TrailRenderer ballTrail;

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            ballTrail = GetComponentInChildren<TrailRenderer>();
        }


        public Vector3 GetSaquePosition(TEAM characterTeam)
        {
            Vector3 centerTarget = (characterTeam == TEAM.Blue) ? 
                MiddleBlueArea.sharedMesh.bounds.center :
                MiddleRedArea.sharedMesh.bounds.center;
            return centerTarget / 2 + Vector3.up * yServeOffset;
        }

        public void ServeAntecipation()
        {
            ballRigidbody.isKinematic = true;
            gameObject.transform.position = GetSaquePosition(scoreRules.LastTeamMarkedPoint);
            ballRigidbody.isKinematic = false;
            ballTrail.Clear();
        }

    }
}

