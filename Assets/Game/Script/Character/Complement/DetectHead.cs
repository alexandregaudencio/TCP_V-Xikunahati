using System;
using UnityEngine;

public class DetectHead : MonoBehaviour
{
    public bool Detect { get; set; } = false;

    public event Action BallEnter = delegate { };


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
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
