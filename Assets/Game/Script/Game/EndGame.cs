using System.Collections.Generic;
using Team;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{

    public class EndGame : MonoBehaviour
    {
        [SerializeField] private Score redScore;
        [SerializeField] private Score blueScore;
        [SerializeField] private Image redUIImage;
        [SerializeField] private Image blueUIImage;

        [SerializeField] private Sprite winnerSprite;
        [SerializeField] private Sprite LoserSprite;


        private TEAM GetWinnerTeam()
        {
            if (redScore.TeamScore < blueScore.TeamScore) 
                return TEAM.Blue;
            if (redScore.TeamScore > blueScore.TeamScore) 
                return TEAM.Red;
            return TEAM.NONE;

        }

        public void ShowWinner()
        {
            if(GetWinnerTeam() == TEAM.Red)
            {
                redUIImage.sprite = winnerSprite;
                blueUIImage.sprite = LoserSprite;
            } else if(GetWinnerTeam() == TEAM.Blue)
            {
                redUIImage.sprite = LoserSprite;
                blueUIImage.sprite = winnerSprite;
            } else
            {
                redUIImage.sprite = winnerSprite;
                blueUIImage.sprite = winnerSprite;
            }
        }


        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ResetGame();
            }
        }


        public void ResetGame()
        {
            SceneManager.LoadScene(0);
        }


    }

}
