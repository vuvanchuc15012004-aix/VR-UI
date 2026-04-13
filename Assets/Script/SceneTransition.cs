using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public CanvasGroup fadePanel;
    public float fadeTime = 1f;

    void Start()
    {
        // Ẩn fade khi vào scene
        fadePanel.alpha = 0;
        fadePanel.gameObject.SetActive(false);
    }

    public void LoadScene(int sceneIndex)
    {
        Debug.Log($"---Check LoadScene--- {sceneIndex}");
        // Bật panel lên khi bắt đầu fade
        fadePanel.gameObject.SetActive(true);
        StartCoroutine(FadeAndLoad(sceneIndex));
    }

    IEnumerator FadeAndLoad(int sceneIndex)
    {
        float t = 0;

        // Fade từ trong suốt → đen
        while (t < fadeTime)
        {
            t += Time.deltaTime;
            fadePanel.alpha = t / fadeTime;
            yield return null;
        }

        // Load scene sau khi fade xong
        SceneManager.LoadScene(sceneIndex);
    }
}