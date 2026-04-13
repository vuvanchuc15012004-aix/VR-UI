using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public static void UnlockNext(int currentLevel)
    {
        int unlocked = PlayerPrefs.GetInt("UnlockedLevel", 1);

        if (currentLevel >= unlocked)
        {
            unlocked = currentLevel + 1;
            PlayerPrefs.SetInt("UnlockedLevel", unlocked);

            Debug.Log("Mở khóa đến bài: " + unlocked);
        }
    }
}