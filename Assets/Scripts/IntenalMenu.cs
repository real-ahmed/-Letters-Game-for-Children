using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InternalMenu : MonoBehaviour
{
    [SerializeField] GameObject internalMenu;
    [SerializeField] TextMeshProUGUI internalMenuTitle;
    [SerializeField] Button MainButton;
    [SerializeField] Sprite PauseImage;
    [SerializeField] Sprite NextImage;




    public void Pause()
    {
        internalMenuTitle.text = "Pause";
        MainButton.onClick.RemoveAllListeners();
        MainButton.onClick.AddListener(() => Play());
        Helpers.ChangeBtnBackground(MainButton, PauseImage);

        internalMenu.SetActive(true);
        

    }

    public void Win()
    {
        internalMenuTitle.text = "Win";
        MainButton.onClick.RemoveAllListeners();
        MainButton.onClick.AddListener(() => Next());
        Helpers.ChangeBtnBackground(MainButton, NextImage);
     
        AudioManager.instance.PlaySFX("Win");
     
        internalMenu.SetActive(true);

    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }

    public void Restart()
    {
        LevelManager.LoadLevelScene(LevelManager.SelectedLetter);


    }


    public void Play()
    {
        internalMenu.SetActive(false);
    }

    public static void Next()
    {
        LevelManager.LoadLevelScene(++(LevelManager.SelectedLetter));
    }
}
