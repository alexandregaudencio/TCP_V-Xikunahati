using Game.Ball;
using Game.Character;
using System;
using UnityEngine;

public class DetectHead : MonoBehaviour
{
    public TEAM team;
    public bool Detect { get; set; } = false;

    public event Action BallEnter = delegate { };
    private BallController ballController;
    private void Awake()
    {
        team = GetComponentInParent<TeamSelection>().team;
        ballController = FindObjectOfType<BallController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            ballController.ballInsideHeadTeam = team;
            BallEnter?.Invoke();
            Detect = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

            Detect = false;
        }
    }
}
