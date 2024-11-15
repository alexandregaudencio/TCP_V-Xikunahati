using DG.Tweening;
using UnityEngine;

public static class TimeScaleHandler
{
    private static Tween tween;

    public static void SetTimeScale(float scale, float duration, Ease ease = Ease.Linear)
    {
        tween.Kill();
        tween = DOTween.To(
            () => Time.timeScale,
            x => SetTimeScale(x),
            scale,
            duration)
                .SetEase(ease)
                .SetUpdate(true)
                .SetId("TimeScaleTween");
    }

    public static void SetTimeScale(float value)
    {

        Time.timeScale = value;
        Time.fixedDeltaTime = 0.02f * value;
    }



}
