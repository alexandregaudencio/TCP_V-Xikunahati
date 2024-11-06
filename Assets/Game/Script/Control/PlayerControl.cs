using Game.Ball;
using UnityEngine;

namespace Game.Character
{
    public class PlayerControl : Control
    {
        private CharacterBehaviour characterBehaviour;
        public TeamSelection teamSelection;
        private BallController ballController;
        [field: SerializeField] public bool isServingBall { get; set; }

        private TEAM team => teamSelection.team;


        private ThrowBallData throwBallData => ballController.throwBallData;
        private Vector2 horizontalPosition => new Vector2(transform.position.x, transform.position.z);

        private Vector2 TargetDirection = Vector2.zero;
        private void Awake()
        {
            ballController = FindAnyObjectByType<BallController>();
            teamSelection = GetComponent<TeamSelection>();
            characterBehaviour = GetComponent<CharacterBehaviour>();

        }




        private void Update()
        {
            //GetComponent<PlayerStateMachine>().TransitionToState(GetComponent<PlayerStateMachine>().StateInstances.movingState);

            if (isServingBall) { dive(); return; }

            //if (Vector2.Distance(horizontalPosition, throwBallData.horizontalPositon) > 0.4f)
            //{
            //    Debug.Log("chama");
            //    TargetDirection = throwBallData.horizontalPositon - horizontalPosition;
            //    direction();
            //}
            //else
            //{
            //    Debug.Log("zera tudo");
            //    TargetDirection = Vector2.zero;
            //}


        }

        public void SetServerState(bool value)
        {
            isServingBall = value;
        }

        public override bool ButtonReturn()
        {
            return false;
        }

        public override bool ButtonStart()
        {
            return false;
        }

        public override Vector3 direction()
        {
            return TargetDirection;
        }

        public override bool dive()
        {

            return PlayerInput.dive(team);
        }

        public override bool head()
        {
            return PlayerInput.head(team);

        }

        public override bool jump()
        {
            return PlayerInput.jump(team);
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
            return PlayerInput.xAxis(team);
        }

        protected override float yAxis()
        {
            return PlayerInput.yAxis(team);
        }
    }
}
