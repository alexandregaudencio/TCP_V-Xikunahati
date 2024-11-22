using Cinemachine;
using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
namespace Game.Camera
{
    [Serializable]
    public struct shakeData
    {
        [SerializeField] public float intensity;
        [SerializeField] public float duration;
    }

    public class CameraShaker : MonoBehaviour
    {
        private CinemachineVirtualCamera cinemachineVirtualCamera;
        private CinemachineBasicMultiChannelPerlin multiChannelPerlin;
        private Coroutine coroutine;
        public static CameraShaker Instance { get; private set; }

        private void Awake()
        {
            cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
            multiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Start()
        {
            Instance = this;
            ResetShake();
        }
        public void ApplyShake(shakeData skakeData)
        {
            Shake(skakeData.intensity, skakeData.duration);
        }

        public void Shake(float intensity, float duration)
        {
            if (coroutine != null) StopCoroutine(coroutine);
            coroutine = StartCoroutine(ShakeCoroutine(intensity, duration));
        }

        private IEnumerator ShakeCoroutine(float intensity, float duration)
        {
            //float tweenDuration = (float)duration / (float)intensity;
            multiChannelPerlin.m_AmplitudeGain = intensity;
            yield return new WaitForSecondsRealtime(duration);
            DOTween.To(x => multiChannelPerlin.m_AmplitudeGain = x, intensity, 0f, duration).SetUpdate(true);
        }

        private void ResetShake()
        {
            multiChannelPerlin.m_AmplitudeGain = 0;
        }




    }


}