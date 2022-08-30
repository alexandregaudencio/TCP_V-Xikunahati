using Game;
using System.Collections.Generic;
using UnityEngine;

namespace FSMUI
{
    [System.Serializable]
    public struct STATE
    {
        public SCREEN key;
        public Transform value;
    }
    public class StateControl : MonoBehaviour
    {
        public GameObject initialButtonSelect;
        private Dictionary<SCREEN, Transform> dict = new Dictionary<SCREEN, Transform>();
        public StateScreen screens;
        public STATE[] nextState;
        private float timeOfFirtBurn;
        private float[] EnterDelay;
        private float[] ExitDelay;
        private bool[] checkIn;
        private bool[] checkOut;
        private float exitTime = 0;
        public static StateControl instance;

        public float TimeOfFirtBurn
        {
            get
            {
                timeOfFirtBurn = 0;
                float aux = 0;
                foreach (var e in screens.animables)
                {
                    if (timeOfFirtBurn < e.UIData.endTime)
                    {
                        timeOfFirtBurn = e.UIData.endTime;
                    }
                }
                foreach (var e in screens.animables)
                {
                    if (aux < e.UIData.endDelay)
                    {
                        aux = e.UIData.endDelay;
                    }
                }
                this.timeOfFirtBurn += aux;
                return this.timeOfFirtBurn;
            }
            private set
            {

            }
        }
        public float TimeOfFirtBurnStart
        {
            get
            {
                float aux0 = 0;
                float aux1 = 0;
                foreach (var e in screens.animables)
                {
                    if (aux0 < e.UIData.startTime)
                    {
                        aux0 = e.UIData.startTime;
                    }
                }
                foreach (var e in screens.animables)
                {
                    if (aux1 < e.UIData.startDelay)
                    {
                        aux1 = e.UIData.startDelay;
                    }
                }
                return aux0 + aux1;
            }
            private set
            {

            }
        }

        private void Awake()
        {
            instance = this;
            EnterDelay = new float[screens.animables.Length];
            ExitDelay = new float[screens.animables.Length];
            checkIn = new bool[screens.animables.Length];
            checkOut = new bool[screens.animables.Length];
            foreach (STATE ss in nextState)
            {
                dict[ss.key] = ss.value;
            }
        }
        private void OnEnable()
        {
            for (int i = 0; i < EnterDelay.Length; i++)
            {
                EnterDelay[i] = screens.animables[i].UIData.startDelay;
                ExitDelay[i] = screens.animables[i].UIData.endDelay;
                checkIn[i] = true;
                checkOut[i] = false;
            }
            Invoke("ActiveHover", TimeOfFirtBurnStart);
        }
        private void ActiveHover()
        {
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(null);
            UnityEngine.EventSystems.EventSystem.current.SetSelectedGameObject(initialButtonSelect);
        }
        private void OnDisable()
        {
            if (screens.background)
                screens.background.SetActive(true);
            gameObject.SetActive(false);
        }

        public void ChangeTo(SCREEN next)
        {
            screens.background = dict[next].gameObject;
            for (int i = 0; i < EnterDelay.Length; i++)
            {
                EnterDelay[i] = screens.animables[i].UIData.startDelay;
                ExitDelay[i] = screens.animables[i].UIData.endDelay;
                checkIn[i] = false;
                checkOut[i] = true;
            }
            if (!(EnterDelay.Length > 0))
            {
                OnDisable();
            }
        }

        private void Update()
        {
            delay();
        }

        private void delay()
        {
            for (int i = 0; i < EnterDelay.Length; i++)
            {
                if (checkIn[i])
                {
                    EnterDelay[i] -= (Time.deltaTime == 0) ? Time.fixedDeltaTime : Time.deltaTime;
                    if (EnterDelay[i] < 0f)
                    {
                        checkIn[i] = false;
                        CheckScreenPosition(i);
                    }
                }
                if (checkOut[i])
                {
                    ExitDelay[i] -= (Time.deltaTime == 0) ? Time.fixedDeltaTime : Time.deltaTime;
                    if (ExitDelay[i] < 0f)
                    {
                        checkOut[i] = false;
                        exitTime = TimeOfFirtBurn;
                        CheckScreenPosition(i);
                        if (Time.timeScale > 0)
                            Invoke("OnDisable", exitTime);
                    }
                }
                else if (Time.timeScale == 0)
                {
                    if (exitTime < 0)
                    {
                        OnDisable();
                    }
                    exitTime -= (Time.deltaTime == 0) ? Time.fixedDeltaTime : Time.deltaTime;
                }

            }
        }

        private void CheckScreenPosition(int i)
        {
            switch (screens.animables[i].UIData.initialPositionOnScreen)
            {
                case DIRECTION.outside:
                    AnimeStateIn(screens.animables[i]);
                    screens.animables[i].UIData.initialPositionOnScreen = DIRECTION.inside;
                    break;
                case DIRECTION.inside:

                    AnimeStateOut(screens.animables[i]);
                    screens.animables[i].UIData.initialPositionOnScreen = DIRECTION.outside;
                    break;
            }
        }

        private void AnimeStateIn(UIState e)
        {
            switch (e.UIData.axle)
            {
                case AXLE.horizontal:
                    e.animationTarget.LeanMoveLocalX(e.UIData.endPosition, e.UIData.endTime).setEase(e.UIData.type).setIgnoreTimeScale(true);
                    break;
                case AXLE.vertical:
                    e.animationTarget.LeanMoveLocalY(e.UIData.endPosition, e.UIData.startTime).setEase(e.UIData.type).setIgnoreTimeScale(true);

                    break;
            }
        }
        private void AnimeStateOut(UIState e)
        {
            switch (e.UIData.axle)
            {
                case AXLE.horizontal:
                    e.animationTarget.LeanMoveLocalX(e.UIData.startPosition, e.UIData.startTime).setEase(e.UIData.type).setIgnoreTimeScale(true);
                    break;

                case AXLE.vertical:
                    e.animationTarget.LeanMoveLocalY(e.UIData.startPosition, e.UIData.endTime).setEase(e.UIData.type).setIgnoreTimeScale(true);
                    break;
            }
        }
    }
    public enum DIRECTION { inside, outside }
    public enum AXLE { vertical, horizontal }
    [System.Serializable]
    public struct StateScreen
    {
        public SCREEN screen;
        public GameObject background;
        public UIState[] animables;
    }

    [System.Serializable]
    public struct UIState
    {
        public GameObject animationTarget;
        public UIData UIData;
    }

    [System.Serializable]
    public class UIData
    {
        public DIRECTION initialPositionOnScreen;
        public LeanTweenType type;
        public AXLE axle;
        public float startTime;
        public float endTime;
        public float startPosition;
        public float endPosition;
        public float startDelay;
        public float endDelay;
        public float[] Time { get => new float[2] { this.startTime, this.endTime }; set { } }
    }
}