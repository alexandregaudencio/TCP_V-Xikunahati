using TMPro;

namespace Game
{
    public class TimerManager : Timer
    {
        private TMP_Text text_timer;

        private void Awake()
        {
            text_timer = GetComponentInChildren<TMP_Text>();
        }
        private void Start()
        {
            timerChange += UpdateTimerText;
            text_timer.SetText(TimeClockFormated());
        }

        private void OnDestroy()
        {
            timerChange -= UpdateTimerText;

        }

        private void UpdateTimerText(/*float time*/)
        {
            text_timer.SetText(TimeClockFormated());

        }

    }
}

