using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundConfigure : MonoBehaviour
{
    public AudioMixer mixer;
    private Scrollbar sb;
    public VOLUME_TAG tag;
    private float currentVolume;
    void Start()
    {
        sb = GetComponent<Scrollbar>();

        mixer.GetFloat(tag.ToString(), out currentVolume);
        sb.value = (currentVolume + 20) / 40;
    }
    public void SetVolume()
    {
        mixer.SetFloat(tag.ToString(), -20 + (20 + 20) * sb.value);
    }
}
[System.Serializable]
public enum VOLUME_TAG { FXVolume, masterVolume, backgroundVolume, dynamicsVolume }
