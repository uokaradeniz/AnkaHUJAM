using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BeforeMenuScript : MonoBehaviour
{
    public GameObject BeforeMenuCanvas;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            BeforeMenuCanvas.SetActive(false);

        }
        
    }
}
