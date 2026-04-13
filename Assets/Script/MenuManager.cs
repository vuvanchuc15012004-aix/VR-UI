using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void LoadLesson(int sceneIndex)
    {
        Debug.Log("Load scene index: " + sceneIndex);

        SceneManager.LoadScene(sceneIndex);
    }

    public void QuitGame()
    {
        Debug.Log("Thoát game");
        Application.Quit();
    }
}