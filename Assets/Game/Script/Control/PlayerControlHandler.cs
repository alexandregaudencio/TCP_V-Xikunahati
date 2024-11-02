using Team;
using UnityEngine;

namespace Character.Control
{
    public class PlayerControlHandler : MonoBehaviour
    {
        [SerializeField] private CharacterControl[] blueOrderedCharacterControl;
        [SerializeField] private CharacterControl[] redOrderedCharacterControl;
        [SerializeField] private PlayerInput[] redInputs;
        [SerializeField] private PlayerInput[] blueInputs;
        private int redIndex = 1;
        private int blueIndex = 1;
        private PlayerInput redCurrentInput;
        private PlayerInput blueCurrentInput;

        public static PlayerControlHandler Instance;

        private bool inputEnabled;


        private void Start()
        {
            Instance = this;
            //for(int i = 0; i < blueOrderedCharacterControl.Length; i++) {

            //    redInputs[i] = redOrderedCharacterControl[i].GetComponent<PlayerInput>();
            //    blueInputs[i] = blueOrderedCharacterControl[i].GetComponent<PlayerInput>();
            //}
            blueCurrentInput = blueInputs[blueIndex];
            redCurrentInput = redInputs[redIndex];


        }

        private void OnGUI()
        {
            string inputEnableLabel = (inputEnabled) ? "Disable input" : "Enable input";
            if (GUI.Button(new Rect(25, 25, 100, 30), inputEnableLabel))
            {
                inputEnabled = !inputEnabled;
                if (inputEnabled)
                {
                    ResetControl();
                }
                else
                {
                    DisableAll(blueOrderedCharacterControl);
                    DisableAll(redOrderedCharacterControl);
                }
            }
        }

        public void ResetControl()
        {
            DisableAll(blueOrderedCharacterControl);
            DisableAll(redOrderedCharacterControl);
            EnableControl(redOrderedCharacterControl, 1);
            EnableControl(blueOrderedCharacterControl, 1);
        }

        private void DisableAll(CharacterControl[] characterControls)
        {
            foreach (CharacterControl characterControl in characterControls)
            {
                characterControl.SetAiControl();
            }
        }

        private void EnableControl(CharacterControl[] characterControls, int index)
        {
            characterControls[index].SetPlayerControl();

        }

        private void Update()
        {
            //ReadBlueLRInputs();
            //ReadRedLRInputs();
        }

        private void ReadRedLRInputs()
        {
            if (redCurrentInput.R())
            {
                redIndex = RightIndex(redIndex);
                DisableAll(redOrderedCharacterControl);
                EnableControl(redOrderedCharacterControl, redIndex);
                redCurrentInput = redInputs[redIndex];

            }
            if (redCurrentInput.L())
            {
                redIndex = LeftIndex(redIndex);
                DisableAll(redOrderedCharacterControl);
                EnableControl(redOrderedCharacterControl, redIndex);
                redCurrentInput = redInputs[redIndex];
            }
        }

        private void ReadBlueLRInputs()
        {
            if (blueCurrentInput.R())
            {
                blueIndex = RightIndex(blueIndex);
                DisableAll(blueOrderedCharacterControl);
                EnableControl(blueOrderedCharacterControl, blueIndex);
                blueCurrentInput = blueInputs[blueIndex];


            }
            if (blueCurrentInput.L())
            {
                blueIndex = LeftIndex(blueIndex);
                DisableAll(blueOrderedCharacterControl);
                EnableControl(blueOrderedCharacterControl, blueIndex);
                blueCurrentInput = blueInputs[blueIndex];

            }


        }


        private int LeftIndex(int index)
        {
            if (index == 0) return 2;
            if (index == 1) return 0;
            if (index == 2) return 1;
            return 1;
        }
        private int RightIndex(int index)
        {
            if (index == 0) return 1;
            if (index == 1) return 2;
            if (index == 2) return 0;
            return 1;
        }

        public PlayerInput GetRandomPlayerInput(TEAM team)
        {
            int randomIndex = Random.Range(0, redInputs.Length);
            if (team == TEAM.Red)
            {
                return redInputs[randomIndex];

            }
            return blueInputs[randomIndex];

        }
    }

}
