using AYellowpaper.SerializedCollections;
using Game.Ball;
using UnityEngine;

namespace Game.Character
{
    public class PlayerControlHandler : MonoBehaviour
    {
        [SerializeField, SerializedDictionary("Team", "Character Control")]
        private SerializedDictionary<TEAM, CharacterControl[]> characters;
        private BallController ballController;
        public static PlayerControlHandler Instance;

        private bool inputEnabled;
        public CharacterControl[] GetCharacters(TEAM team) => characters[team];

        private void Awake()
        {
            ballController = FindObjectOfType<BallController>();
            DisableAll();
        }

        private void Start()
        {
            Instance = this;
            ballController.HeadedBall += OnHeadedBall;
        }

        private void OnDestroy()
        {
            ballController.HeadedBall -= OnHeadedBall;

        }

        private void OnHeadedBall(ThrowBallData data)
        {
            DisableAll();
            data.CharacterControl.SetPlayerControl();
        }


        private void OnGUI()
        {
            string inputEnableLabel = (inputEnabled) ? "Disable input" : "Enable input";
            if (GUI.Button(new Rect(25, 25, 100, 30), inputEnableLabel))
            {
                inputEnabled = !inputEnabled;
                if (inputEnabled)
                {
                    EnableAll(TEAM.Red);
                    EnableAll(TEAM.Blue);
                }
                else
                {
                    DisableAll();
                }
            }
        }

        public void DisableAll()
        {
            DisableAll(TEAM.Red);
            DisableAll(TEAM.Blue);
        }

        private void DisableAll(TEAM team)
        {
            foreach (CharacterControl characterControl in characters[team])
            {
                characterControl.SetAiControl();
            }
        }
        private void EnableAll(TEAM team)
        {
            foreach (CharacterControl characterControl in characters[team])
            {
                characterControl.SetPlayerControl();
            }
        }


        public CharacterControl GetRandomCharacter(TEAM team)
        {
            int randomIndex = Random.Range(0, 3);
            return characters[team][randomIndex];

        }

    }

}
