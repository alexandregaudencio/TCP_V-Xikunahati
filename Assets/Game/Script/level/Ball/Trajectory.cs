using UnityEngine;

namespace Game.Ball
{
    public class Trajectory : MonoBehaviour
    {
        private BallVelocity ballVelocity;

        private TrajectoryPredictor trajectoryPredictor;

        private new Rigidbody rigidbody;
        private void Awake()
        {
            ballVelocity = FindObjectOfType<BallVelocity>();
            trajectoryPredictor = GetComponent<TrajectoryPredictor>();
            rigidbody = ballVelocity.GetComponent<Rigidbody>();

        }

        private void OnEnable()
        {
            ballVelocity.VelocityChange += OnVelocityUpdate;
        }

        private void OnDisable()
        {
            ballVelocity.VelocityChange -= OnVelocityUpdate;

        }

        private void OnVelocityUpdate(Rigidbody rigidbody)
        {

            trajectoryPredictor.PredictTrajectory(rigidbody);
        }



    }

}