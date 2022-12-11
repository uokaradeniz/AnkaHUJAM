using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasControl : MonoBehaviour
{

    public GameObject mainCanvas;
    public GameObject deathCanvas;

    GameObject player;
    float oxygenValue;

    private GameHandler gameHandler;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameHandler = GameObject.Find("Game Handler").GetComponent<GameHandler>();
    }


    void Update()
    {
        oxygenValue = player.GetComponent<PlayerController>().oxygenLevel;
        if (oxygenValue < 0 && !gameHandler.gameFinished)
        {
            mainCanvas.SetActive(false);
            deathCanvas.SetActive(true);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (gameHandler.gameFinished)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
