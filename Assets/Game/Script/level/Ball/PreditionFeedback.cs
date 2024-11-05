using UnityEngine;

namespace Game.Ball
{
    [ExecuteAlways]
    public class PreditionFeedback : MonoBehaviour
    {
        private BallController ballController;
        public UnityEngine.Camera redCamera;
        public UnityEngine.Camera blueCamera;
        public Transform targetCameraTransform;

        [SerializeField] private LayerMask blueLayer = LayerMask.NameToLayer("Vcam1");
        [SerializeField] private LayerMask redLayer = LayerMask.NameToLayer("Vcam2");

        private void Awake()
        {
            ballController = FindAnyObjectByType<BallController>();
        }

        private void Start()
        {
            ballController.HeadedBall += OnHeadedBall;
        }

        private void OnDestroy()
        {
            ballController.HeadedBall -= OnHeadedBall;
        }

        private void OnHeadedBall(ThrowBallData data)
        {
            if (data.TargetTeam == Team.TEAM.Red)
            {
                targetCameraTransform = redCamera.transform;
                gameObject.layer = redLayer;
            }
            else
            {
                targetCameraTransform = blueCamera.transform;
                gameObject.layer = blueLayer;
            }
        }

        private void LateUpdate()
        {
            transform.forward = targetCameraTransform.forward;
            //Vector2 direction = targetCameraTransform.position - transform.position;
            //transform.LookAt(direction);
            //transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);

        }
    }

}