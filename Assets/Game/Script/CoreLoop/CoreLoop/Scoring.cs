using System.Collections;
using UnityEngine;

namespace Game.CoreLoop
{
    public class Scoring : MonoBehaviour
    {
        [SerializeField] private int intervalInSeconds = 3;
        [SerializeField] private TeamTurnHandler teamTurnHandler;
        private CoreLoopController coreLoopController;


        private void Awake()
        {
            coreLoopController = GetComponentInParent<CoreLoopController>();
        }



        public void SkillScoringStateDealyed()
        {
            StartCoroutine(WaitForSkipState());

        }



        private IEnumerator WaitForSkipState()
        {
            yield return new WaitForSeconds(intervalInSeconds);
            coreLoopController.NextStep();
        }






    }

}
