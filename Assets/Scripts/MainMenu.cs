using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button MuteMusicbuttonOne, MuteMusicbuttonTwo;
    public Slider _MusicSilder, _SFXSilder;

    private float originalMusicVolume;
    private float originalSfxVolume;

    void Start()
    {
       

        originalMusicVolume = 0.05f; 
        originalSfxVolume = 1f;


        _MusicSilder.value = originalMusicVolume;
        _SFXSilder.value = originalSfxVolume;
        MusicVolume();
        SFXVolume();



    }

    void Awake()
    {

    }

    public void SaveSettings()
    {

        originalMusicVolume = _MusicSilder.value;
        originalSfxVolume = _SFXSilder.value;


    }

    public void CancelSettings()
    {
        _MusicSilder.value = originalMusicVolume;
        _SFXSilder.value = originalSfxVolume;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }




    public void Quit()
    {
        Application.Quit();
    }


    public void ToggleMusic(Sprite newBackground)
    {
        AudioManager.instance.ToggleMusic();
        Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        Button otherBtn = btn == MuteMusicbuttonOne ? MuteMusicbuttonTwo : MuteMusicbuttonOne;

        Helpers.ChangeBtnBackground(btn, newBackground);
        Helpers.ChangeBtnBackground(otherBtn, newBackground);
    }

    public void ToggleSFX(Sprite newBackground)
    {
        AudioManager.instance.ToggleSFX();
        Button btn = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();

        Helpers.ChangeBtnBackground(btn, newBackground);


    }







    public void MusicVolume()
    {
        AudioManager.instance.MusicVolume(_MusicSilder.value);
    }


    public void SFXVolume()
    {
        AudioManager.instance.SfxVolume(_MusicSilder.value);
    }

}
