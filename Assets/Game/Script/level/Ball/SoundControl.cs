using UnityEngine;


namespace Game.AudioControl
{
    public class SoundControl : MonoBehaviour
    {
        private RandomAudioPlay randomAudioPlay;

        private void Awake()
        {
            randomAudioPlay = GetComponent<RandomAudioPlay>();
        }
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Head"))
            {
                randomAudioPlay.PlayRandomClip(SOUND_KEY.head, 0);
            }
            if (collision.gameObject.CompareTag("FieldRange"))
            {
                randomAudioPlay.PlayRandomClip(SOUND_KEY.floor, 0);
            }
            if (collision.gameObject.CompareTag("grass"))
            {
                randomAudioPlay.PlayRandomClip(SOUND_KEY.floor, 1);
            }
        }
    }
}