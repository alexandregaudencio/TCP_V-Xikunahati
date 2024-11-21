using AYellowpaper.SerializedCollections;
using Game.Character;
using UnityEngine;

namespace Game.Level
{
    public class ServerPositions : MonoBehaviour
    {
        private PlayerControlHandler playerControlHandler;
        [SerializeField, SerializedDictionary("Character", "Position")]
        SerializedDictionary<CharacterControl, Transform> characterServePosition;

        private void Awake()
        {
            playerControlHandler = FindObjectOfType<PlayerControlHandler>();
        }

        public Transform GetSevePosition(CharacterControl characterControl) => characterServePosition[characterControl];
        public Transform GetServePosition(TEAM team)
        {
            var middleCharacterControl = playerControlHandler.GetMiddleCharacter(team);
            return characterServePosition[middleCharacterControl];
        }

    }
}
