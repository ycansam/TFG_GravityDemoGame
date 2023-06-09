using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadGame()
    {
        // Aquí puedes agregar la lógica para cargar una partida guardada
        Debug.Log("Cargando partida...");
    }

    public void LoadLevel()
    {
        // Aquí puedes agregar la lógica para abrir la pantalla de selección de mapas
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
}