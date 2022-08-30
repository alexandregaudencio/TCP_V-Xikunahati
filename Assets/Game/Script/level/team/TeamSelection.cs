using System;
using UnityEngine;
namespace Team
{
    [Serializable] public enum TEAM { Red, Blue, NONE };
    public class TeamSelection : MonoBehaviour
    {
        public TEAM team = TEAM.Red;
        public MeshRenderer feedback;
        private Vector3 startPosition;

        private void Start()
        {
            gameObject.tag = team.ToString();
            //feedback.enabled = Captain;
            //if (Captain)
            //{
            //    GetComponent<CharacterControl>().SetControl(GetComponent<PlayerInput>());
            //}
            //else
            //{
            //    GetComponent<CharacterControl>().SetControl(GetComponent<AIControl>());
            //}
            startPosition = feedback.transform.position;
        }

        //internal void Swap()
        //{
        //    string teamName = gameObject.tag.ToString();
        //    GameObject[] team = GameObject.FindGameObjectsWithTag(teamName);
        //    foreach (GameObject go in team)
        //    {
        //        go.GetComponent<CharacterControl>().SetControl(GetComponent<AIControl>());
        //        go.GetComponent<CharacterAnimation>().Idle();
        //        go.GetComponent<TeamSelection>().feedback.enabled = false;
        //    }
        //    GetComponent<CharacterControl>().SetControl(GetComponent<PlayerInput>());
        //    feedback.enabled = true;
        //}
        private void Update()
        {
            feedback.gameObject.transform.position = new Vector3(transform.position.x, startPosition.y, transform.position.z);
        }
        //public float Convert()
        //{
        //    switch (team) {
        //        case TEAM.Red:
        //            return -1f; 
        //        case TEAM.Blue:
        //            return 1f;
        //    }
        //    return 0;
        //}
    }
}
