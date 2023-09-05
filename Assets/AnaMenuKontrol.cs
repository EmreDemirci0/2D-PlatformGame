using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AnaMenuKontrol : MonoBehaviour
{

    public Button playButton, exitButton,levelsButton, settingsButton, level1Button, level2Button, level3Button,BackButton;
    public Button SoundText, settingsText,SaveButton;
    public Slider MenuSesSlider, OyuniciSesSlider;
    public float AnaMenuMuzikSesi=1f, OyunIciMuzikSesi = 1f;
   public AudioSource AnamenuSes;
 //  public AudioSource oyuniciSes;
    AudioListener ses;
    float a;

    
    private void Start()
    {

       


        AnamenuSes = GetComponent<AudioSource>();
        AnamenuSes.Play();
        MenuSesSlider.value = PlayerPrefs.GetFloat("AnaMenuSes");


        OyunIciMuzikSesi = PlayerPrefs.GetFloat("OyunIciSes");
    }
    
     void Update()
    {
 
        AnamenuSes.volume =  MenuSesSlider.value;
        OyunIciMuzikSesi = OyuniciSesSlider.value;

    }
    public void AyarKaydet()
    {
        PlayerPrefs.SetFloat("AnaMenuSes", MenuSesSlider.value);
        PlayerPrefs.SetFloat("OyunIciSes", OyuniciSesSlider.value);

    }

    #region PLAY
    public void Play()
    {
        exitButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        levelsButton.gameObject.SetActive(true);
        level1Button.gameObject.SetActive(true);
        level2Button.gameObject.SetActive(true);
        level3Button.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
        SaveButton.gameObject.SetActive(false);


    }
    public void level1()
    {
        SceneManager.LoadScene("level1");
    }
    public void level2()
    {

    }
    public void level3()
    {

    }
    #endregion

    public void Exit()
    {
        Application.Quit();
    }
    public void Back()
    {
        exitButton.gameObject.SetActive(true);
        settingsButton.gameObject.SetActive(true);
        playButton.gameObject.SetActive(true);
        MenuSesSlider.gameObject.SetActive(false);
        OyuniciSesSlider.gameObject.SetActive(false);
        settingsText.gameObject.SetActive(false);
        SoundText.gameObject.SetActive(false);
        levelsButton.gameObject.SetActive(false);
        level1Button.gameObject.SetActive(false);
        level2Button.gameObject.SetActive(false);
        level3Button.gameObject.SetActive(false);
    }
    public void Settings()
    {
        exitButton.gameObject.SetActive(false);
        settingsButton.gameObject.SetActive(false);
        playButton.gameObject.SetActive(false);
        
        MenuSesSlider.gameObject.SetActive(true);
        OyuniciSesSlider.gameObject.SetActive(true);
        settingsText.gameObject.SetActive(true);
        SoundText.gameObject.SetActive(true);
        BackButton.gameObject.SetActive(true);
        AnamenuSes.volume = MenuSesSlider.value;
        SaveButton.gameObject.SetActive(true);
      //  oyuniciSes.volume = OyuniciSesSlider.value;

    }
    //public void Ses(float Ses)
    //{
    //    MuzikSesi = Ses;
    //}
}
