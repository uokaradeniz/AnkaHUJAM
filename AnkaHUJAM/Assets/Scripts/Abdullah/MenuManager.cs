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
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);

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

    //Ses aç kapa fonksiyonlarý
    public void OpenSound() { AudioListener.volume = 1; }

    public void CloseSound() { AudioListener.volume = 0; }

    //Grafik ayalarý için fonksiyonlar 

    public void SetQualityLow(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex = 1);

    }
    public void SetQualityMedium(int qualityÝndex)
    {
        QualitySettings.SetQualityLevel(qualityÝndex = 3);

    }
    public void SetQualityHigh(int qualityÝndex)
    {
        QualitySettings.SetQualityLevel(qualityÝndex = 5);

    }



}
