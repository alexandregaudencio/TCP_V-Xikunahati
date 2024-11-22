using System;
using UnityEngine;

namespace Game.Ball
{
    public class BallVelocity : MonoBehaviour
    {
        private BallController ballController;
        [SerializeField] private float initialParabolicTime = 2.5f;
        [SerializeField, Range(0.01f, 0.2f)] private float speedTimeMultiplier = 0.12f;
        private Rigidbody ballRigidbody;
        [SerializeField, Min(0.1f)] private float minParabolicTime = 0.8f;
        [SerializeField] private float currentParabolicTime;
        public event Action<Rigidbody> VelocityChange = delegate { };

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
            float parabolicTime = initialParabolicTime - ballController.headCount * speedTimeMultiplier;

            parabolicTime = Mathf.Clamp(parabolicTime, minParabolicTime, initialParabolicTime);
            //parabolicTime = Mathf.Clamp(parabolicTime, VelocityRange.x, VelocityRange.y);

            Vector3 velocity = ParabolicVelocity(transform.position, data.FinalPositionOffset, parabolicTime);
            currentParabolicTime = parabolicTime;
            ballRigidbody.velocity = velocity;
            VelocityChange?.Invoke(ballRigidbody);
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
