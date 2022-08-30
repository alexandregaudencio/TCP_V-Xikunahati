using Character;
using Character.Control;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Team;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    private new Rigidbody rigidbody;
    
    private Vector3 speed;
    private Animator anim;
    public bool dive = false;
    public float count;
    public bool Floor { get => this.anim.GetBool("onFloor"); private set { } }

    public Animator Anim { get => anim; set => anim = value; }

    private void Awake()
    {
        this.anim = GetComponentInChildren<Animator>();
        this.rigidbody = GetComponent<Rigidbody>();
        anim.Play("idle");

    }

    public void Jumping()
    {
        anim.Play("jump");
    }

    public void Dive()
    {
        anim.Play("dive");
        //count = anim.GetCurrentAnimatorStateInfo(0).length / anim.GetCurrentAnimatorStateInfo(0).speed;
        count = 1;
        this.dive = true;
    }
    public bool IsDive()
    {
        if (count < 0)
            this.dive = false;
        return this.dive;
    }
    public void Head()
    {
        if (this.dive)
            this.anim.SetTrigger("headDive");
        else
            this.anim.SetTrigger("head");
    }
    
    //public void Falling()
    //{
    //    anim.SetFloat("vertical", characterBehaviour.CharacterRigidbody.velocity.y);
    //}

    public void Idle()
    {
        anim.Play("idle");
        //this.anim.SetBool("move", false);
    }

    public void Move()
    {
        anim.Play("move");
        //this.anim.SetBool("move", true);
    }

    private void Update()
    {
        this.speed.y = float.Parse(this.rigidbody.velocity.normalized.y.ToString("0.00"));
        this.anim.SetFloat("vertical", this.speed.y);
        if(count > -1)
        {
            count -= Time.deltaTime;
        }

    }


    private void OnCollisionExit(Collision collision)
    {
        bool isField = LayerMask.LayerToName(collision.gameObject.layer) == "Field";
        if (isField)
        {
            this.anim.SetBool("onFloor", false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bool isField = LayerMask.LayerToName(collision.gameObject.layer) == "Field";
        if (isField)
        {
            this.anim.SetBool("onFloor", true);
        }
    }
}
