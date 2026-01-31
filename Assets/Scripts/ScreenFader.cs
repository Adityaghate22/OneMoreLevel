using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScreenFader : MonoBehaviour
{
    public Image fadeImage;
    public float fadeSpeed = 1.5f;

    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public void FadeToNextLevel(string sceneName)
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeOut(sceneName));
    }
    // transitions for fading in and out
    IEnumerator FadeIn()
    {
        float alpha = 1;
        while (alpha > 0)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }
    }

    IEnumerator FadeOut(string sceneName)
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime * fadeSpeed;
            fadeImage.color = new Color(0, 0, 0, alpha);
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }
}
