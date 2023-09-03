using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPlaying : MonoBehaviour
{
    [SerializeField]
    Transform menu;
    Transform player;

    [SerializeField]
    private LoadingScreen loadingScreen;

    private bool isPaused = false;
    private void Awake()
    {
        if (menu.gameObject.activeSelf)
        {
            menu.gameObject.SetActive(false);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.PLAYER).transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                if (menu.gameObject.activeSelf)
                {
                    menu.gameObject.SetActive(false);
                }
                ResumeGame();
            }
            else
            {
                if (!menu.gameObject.activeSelf)
                {
                    menu.gameObject.SetActive(true);
                }
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Pause the game by setting time scale to 0
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    void ResumeGame()
    {
        Time.timeScale = 1f; // Resume the game by setting time scale to 1
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ResetLevel()
    {
        Debug.Log("a");
        ResumeGame();
        Destroy(player.gameObject);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void MainMenu()
    {
        ResumeGame();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Destroy(player.gameObject);
        loadingScreen.LoadScreen("Menu");
    }
}
