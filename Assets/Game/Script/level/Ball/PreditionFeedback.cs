using UnityEngine;

namespace Game.Ball
{
    [ExecuteAlways]
    public class PreditionFeedback : MonoBehaviour
    {
        [Range(0, 1)] public float opacityOnHeading = 0.5f;
        private BallController ballController;
        //public UnityEngine.Camera redCamera;
        //public UnityEngine.Camera blueCamera;
        public Transform targetCameraTransform;

        public Color color;
        public int colorID => Shader.PropertyToID("_Color");
        private MeshRenderer meshRenderer;
        MaterialPropertyBlock materialPropertyBlock;


        private void Awake()
        {
            ballController = FindAnyObjectByType<BallController>();
            materialPropertyBlock = new MaterialPropertyBlock();
            meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.GetPropertyBlock(materialPropertyBlock);
            color = meshRenderer.sharedMaterial.GetColor(colorID);
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
            SetOpacity(opacityOnHeading);
            transform.position = data.FinalPositionOffset;

        }


        public void SetOpacity(float opacity)
        {
            color.a = opacity;
            materialPropertyBlock.SetColor(colorID, color);
            meshRenderer.SetPropertyBlock(materialPropertyBlock);


        }

        //private void Awake()
        //{
        //    ballController = FindAnyObjectByType<BallController>();
        //}

        //private void Start()
        //{
        //    ballController.HeadedBall += OnHeadedBall;
        //}

        //private void OnDestroy()
        //{
        //    ballController.HeadedBall -= OnHeadedBall;
        //}

        //private void OnHeadedBall(ThrowBallData data)
        //{
        //    if (data.TargetTeam == TEAM.Red)
        //    {
        //        targetCameraTransform = redCamera.transform;
        //        gameObject.layer = LayerMask.NameToLayer("Vcam2");
        //    }
        //    else
        //    {
        //        targetCameraTransform = blueCamera.transform;
        //        gameObject.layer = LayerMask.NameToLayer("Vcam1");
        //    }
        //}

        private void LateUpdate()
        {
            transform.forward = targetCameraTransform.forward;
            //Vector2 direction = targetCameraTransform.position - transform.position;
            //transform.LookAt(direction);
            //transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);

        }
    }

}