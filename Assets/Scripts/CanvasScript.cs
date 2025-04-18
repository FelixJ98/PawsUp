using System.Collections;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    public Transform pawsupTransform;
    public Vector3 startOffset = new Vector3(0, 100f, 0);
    private Vector3 pawsupFinalPosition;
    public SpriteRenderer pawsupSprite;
    public CanvasGroup startButtonCanvas;
    public CanvasGroup quitButtonCanvas;
    public float fadeDuration = 1f; // Pawsup fade duration
    public float moveDuration = 2f; // Pawsup move duration
    public float buttonFadeDuration = 0.5f; // Faster fade-in for buttons

    void Start()
    {
        pawsupFinalPosition = pawsupTransform.position;
        pawsupTransform.position = pawsupFinalPosition + startOffset;
        pawsupSprite.color = new Color(pawsupSprite.color.r, pawsupSprite.color.g, pawsupSprite.color.b, 0f);
        startButtonCanvas.alpha = 0f;
        quitButtonCanvas.alpha = 0f;

        StartCoroutine(FadeInSequence());
    }

    IEnumerator FadeInSequence()
    {
        yield return StartCoroutine(FadeInPawsup());
        yield return StartCoroutine(FadeInStartButton());
        yield return StartCoroutine(FadeInQuitButton());
    }

    IEnumerator FadeInPawsup()
    {
        float elapsedTime = 0;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / fadeDuration);
            pawsupSprite.color = new Color(pawsupSprite.color.r, pawsupSprite.color.g, pawsupSprite.color.b, alpha);
            pawsupTransform.position = Vector3.Lerp(pawsupFinalPosition + startOffset, pawsupFinalPosition, elapsedTime / moveDuration);
            yield return null;
        }
    }

    IEnumerator FadeInStartButton()
    {
        float elapsedTime = 0;
        while (elapsedTime < buttonFadeDuration) // Faster fade for buttons
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / buttonFadeDuration);
            startButtonCanvas.alpha = alpha;
            yield return null;
        }
    }

    IEnumerator FadeInQuitButton()
    {
        float elapsedTime = 0;
        while (elapsedTime < buttonFadeDuration) // Faster fade for buttons
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Clamp01(elapsedTime / buttonFadeDuration);
            quitButtonCanvas.alpha = alpha;
            yield return null;
        }
    }
}
