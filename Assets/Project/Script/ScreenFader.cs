using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour
{
    CanvasGroup _canvasGroup;
    [SerializeField] float fadeTime;
    [SerializeField] bool coverOnAwake;
    Coroutine currentCor = null;

    private void Awake()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _canvasGroup.alpha = (coverOnAwake)?1:0;
    }

    private void Start()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        if (currentCor != null) return;
        currentCor = StartCoroutine(FadeIn(fadeTime));
    }

    public void FadeOut()
    {
        if (currentCor != null) return;
        currentCor = StartCoroutine(FadeOut(fadeTime));
    }

    public IEnumerator FadeOut(float time)
    {
        _canvasGroup.alpha = 0;
        while (_canvasGroup.alpha < 1)
        {
            _canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
        currentCor = null;
    }


    public IEnumerator FadeIn(float time)
    {
        _canvasGroup.alpha = 1;
        while (_canvasGroup.alpha > 0)
        {
            _canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
        currentCor = null;
    }
}
