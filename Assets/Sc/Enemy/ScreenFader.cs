using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ScreenFader : MonoBehaviour
{
    [SerializeField] private Image whitePanel;
    [SerializeField] private float fadeDuration = 1.0f;

    public void FadeOutAndCall(System.Action onComplete)
    {
        StartCoroutine(FadeOutCoroutine(onComplete));
    }

    internal void FadeOutAndCall()
    {
        throw new NotImplementedException();
    }

    private IEnumerator FadeOutCoroutine(System.Action onComplete)
    {
        float time = 0f;
        Color color = whitePanel.color;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            color.a = Mathf.Clamp01(time / fadeDuration);
            whitePanel.color = color;
            yield return null;
        }

        onComplete?.Invoke(); // フェード完了後にメソッド呼び出し
    }
}
