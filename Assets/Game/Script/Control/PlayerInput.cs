using UnityEngine;

namespace Game.Character
{
    public static class PlayerInput
    {
        //[SerializeField] private Players player;

        //private int playerIndex => (int)player + 1;

        //vai de -1 a 1
        public static float xAxis(this TEAM team)
        {
            return Input.GetAxis("Horizontal" + ((int)team + 1));
        }

        //vai de -1 a 1
        public static float yAxis(this TEAM team)
        {
            return Input.GetAxis("Vertical" + ((int)team + 1));
        }

        public static Vector3 direction(this TEAM team)
        {
            return new Vector3(xAxis(team), 0, yAxis(team));
        }

        public static bool jump(this TEAM team)
        {
            return Input.GetButtonDown("Jump" + ((int)team + 1));
        }
        public static bool head(this TEAM team)
        {
            return Input.GetButtonDown("Head" + ((int)team + 1));
        }
        public static bool dive(this TEAM team)
        {
            return Input.GetButtonDown("Dive" + ((int)team + 1));
        }

        public static void playerSelect(this TEAM team)
        {
            Debug.LogWarning("deve-se implementar a mudança de controle entre os personagens");
        }

        public static bool ButtonStart(TEAM team)
        {
            return Input.GetButtonDown("Start" + ((int)team + 1));
        }

        public static bool ButtonReturn(this TEAM team)
        {
            return Input.GetButtonDown("Return" + ((int)team + 1));
        }

        public static bool R(this TEAM team)
        {
            return Input.GetButtonDown("R" + ((int)team + 1));
        }

        public static bool L(this TEAM team)
        {
            return Input.GetButtonDown("L" + ((int)team + 1));
        }
    }
}

