
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowClueController : MonoBehaviour
{
    [SerializeField] private Image[] images;
    [SerializeField] private float fadeDuration = 1f;

    private void Start()
    {
        DisableAllImages();
    }

    public void EnableImage(int index)
    {
        StartCoroutine(FadeImage(images[index], 0f, 1f, fadeDuration));
    }

    private void DisableAllImages()
    {
        foreach (Image image in images)
        {
            image.gameObject.SetActive(false);
        }
    }

    private IEnumerator FadeImage(Image image, float startAlpha, float endAlpha, float duration)
    {
        image.gameObject.SetActive(true);

        Color color = image.color;
        color.a = startAlpha;
        image.color = color;

        float startTime = Time.time;
        float endTime = startTime + duration;

        while (Time.time <= endTime)
        {
            float t = (Time.time - startTime) / duration;
            color.a = Mathf.Lerp(startAlpha, endAlpha, t);
            image.color = color;
            yield return null;
        }

        color.a = endAlpha;
        image.color = color;
    }
}
