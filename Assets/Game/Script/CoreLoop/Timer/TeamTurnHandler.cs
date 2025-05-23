using Game.Ball;
using Game.Character;
using UnityEngine;


namespace Game.CoreLoop
{
    public class TeamTurnHandler : MonoBehaviour
    {
        [SerializeField] private TEAM teamTurn;
        //public event Action ballStopped;
        [SerializeField] private BallController ballController;
        [SerializeField] private ScoreRules scoreRules;
        public TEAM TeamTurn => teamTurn;
        public static TeamTurnHandler Instance;
        private void Awake()
        {
            Instance = this;
            ballController = FindObjectOfType<BallController>();
            scoreRules = FindAnyObjectByType<ScoreRules>();
        }
        private void OnEnable()
        {
            ballController.BallChangeFieldSide += BallChangeFieldSide;

        }
        private void OnDisable()
        {
            ballController.BallChangeFieldSide -= BallChangeFieldSide;

        }

        private void BallChangeFieldSide(TEAM teamTurn)
        {
            Debug.Log("change side: " + teamTurn);
            this.teamTurn = teamTurn;
        }



    }

}
