using Character.Control;
using System.Collections;
using Team;
using UnityEngine;

namespace CoreLoop
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private int intervalInSeconds = 3;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        private CoreLoopController coreLoopController;

        private Players player;
        
        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }

        private void Start()
        {
            teamTurnHandler.turnOver += UpdateTeamServe;

        }

        private void OnDestroy()
        {
            teamTurnHandler.turnOver -= UpdateTeamServe;

        }

        private void OnEnable()
        {
            StartCoroutine(WaitForSkipState());

        }
        private void OnDisable()
        {
            StopCoroutine(WaitForSkipState());
        }       



        private void UpdateTeamServe(TEAM team)
        {
            player = (team == TEAM.Blue) ? Players.Player2 : Players.Player1;
        }

        private IEnumerator WaitForSkipState()
        {
            yield return new WaitForSeconds(intervalInSeconds);
            coreLoopController.NextStep();
        }






    }

}
