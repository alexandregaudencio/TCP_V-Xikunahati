using AYellowpaper.SerializedCollections;
using Game.Ball;
using Game.CoreLoop;
using UnityEngine;

namespace Game.Camera
{

    public class CameraController : MonoBehaviour
    {
        [SerializeField, SerializedDictionary("BallVelocity", "Shak")]
        private SerializedDictionary<BallVelocityMode, shakeData> shakeData;

        private CameraShaker[] cameraShaker;
        private BallController ballController;

        //public static CameraController Instance;

        private void Awake()
        {
            cameraShaker = GetComponentsInChildren<CameraShaker>();
            ballController = FindAnyObjectByType<BallController>();
        }
        public void Start()
        {
            //Instance = this;
            ballController.HeadedBall += OnHeadedBall;
        }

        private void OnDestroy()
        {
            ballController.HeadedBall -= OnHeadedBall;
        }

        private void OnHeadedBall(ThrowBallData data)
        {
            ShakeCameras(shakeData[data.BallState.velocityMode]);

        }

        public void ShakeCameras(shakeData shakeData)
        {
            foreach (var shaker in cameraShaker)
            {
                shaker.ApplyShake(shakeData);
            }
        }



    }

}