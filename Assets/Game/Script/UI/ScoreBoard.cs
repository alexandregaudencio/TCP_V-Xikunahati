using CoreLoop;
using Team;
using TMPro;
using UnityEngine;

namespace Game
{
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField] private TEAM team;
        [SerializeField] private Score teamScore;
        private TMP_Text text_TeamScore;

        private void Awake()
        {
            text_TeamScore = GetComponentInChildren<TMP_Text>();
            //fieldSide = SearchFieldToScore(team);
        }

        private void OnEnable()
        {
            teamScore.updateTeamScore += ShowScoreText;
        }

        private void OnDisable()
        {
            teamScore.updateTeamScore -= ShowScoreText;
        }

        private void ShowScoreText(int score)
        {
            text_TeamScore.SetText(score.ToString());
        }

    }
}

