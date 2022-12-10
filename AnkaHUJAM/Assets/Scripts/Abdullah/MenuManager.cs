using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject MenuCanvas;
    public GameObject SettingsCanvas;

    public AudioSource audiosource;
    public AudioClip audioclip;
   
    public void StartButton()
    {
        SceneManager.LoadScene(1, LoadSceneMode.Single);

    }
    public void QuitButton()
    {
        Application.Quit();
    }
    public void GoSettings()
    {
        MenuCanvas.SetActive(false);
        SettingsCanvas.SetActive(true);
    }
    public void BackMenu()
    {
        SettingsCanvas.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    //Ses aç kapa fonksiyonları
    public void OpenSound() { AudioListener.volume = 1; }

    public void CloseSound() { AudioListener.volume = 0; }

    //Grafik ayaları için fonksiyonlar 

    public void SetQualityLow(int qualityİndex)
    {
        QualitySettings.SetQualityLevel(qualityİndex = 1);

    }
    public void SetQualityMedium(int qualityİndex)
    {
        QualitySettings.SetQualityLevel(qualityİndex = 3);

    }
    public void SetQualityHigh(int qualityİndex)
    {
        QualitySettings.SetQualityLevel(qualityİndex = 5);

    }



}
