using Game.CoreLoop;
using Game.Level;
using UnityEngine;

namespace Game.Ball
{
    public class BallServeHandler : MonoBehaviour
    {
        [SerializeField] private Vector2 ServeOffset = new Vector2(5, 1);
        [SerializeField] private ScoreRules scoreRules;
        private Rigidbody ballRigidbody;
        private TrailRenderer ballTrail;
        private ServerPositions serverPositions;

        private void Awake()
        {
            ballRigidbody = GetComponent<Rigidbody>();
            ballTrail = GetComponentInChildren<TrailRenderer>();
            scoreRules = FindAnyObjectByType<ScoreRules>();
            serverPositions = FindAnyObjectByType<ServerPositions>();
        }



        public void ServeAntecipation()
        {
            ballRigidbody.isKinematic = true;
            ballRigidbody.isKinematic = false;
            ballTrail.Clear();
            SetServePosition();
        }

        public void SetServePosition()
        {
            Transform serveTransform = serverPositions.GetServePosition(TeamTurnHandler.Instance.TeamTurn);
            transform.position = serveTransform.position - serveTransform.forward * ServeOffset.x + Vector3.up * ServeOffset.y;

        }

    }
}

