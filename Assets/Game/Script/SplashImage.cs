using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class SplashImage : MonoBehaviour
{
    Image image;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        transform.localScale = Vector3.one * 0.7f;
        transform.DOScale(1, 4).SetUpdate(true);
        image.DOFade(0, 1).SetUpdate(true).SetDelay(3);

    }


}
