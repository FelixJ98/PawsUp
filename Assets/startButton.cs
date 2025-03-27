using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public CanvasGroup menuCanvas; // Assign the UI Canvas Group
    public SpriteRenderer[] spritesToFade; // Assign your sprites (like "pawsup") in Inspector
    public float fadeDuration = 1f; // Time for fade effect
    public string sceneToLoad = "testing"; // Scene name
    public ParticleSystem[] confettiSystems; // Assign both confetti systems in Inspector


    public void StartSceneTransition()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    IEnumerator FadeAndLoadScene()
    {
        foreach (var confetti in confettiSystems)
        {
            if (confetti != null)
            {
                confetti.Play();
            }
        }
        float elapsedTime = 0;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = 1 - (elapsedTime / fadeDuration); // Decrease alpha over time

            // Fade UI (Canvas Group)
            menuCanvas.alpha = alpha;

            // Fade all Sprite Renderers
            foreach (var sprite in spritesToFade)
            {
                sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, alpha);
            }

            yield return null;
        }

        // Load the new scene
        yield return new WaitForSeconds(0.5f); // Adjust delay as needed

        SceneManager.LoadScene(sceneToLoad);
    }
}
