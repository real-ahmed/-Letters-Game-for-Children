using UnityEngine;

public static class SaveLoadManager
{
    private const string ProgressKey = "GameProgress";

    public static int LoadProgress()
    {

        if (PlayerPrefs.HasKey(ProgressKey))
        {
            return PlayerPrefs.GetInt(ProgressKey);
        }
        else
        {
            return 0;
        }
    }

    public static void SaveProgress(int progress)
    {
        PlayerPrefs.SetInt(ProgressKey, progress);
        PlayerPrefs.Save();
    }

}
