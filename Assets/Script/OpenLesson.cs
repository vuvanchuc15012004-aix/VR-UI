using UnityEngine;

public class ClickTube : MonoBehaviour
{
    public LessonManager lessonManager;

    void OnMouseDown()
    {
        lessonManager.OpenLesson();
    }
}