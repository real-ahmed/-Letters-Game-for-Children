using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class LevelManager : MonoBehaviour
{
    public GameObject buttonPrefab;
    public Transform panel;
    public static char SelectedLetter;
    private static int currentProgress;
    public static Object LevelQuestion;
    public Sprite LockedLevel;

    void Start()
    {
        currentProgress = SaveLoadManager.LoadProgress();

        GenerateLevelButtons();
    }

    public void BackHome()
    {
        SceneManager.LoadScene(0);
    }

    void GenerateLevelButtons()
    {
        for (char c = 'a'; c <= 'z'; c++)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, panel);
            buttonObj.name = "Button_" + c;


            bool isLocked = c - 'a' > currentProgress;
            if (isLocked)
                Helpers.ChangeBtnBackground(buttonObj.GetComponent<Button>(), LockedLevel);
            buttonObj.GetComponent<Button>().interactable = !isLocked;

            buttonObj.SetActive(true);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = isLocked ? "" : c.ToString().ToUpper() + c;

            char localCopyOfC = c;

            Button btn = buttonObj.GetComponent<Button>();
            btn.onClick.AddListener(() => LoadLevelScene(localCopyOfC));
        }
    }

    public static void LoadLevelScene(char levelChar)
    {
        if (LevelQuestion)
            Destroy(LevelQuestion);

        SelectedLetter = levelChar;
        string folderPath = "Assets/Scenes/Questions/";
        string[] levelFiles = Directory.GetFiles(folderPath,"*.unity");
        Debug.Log(levelFiles.Length);
        int questionSceneName = Random.Range(1, levelFiles.Length);
        Debug.Log(questionSceneName);
        SceneManager.LoadScene($"Scenes/Questions/{questionSceneName}");
    }
}
