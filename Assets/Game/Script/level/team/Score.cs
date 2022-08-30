using System;
using UnityEngine;

namespace Team
{
    [CreateAssetMenu(fileName ="game Score")]
    public class Score : ScriptableObject
    {
        [SerializeField] private int teamScore = 0;
        public event Action<int> updateTeamScore;

        public int TeamScore => teamScore;

        private void OnEnable()
        {
            ResetScore();
        }

        public void IncreaseScore()
        {
            teamScore++;
            updateTeamScore?.Invoke(teamScore);
        }

        public void ResetScore()
        {
            teamScore = 0;
            updateTeamScore?.Invoke(teamScore);

        }
    }
}

