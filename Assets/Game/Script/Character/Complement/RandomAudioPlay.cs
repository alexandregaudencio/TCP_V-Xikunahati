using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SOUND_KEY {
    mute,  
    foot, 
    head,  
    audience,
    floor,
}
[RequireComponent(typeof(AudioSource))]
public class RandomAudioPlay : MonoBehaviour
{
    [Serializable]
    public class MaterialAudioOverride
    {
        public SOUND_KEY[] key;
        public SoundBank[] banks;
    }

    [Serializable]
    public class SoundBank
    {
        public string name;
        public AudioClip[] clips;
    }

    public bool randomizePitch = true;
    public float pitchRandomRange = 0.2f;
    public float playDelay = 0;
    public SoundBank defaultBank = new SoundBank();
    public MaterialAudioOverride[] overrides;

    [HideInInspector]
    public bool playing;
    [HideInInspector]
    public bool canPlay;

    protected AudioSource m_Audiosource;
    protected Dictionary<SOUND_KEY, SoundBank[]> m_Lookup = new Dictionary<SOUND_KEY, SoundBank[]>();

    public AudioSource audioSource { get { return m_Audiosource; } }

    public AudioClip clip { get; private set; }

    void Awake()
    {
        m_Audiosource = GetComponent<AudioSource>();
        for (int i = 0; i < overrides.Length; i++)
        {
            foreach (SOUND_KEY key in overrides[i].key)
                m_Lookup[key] = overrides[i].banks;
        }
    }

    public AudioClip PlayRandomClip(SOUND_KEY overrideKey, int bankId = 0)
    {
        return InternalPlayRandomClip(overrideKey, bankId);
    }

    public void PlayRandomClip()
    {
        clip = InternalPlayRandomClip(SOUND_KEY.audience, bankId: 0);
    }

    AudioClip InternalPlayRandomClip(SOUND_KEY key, int bankId)
    {
        SoundBank[] banks = null;
        var bank = defaultBank;
        if (key != SOUND_KEY.mute)
            if (m_Lookup.TryGetValue(key, out banks))
                if (bankId < banks.Length)
                    bank = banks[bankId];
        if (bank.clips == null || bank.clips.Length == 0)
            return null;
        var clip = bank.clips[UnityEngine.Random.Range(0, bank.clips.Length)];

        if (clip == null)
            return null;

        m_Audiosource.pitch = randomizePitch ? UnityEngine.Random.Range(1.0f - pitchRandomRange, 1.0f + pitchRandomRange) : 1.0f;
        m_Audiosource.clip = clip;
        m_Audiosource.PlayDelayed(playDelay);

        return clip;
    }

}
