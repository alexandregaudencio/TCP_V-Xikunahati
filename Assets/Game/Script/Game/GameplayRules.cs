using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game
{
    public class GameplayRules : MonoBehaviour
    {
        [SerializeField] private Timer gameplayTimer;
        private GameStateController gameStateController;
        private void Awake()
        {
            gameStateController = GetComponentInParent<GameStateController>();
        }
        // Start is called before the first frame update


        private void OnEnable()
        {
            gameplayTimer.timeOver += FinishRollingBall;
        }

        private void OnDisable()
        {
            gameplayTimer.timeOver -= FinishRollingBall;

        }

        // Update is called once per frame
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


        public void FinishRollingBall()
        {

            gameStateController.nextStep(); 
        }


    }

}

