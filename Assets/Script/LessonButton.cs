using UnityEngine;
using UnityEngine.UI;

public class LessonButton : MonoBehaviour
{
    public int lessonIndex;
    public Button button;

    void Start()
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);
        Debug.Log($"---Check Unlocked --- {unlocked}");

        if (lessonIndex > unlocked)
        {
            button.interactable = false;
        }
    }
}