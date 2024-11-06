using UnityEngine;

namespace Game.Character
{
    public static class PlayerInput
    {
        //[SerializeField] private Players player;

        //private int playerIndex => (int)player + 1;

        //vai de -1 a 1
        public static float xAxis(TEAM team)
        {
            return Input.GetAxis("Horizontal" + ((int)team + 1).ToString());
        }

        //vai de -1 a 1
        public static float yAxis(TEAM team)
        {
            return Input.GetAxis("Vertical" + ((int)team + 1).ToString());
        }

        public static Vector3 direction(TEAM team)
        {
            return new Vector3(xAxis(team + 1), 0, yAxis(team + 1));
        }

        public static bool jump(TEAM team)
        {
            return Input.GetButtonDown("Jump" + ((int)team + 1).ToString());
        }
        public static bool head(TEAM team)
        {
            return Input.GetButtonDown("Head" + ((int)team + 1).ToString());
        }
        public static bool dive(TEAM team)
        {
            return Input.GetButtonDown("Dive" + ((int)team + 1).ToString());
        }

        public static void playerSelect(TEAM team)
        {
            Debug.LogWarning("deve-se implementar a mudança de controle entre os personagens");
        }

        public static bool ButtonStart(TEAM team)
        {
            return Input.GetButtonDown("Start" + ((int)team + 1).ToString());
        }

        public static bool ButtonReturn(TEAM team)
        {
            return Input.GetButtonDown("Return" + ((int)team + 1).ToString());
        }

        public static bool R(TEAM team)
        {
            return Input.GetButtonDown("R" + ((int)team + 1).ToString());
        }

        public static bool L(TEAM team)
        {
            return Input.GetButtonDown("L" + ((int)team + 1).ToString());
        }
    }
}

