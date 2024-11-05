using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

namespace Game
{
    public class Startup : MonoBehaviour
    {
        private GameStateController gameStateController;
        private PriorityControl[] priorityControls;

        private void Awake()
        {
            gameStateController = GetComponentInParent<GameStateController>();
            priorityControls = FindObjectsOfType<PriorityControl>();

        }

        public void configCharacterForGameplay()
        {
            foreach(PriorityControl priorityControl in priorityControls)
            {
                priorityControl.EnableCharacter(true);
                priorityControl.SetInitialPosition();
            }
        }

        public void RemoveAllCharacterOnField()
        {
            foreach (PriorityControl priorityControl in priorityControls)
            {
                priorityControl.EnableCharacter(false);

            }
        }
    }

}
