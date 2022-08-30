using FSMUI;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
    public enum SCREEN { banner, menu, inGame, endGame, resume, credits, configure, pause, tutorial }
    [System.Serializable]
    public struct PairValueKey
    {
        public SCREEN key;
        public StateControl value;
    }
    public class StartGame : MonoBehaviour
    {
        private static Dictionary<SCREEN, StateControl> dict = new Dictionary<SCREEN, StateControl>();
        public PairValueKey[] elements;
        private static Stack<SCREEN> last;
        public static Stack<SCREEN> LastState { get { return last; } private set { } }

        private void Awake()
        {
            last = new Stack<SCREEN>();
            foreach (PairValueKey pk in elements)
            {
                dict[pk.key] = pk.value;
            }
        }

        private void Start()
        {
            last = new Stack<SCREEN>();
            last.Push(SCREEN.banner);
            dict[LastState.Peek()].gameObject.SetActive(true);
        }

        public static void MakeTransiction(SCREEN item)
        {
            if (LastState.Count > 0)
            {
                dict[LastState.Peek()].ChangeTo(item);
                if (!LastState.Peek().Equals(item))
                    LastState.Push(item);
            }
        }
    }
}
