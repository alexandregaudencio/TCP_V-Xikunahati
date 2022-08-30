using UnityEngine;

namespace Character.Control
{
    public enum Players
    {
        Player1,
        Player2
    }

    public class PlayerInput : Control
    {
        [SerializeField] private Players player;

        private int playerIndex => (int)player + 1;

        //vai de -1 a 1
        protected override float xAxis()
        {
            return Input.GetAxis("Horizontal" + playerIndex.ToString());
        }

        //vai de -1 a 1
        protected override float yAxis()
        {
            return Input.GetAxis("Vertical" + playerIndex.ToString());
        }

        public override Vector3 direction()
        {
            return new Vector3(xAxis(), 0, yAxis());
        }

        public override bool jump()
        {
            return Input.GetButtonDown("Jump" + playerIndex.ToString());
        }
        public override bool head()
        {
            return Input.GetButtonDown("Head" + playerIndex.ToString());
        }
        public override bool dive()
        {
            return Input.GetButtonDown("Dive" + playerIndex.ToString());
        }

        public override void playerSelect()
        {
            Debug.LogWarning("deve-se implementar a mudança de controle entre os personagens");
        }

        public override bool ButtonStart()
        {
            return Input.GetButtonDown("Start" + playerIndex.ToString());
        }

        public override bool ButtonReturn()
        {
            return Input.GetButtonDown("Return" + playerIndex.ToString());
        }

        public override bool R()
        {
            return Input.GetButtonDown("R" + playerIndex.ToString());
        }

        public override bool L()
        {
            return Input.GetButtonDown("L" + playerIndex.ToString());
        }
    }
}

