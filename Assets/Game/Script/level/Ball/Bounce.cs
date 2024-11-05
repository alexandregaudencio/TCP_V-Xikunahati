using Game.CoreLoop;
using UnityEngine;

namespace Game.Ball
{
    [RequireComponent(typeof(SphereCollider)),
    RequireComponent(typeof(Rigidbody))]
    public class Bounce : MonoBehaviour
    {
        public float force = 13;
        public GameObject BallPositionPrediction;
        public const float gravity = 9.81f;
        Rigidbody ballRigidBody;
        public BallController ballController;


        private void Awake()
        {
            ballController = GetComponent<BallController>();
            ballRigidBody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            ballController.HeadedBall += OnBallHeaded;
        }

        private void OnDestroy()
        {
            ballController.HeadedBall -= OnBallHeaded;
        }

        private void OnBallHeaded(ThrowBallData data)
        {
            Vector3 velocity = ParabolicVelocity(transform.position, data.FinalPositionOffset, 2);
            ballRigidBody.velocity = velocity;
            SetPreditionPosition(data.FinalPositionOffset);
        }

        public void SetPreditionPosition(Vector3 value)
        {
            this.BallPositionPrediction.transform.position = value;
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