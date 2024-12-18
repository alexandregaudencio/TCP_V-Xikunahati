using Game.Level;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Game.Character
{

    public enum AiBehaviour
    {
        IDLE,
        MOVING
    }

    public class AIControl : Control
    {
        [SerializeField] private Transform ballTransform;
        [SerializeField] private PriorityControl priorityControl;
        [SerializeField] private float distanceLimit = 0.2f;
        public float DistanceToTarget => Vector3.Distance(targetPosition, transform.position);
        public float radiusCenter;
        public Vector3 centerPosition => priorityControl.CenterPointTransform.position;
        [SerializeField] private Vector3 targetPosition;
        private Vector3 randomPosition => new Vector3(
            Random.Range(-radiusCenter, radiusCenter),
            -1,
            Random.Range(-radiusCenter, radiusCenter));

        [SerializeField][Range(1, 7)] private float maxIntervalToChangeBehaviour;

        public AiBehaviour AiBehaviour = AiBehaviour.IDLE;
        [SerializeField][Range(30, 100)] float speedPercentage;
        private List<Vector3> positionsTarget => new List<Vector3>() {
            centerPosition,
            centerPosition+randomPosition
        };

        private void Start()
        {
            targetPosition = centerPosition;
        }

        private void OnEnable()
        {
            StartCoroutine(ChangeBehaviour());
            StartCoroutine(ChangeTargetPosition());
            //StartCoroutine(PlayRandomIdleAnim());
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

        public void StartCoroutines()
        {
            StartCoroutine(ChangeBehaviour());
            StartCoroutine(ChangeTargetPosition());
            //StartCoroutine(PlayRandomIdleAnim());
        }

        public void StopCoroutines()
        {
            StopAllCoroutines();
        }
        //private void OnDrawGizmos()
        //{
        //    Gizmos.color = Color.white;
        //    Gizmos.DrawWireSphere(targetPosition, radiusCenter);

        //}
        private IEnumerator ChangeBehaviour()
        {
            while (true)
            {
                //Mathf.
                AiBehaviour behaviour = (AiBehaviour)Mathf.Abs(Random.Range(0, 2));
                AiBehaviour = behaviour;
                yield return new WaitForSeconds(1);

            }
        }

        private IEnumerator ChangeTargetPosition()
        {
            while (true)
            {
                //Mathf.
                int targetIndex = Mathf.Abs(Random.Range(0, 2));
                targetPosition = positionsTarget[targetIndex];
                yield return new WaitForSeconds(1);

            }
        }


        public override bool ButtonReturn()
        {
            throw new System.NotImplementedException();
        }

        public override bool ButtonStart()
        {
            throw new System.NotImplementedException();
        }

        public override Vector3 direction()
        {
            if (AiBehaviour == AiBehaviour.MOVING)
            {
                if (DistanceToTarget > distanceLimit)
                {
                    Vector3 distanceVector = targetPosition - transform.position;
                    float randomSpeed = Random.Range(speedPercentage - 10, speedPercentage + 10);
                    return new Vector3(distanceVector.x, 0, distanceVector.z).normalized * (randomSpeed / 100);
                }
            }
            return Vector3.zero;

        }

        public override bool dive()
        {
            return false;
        }

        public override bool head()
        {
            return false;
        }

        public override bool jump()
        {
            return false;
        }

        public override bool L()
        {
            return false;
        }

        public override void playerSelect()
        {

        }

        public override bool R()
        {
            return false;
        }

        protected override float xAxis()
        {
            return 0f;
        }

        protected override float yAxis()
        {
            return 0f;
        }

        private void FixedUpdate()
        {

        }



    }

}

//[Serializable] public class AIBehaviour 
//{
//    [SerializeField] private Transform ballTransform;
//    [SerializeField] private CharacterAnimation characterAnimation;
//    [SerializeField] private PriorityControl priorityControl;

//    public AIBehaviour(Transform ballTransform, CharacterAnimation characterAnimation, PriorityControl priorityControl)
//    {
//        this.ballTransform = ballTransform;
//        this.characterAnimation = characterAnimation;
//        this.priorityControl = priorityControl;
//    }



//}
