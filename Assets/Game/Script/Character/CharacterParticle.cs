using head;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterParticle : MonoBehaviour
{
    public ParticleSystem head;
    public ParticleSystem jump;
    public ParticleSystem fall;
    public ParticleSystem run;

    private DetectHead dh;
    private void Awake()
    {
        dh = GetComponentInChildren<DetectHead>();
    }

    private void Update()
    {
        if (dh.Detect)
        {
            Head();
        }
    }
    public void Jumping()
    {
        run.Stop();
        jump.Play();
    }
    public void Fall()
    {
        fall.Play();
    }
    public void Move()
    {
        run.Play();
    }

    public void Head()
    {
        head.Play();
    }
    public void Idle()
    {
        run.Stop();
    }
}
