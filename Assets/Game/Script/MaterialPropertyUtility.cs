using DG.Tweening;
using UnityEngine;

namespace Game.Core
{

    public static class MaterialPropertyUtility
    {
        public static Tween InterpolateFloat(this Renderer renderer, int propertyID, float targetValue, float duration = 1, Ease ease = Ease.Linear, float delay = 0)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            float startValue = propertyBlock.GetFloat(propertyID);

            return DOTween.To(() => startValue, value =>
             {
                 startValue = value;
                 propertyBlock.SetFloat(propertyID, startValue);
                 renderer.SetPropertyBlock(propertyBlock);
             }, targetValue, duration);

        }

        public static Tween InterpolateInt(this Renderer renderer, int propertyID, int targetValue, float duration = 1, Ease ease = Ease.Linear, float delay = 0)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            int startValue = propertyBlock.GetInt(propertyID);

            return DOTween.To(() => startValue, value =>
            {
                startValue = value;
                propertyBlock.SetInt(propertyID, startValue);
                renderer.SetPropertyBlock(propertyBlock);
            }, targetValue, duration);

        }

        public static Tween InterpolateColor(this Renderer renderer, int propertyID, Color targetValue, float duration = 1, Ease ease = Ease.Linear, float delay = 0)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            Color startValue = propertyBlock.GetColor(propertyID);

            return DOTween.To(() => startValue, value =>
            {
                startValue = value;
                propertyBlock.SetColor(propertyID, startValue);
                renderer.SetPropertyBlock(propertyBlock);
            }, targetValue, duration);

        }

        public static Tween InterpolateVector(this Renderer renderer, int propertyID, Vector4 targetValue, float duration = 1, Ease ease = Ease.Linear, float delay = 0)
        {
            var propertyBlock = new MaterialPropertyBlock();
            renderer.GetPropertyBlock(propertyBlock);
            Vector4 startValue = propertyBlock.GetVector(propertyID);

            return DOTween.To(() => startValue, value =>
             {
                 startValue = value;
                 propertyBlock.SetVector(propertyID, startValue);
                 renderer.SetPropertyBlock(propertyBlock);
             }, targetValue, duration);

        }


    }

}
