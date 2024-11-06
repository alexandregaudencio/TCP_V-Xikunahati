using UnityEngine;

namespace Game.Character
{
    public class PlayerControl : Control
    {
        private CharacterBehaviour characterBehaviour;
        public TeamSelection teamSelection;
        [field: SerializeField] public bool isServingBall { get; set; }

        private TEAM team => teamSelection.team;


        private void Awake()
        {
            teamSelection = GetComponent<TeamSelection>();
            characterBehaviour = GetComponent<CharacterBehaviour>();
        }

        private void Update()
        {
            characterBehaviour.Moving();
            if (isServingBall) { dive(); return; }




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
            return Vector3.zero;
        }

        public override bool dive()
        {

            return PlayerInput.dive(team);
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
            return 0;
        }

        protected override float yAxis()
        {
            return 0;
        }
    }
}
