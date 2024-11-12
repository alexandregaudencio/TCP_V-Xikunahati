using DG.Tweening;
using UnityEngine;

public static class TimeScaleHandler
{
    private static Tween tween;

    public static void SetTimeScale(float scale, float duration = 0, Ease ease = Ease.Linear)
    {
        tween.Kill();
        tween = DOTween.To(() => Time.timeScale, x => Time.timeScale = x, scale, duration)
            .SetEase(ease)
            .SetUpdate(true)
            .SetId("TimeScaleTween");
    }



}
