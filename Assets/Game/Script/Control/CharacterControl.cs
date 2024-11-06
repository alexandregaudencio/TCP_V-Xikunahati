using Game.AudioControl;
using Game.CoreLoop;
using UnityEngine;

namespace Game.Character
{
    public class CharacterControl : MonoBehaviour
    {
        [HideInInspector] public Vector3 initialForward;
        private TeamSelection teamSelection;
        [SerializeField] private MeshRenderer feedback;
        [SerializeField] PlayerControl playerControl;
        [SerializeField] private AIControl aiControl;
        public Control control;
        private CharacterBehaviour behaviour;
        private CharacterAnimation anim;
        private CharacterParticle particle;
        private CharacterHeadControl headControl;
        private CharacterSoundControl soundControl;
        public Control Control { get => control; private set => control = value; }
        public CharacterBehaviour Behaviour { get => behaviour; set => behaviour = value; }
        public CharacterAnimation Animator { get => anim; set => anim = value; }
        public CharacterParticle Particle { get => particle; set => particle = value; }
        public CharacterHeadControl HeadControl { get => headControl; set => headControl = value; }
        public CharacterSoundControl SoundControl { get => soundControl; set => soundControl = value; }

        private TeamTurnHandler TeamTurnHandler;

        private void Awake()
        {
            TeamTurnHandler = FindAnyObjectByType<TeamTurnHandler>();
            teamSelection = GetComponent<TeamSelection>();
            behaviour = GetComponent<CharacterBehaviour>();
            anim = GetComponent<CharacterAnimation>();
            particle = GetComponent<CharacterParticle>();
            headControl = GetComponent<CharacterHeadControl>();
            soundControl = GetComponent<CharacterSoundControl>();
            playerControl = GetComponent<PlayerControl>();
            aiControl = GetComponent<AIControl>();

            SetControl(aiControl);
        }

        private void Start()
        {
            initialForward = transform.forward;
        }

        //subscribed on Serve coreloop state enter/start
        public void ConfigServing()
        {
            bool isCurrentTeamServer = (TeamTurnHandler.TeamTurn == teamSelection.team);
            playerControl.SetServerState(isCurrentTeamServer);
            if (isCurrentTeamServer) SetPlayerControl();

        }

        private void SetControl(Control control)
        {
            control.enabled = true;
            this.control = control;
        }

        public void SetAiControl()
        {
            playerControl.enabled = false;

            SetControl(aiControl);
            feedback.enabled = false;
        }
        public void SetPlayerControl()
        {
            aiControl.enabled = false;
            SetControl(playerControl);
            feedback.enabled = true;
        }

    }
}

