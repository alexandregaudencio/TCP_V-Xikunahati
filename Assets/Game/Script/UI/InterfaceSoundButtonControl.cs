using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SoundButtonManager
{
    [RequireComponent(typeof(AudioSource))]
    public class InterfaceSoundButtonControl : MonoBehaviour
    {
        public SoundButton[] list;
        private Dictionary<BUTTON, AudioClip> dict = new Dictionary<BUTTON, AudioClip>();
        private AudioSource audioSource;
        private void Awake()
        {
            this.audioSource = GetComponent<AudioSource>();
            foreach (SoundButton sound in list)
            {
                dict[sound.tag] = sound.clip;
            }
        }
        public void SoundSelect()
        {
            this.audioSource.clip = this.dict[BUTTON.select];
            this.audioSource.Play();
        }
        public void SoundSubmit()
        {
            this.audioSource.clip = this.dict[BUTTON.submit];
            this.audioSource.Play();
        }
        public void SaoundError()
        {
            this.audioSource.clip = this.dict[BUTTON.error];
            this.audioSource.Play();
        }
        public void SoundScape()
        {
            this.audioSource.clip = this.dict[BUTTON.scape];
            this.audioSource.Play();
        }
    }
    public enum BUTTON { submit, scape, select, error }
    [System.Serializable]
    public struct SoundButton
    {
        public BUTTON tag;
        public AudioClip clip;
    }
}