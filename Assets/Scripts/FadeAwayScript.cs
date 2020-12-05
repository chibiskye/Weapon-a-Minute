using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeAwayScript : MonoBehaviour
{
    [SerializeField] private float fadeDuration = 2.0f;

    private Image image = null;

    void Awake()
    {
        image = GetComponent<Image>();
        image.canvasRenderer.SetAlpha(0);
    }

    public IEnumerator FadeAway()
    {
        // Fade from transparent to opaque
        image.CrossFadeAlpha(1, fadeDuration, false);

        // Fade from opaque to transparent
        image.canvasRenderer.SetAlpha(1);
        image.CrossFadeAlpha(0, fadeDuration, false);
        yield return new WaitForSeconds(fadeDuration);
    }
}
