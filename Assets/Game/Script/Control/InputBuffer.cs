using DG.Tweening;
using System;
using UnityEngine;

namespace Game.Character
{

    [Serializable]
    public class TeamBuffer
    {
        public TEAM team;
        private float startTime;
        public float timeRelease;
        public bool inputBuffered => timeRelease > 0;
        public event Action StartTime = delegate { };
        public TeamBuffer(TEAM team, float startTime)
        {
            this.team = team;
            this.startTime = startTime;
        }
        public void RestartBuffer()
        {
            timeRelease = startTime;
            StartTime?.Invoke();
        }

        public void Update()
        {
            if (team.head()) RestartBuffer();
            if (timeRelease > 0) timeRelease -= Time.unscaledDeltaTime;
        }


    }
    public class InputBuffer : MonoBehaviour
    {

        [Range(0, 1)] public float bufferTime = 0.5f;
        public TeamBuffer redTeamBuffer;
        public TeamBuffer blueTeamBuffer;
        [SerializeField] private RectTransform redBufferViewImage;
        [SerializeField] private RectTransform blueBufferViewImage;
        public static InputBuffer Instance;

        private void Awake()
        {
            Instance = this;
            redTeamBuffer = new TeamBuffer(TEAM.Red, bufferTime);
            blueTeamBuffer = new TeamBuffer(TEAM.Blue, bufferTime);
            blueBufferViewImage.sizeDelta = new Vector2(15, 0);
            redBufferViewImage.sizeDelta = new Vector2(15, 0);

        }
        private void OnDisable()
        {
            redTeamBuffer.StartTime -= OnRedStart;
            blueTeamBuffer.StartTime -= OnBlueStart;
        }

        private void OnEnable()
        {
            redTeamBuffer.StartTime += OnRedStart;
            blueTeamBuffer.StartTime += OnBlueStart;
        }

        private void OnBlueStart()
        {
            blueBufferViewImage.sizeDelta = new Vector2(15, 130);
            blueBufferViewImage.DOSizeDelta(new Vector2(15, 0), bufferTime).SetUpdate(true);
        }

        private void OnRedStart()
        {
            redBufferViewImage.sizeDelta = new Vector2(15, 130);
            redBufferViewImage.DOSizeDelta(new Vector2(15, 0), bufferTime).SetUpdate(true);
        }



        void Update()
        {
            redTeamBuffer.Update();
            blueTeamBuffer.Update();

        }


        public bool TeamHeadInputBuffered(TEAM team)
        {
            if (team == TEAM.Red) return redTeamBuffer.inputBuffered;
            if (team == TEAM.Blue) return blueTeamBuffer.inputBuffered;
            return false;
        }

    }
}
