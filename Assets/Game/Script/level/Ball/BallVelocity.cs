using System;
using UnityEngine;

namespace Game.Ball
{
    public class BallVelocity : MonoBehaviour
    {
        private BallController ballController;
        [SerializeField] private float initialVelocity = 2;
        [SerializeField, Range(0.01f, 1)] private float speedTimeMultiplier = 0.1f;
        private Rigidbody ballRigidbody;

        public Vector2 VelocityRange = new Vector2(0.5f, 2);
        [SerializeField] private float velocityForce;

        private void Awake()
        {
            ballController = GetComponent<BallController>();
            ballRigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            ballController.HeadedBall += OnHeadedBall;
        }

        private void OnDisable()
        {
            ballController.HeadedBall -= OnHeadedBall;

        }

        private void OnHeadedBall(ThrowBallData data)
        {
            float parabolicTime = initialVelocity - ballController.headCount * speedTimeMultiplier;
            //parabolicTime = Mathf.Clamp(parabolicTime, VelocityRange.x, VelocityRange.y);

            Vector3 velocity = ParabolicVelocity(transform.position, data.FinalPositionOffset, parabolicTime);
            velocityForce = parabolicTime;
            ballRigidbody.velocity = velocity;
        }


        public Vector3 ParabolicVelocity(Vector3 start, Vector3 end, float time)
        {
            Vector3 horizontalDisplacement = new Vector3(end.x - start.x, 0, end.z - start.z);
            float horizontalSpeed = horizontalDisplacement.magnitude / time;
            Vector3 horizontalVelocity = horizontalDisplacement.normalized * horizontalSpeed;

            float verticalSpeed = (end.y - start.y + 0.5f * Mathf.Abs(Physics.gravity.y) * Mathf.Pow(time, 2)) / time;
            Vector3 verticalVelocity = Vector3.up * verticalSpeed;

            return horizontalVelocity + verticalVelocity;
        }


    }
}
