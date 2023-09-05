using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private LoadingScreen loadingScreen;
    [SerializeField]
    private GameObject levels;
    private void Start()
    {
        levels.SetActive(false);
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void NewGame()
    {
        loadingScreen.LoadScreen("Level1");
        PlayerSuit.SetPlayerSuitOff();
        PlayerPhone.SetPlayerPhoneOff();
    }

    public void LoadLevel()
    {
        if (levels.activeSelf)
        {
            levels.SetActive(false);
        }
        else
        {
            levels.SetActive(true);
        }
        Debug.Log("Abriendo mapas...");
    }

    public void OpenOptions()
    {
        // Aquí puedes agregar la lógica para abrir la pantalla de opciones
        Debug.Log("Abriendo opciones...");
    }

    public void Exit()
    {
        // Aquí puedes agregar la lógica para salir del juego
        Debug.Log("Saliendo del juego...");
        Application.Quit();
    }
    public void LoadLevel1()
    {
        loadingScreen.LoadScreen("Level1");
        PlayerSuit.SetPlayerSuitOff();
        PlayerPhone.SetPlayerPhoneOff();
    }
    public void LoadLevel2()
    {
        loadingScreen.LoadScreen("Level2");
        PlayerSuit.SetPlayerSuitOff();
        PlayerPhone.SetPlayerPhoneOff();
    }
    public void LoadLevel3()
    {
        loadingScreen.LoadScreen("Level3");
        PlayerSuit.SetPlayerSuitOff();
        PlayerPhone.SetPlayerPhoneOff();
    }
    public void LoadLevel4()
    {
        loadingScreen.LoadScreen("Level4");
        PlayerSuit.SetPlayerSuitOff();
        PlayerPhone.SetPlayerPhoneOff();
    }
}