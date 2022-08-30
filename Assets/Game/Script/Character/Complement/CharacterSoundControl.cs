using head;
using System;
using System.Collections;
using System.Collections.Generic;
using Team;
using UnityEngine;

[RequireComponent(typeof(CharacterAnimation))]
public class CharacterSoundControl : MonoBehaviour
{
    public RandomAudioPlay footSource;
    public RandomAudioPlay indigenousSource;
    public RandomAudioPlay ballSource;

    private bool currentState;

    public DetectHead detectHead;
    private CharacterAnimation characterAnimation;
    private HeaderControl neck;
    private void Start()
    {
        characterAnimation = GetComponent<CharacterAnimation>();
        currentState = characterAnimation.Floor;
        neck = GetComponentInChildren<HeaderControl>();
        detectHead = GetComponentInChildren<DetectHead>();
    }
    public void Run(Collision collision)
    {
        if (footSource.canPlay && collision.gameObject.CompareTag("FieldRange"))
        {
            footSource.PlayRandomClip(SOUND_KEY.foot, 0);
            footSource.audioSource.loop = true;
            footSource.canPlay = false;
        }
    }
    public void Stop()
    {
        footSource.canPlay = true;
        footSource.audioSource.Stop();
        footSource.audioSource.loop = false;
    }

    public void Head()
    {
        indigenousSource.PlayRandomClip(SOUND_KEY.head, 0);
    }

    public void Blow(SOUND_KEY status)
    {
        switch (status)
        {
            case SOUND_KEY.head:
                indigenousSource.PlayRandomClip(SOUND_KEY.head, 0);
                break;
            //case SOUND_KEY.body:
            //    indigenousSource.PlayRandomClip(SOUND_KEY.body, 0);
            //    break;
        }
    }
    public void Trot()
    {
    }
    public void Jump()
    {
        footSource.PlayRandomClip(SOUND_KEY.foot, 1);
    }
    public void Fall()
    {
        footSource.PlayRandomClip(SOUND_KEY.foot, 2);
    }
    public void Dive()
    {
        indigenousSource.PlayRandomClip(SOUND_KEY.floor, 2);
    }
    private void Update()
    {
        if (detectHead.Detect)
        {
            detectHead.Detect = false;
            Blow(SOUND_KEY.head);
        }
        if (characterAnimation.Floor != currentState && !neck.dive)
        {
            footSource.audioSource.loop = false;
            if (currentState)
            {
                Jump();
            }
            else
            {
                Fall();
            }
            currentState = characterAnimation.Floor;

        }
    }
}
