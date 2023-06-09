using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{

    public void LoadScreen(string sceneToLoad)
    {
        StartCoroutine(LoadMainScene(sceneToLoad));
    }

    private System.Collections.IEnumerator LoadMainScene(string sceneToLoad)
    {
        // Carga la escena principal de manera asíncrona
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(sceneToLoad);

        // Evita que la escena se muestre mientras se está cargando
        asyncOperation.allowSceneActivation = false;

        while (!asyncOperation.isDone)
        {
            // Actualiza el progreso de carga (si se desea)
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            Debug.Log("Progress: " + progress);

            // Si la carga de la escena ha finalizado, muestra la escena
            if (asyncOperation.progress >= 0.9f)
            {
                asyncOperation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}