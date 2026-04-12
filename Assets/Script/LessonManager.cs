using UnityEngine;
using TMPro;

public class LessonManager : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text lessonText;

    [TextArea]
    public string content;

    public void OpenLesson()
    {
        panel.SetActive(true);
        lessonText.text = content;
    }

    public void CloseLesson()
    {
        panel.SetActive(false);
    }
}