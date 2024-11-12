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

        private ThrowBallData ThrowBallData;

        [SerializeField] private float nearDistance = 1;
        [SerializeField] private float startDistanceToFadeIn = 4;

        [Header("Scale Effect props")]
        [SerializeField] private AnimationCurve animationCurve;
        [SerializeField, Min(1)] private float scaleOffset = 2;
        private bool BallIsNear => Vector3.Distance(transform.position, ballController.transform.position) < nearDistance;

        private float headedBallStartDistance;
        private float distanceToBall => Vector3.Distance(transform.position, ballController.transform.position);
        private float PercentagemDistanceToBallStartPosition => (distanceToBall / headedBallStartDistance);

        private void Awake()
        {
            ballController = FindAnyObjectByType<BallController>();
            meshRenderer = GetComponent<MeshRenderer>();
            materialPropertyBlock = new MaterialPropertyBlock();
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
            ThrowBallData = data;
            headedBallStartDistance = Vector3.Distance(transform.position, ballController.transform.position);

        }

        private void OnDrawGizmos()
        {
            if (ballController == null) ballController = FindAnyObjectByType<BallController>();
            Gizmos.color = BallIsNear ? Color.blue : Color.red;
            Gizmos.DrawLine(transform.position, ballController.transform.position);
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

        private void ApplyDistanceEffect()
        {
            float animationTimeEvaluted = animationCurve.Evaluate(PercentagemDistanceToBallStartPosition);
            transform.localScale = Vector3.one * (3 + animationTimeEvaluted * scaleOffset);
            SetOpacity(1 - animationTimeEvaluted / 1.2f);
        }


        private void LateUpdate()
        {
            ApplyDistanceEffect();
            transform.forward = targetCameraTransform.forward;
            //Vector2 direction = targetCameraTransform.position - transform.position;
            //transform.LookAt(direction);
            //transform.rotation = transform.rotation * Quaternion.Euler(rotationOffset);

        }
    }

}