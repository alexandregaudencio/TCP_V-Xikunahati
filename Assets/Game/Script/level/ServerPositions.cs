using AYellowpaper.SerializedCollections;
using Game.Character;
using UnityEngine;

namespace Game.Level
{
    public class ServerPositions : MonoBehaviour
    {
        [SerializeField, SerializedDictionary("Character", "Position")] SerializedDictionary<CharacterControl, Transform> characterServePosition;

        public Transform GetSevePosition(CharacterControl characterControl) => characterServePosition[characterControl];


    }
}
