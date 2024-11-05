using Game.Character.StateMachine;
using Team;
using UnityEngine;

namespace Game.CoreLoop
{
    public class CharacterRestrictionOnServe : MonoBehaviour
    {
        [SerializeField] private PlayerStateMachine[] redCharacterFSM;
        [SerializeField] private PlayerStateMachine[] blueCharacterFSM;
        [SerializeField] private ScoreRules scoreRules;
        public void RestricMovement()
        {
            if (scoreRules.LastTeamMarkedPoint == TEAM.Blue)
            {
                foreach (PlayerStateMachine stateMachine in redCharacterFSM)
                {
                    stateMachine.GoServeState();
                }

            }
            else
            {
                foreach (PlayerStateMachine stateMachine in blueCharacterFSM)
                {
                    stateMachine.GoServeState();
                }

            }
        }

        public void ReturnTeamServingToIdleState()
        {
            blueCharacterFSM[0].GoIdleState();
            blueCharacterFSM[2].GoIdleState();
            redCharacterFSM[0].GoIdleState();
            redCharacterFSM[2].GoIdleState();
        }


    }

}
