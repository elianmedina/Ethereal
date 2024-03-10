using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEscTiempo : MonoBehaviour
{
    void Start()
    {
        Invoke("CargarSiguienteEscena", 25f); // Llama a la función CargarSiguienteEscena después de 30 segundos
    }
    void CargarSiguienteEscena()
    {
        // Obtén el índice de la siguiente escena en la build
        int siguienteEscenaIndex = SceneManager.GetActiveScene().buildIndex + 2;

        // Verifica si la siguiente escena existe en la build
        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscenaIndex); // Carga la siguiente escena
        }
        else
        {
            Debug.Log("No hay más escenas en la build."); // Si no hay más escenas, muestra un mensaje de error
        }
    }
}
