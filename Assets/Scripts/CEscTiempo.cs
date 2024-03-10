using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CEscTiempo : MonoBehaviour
{
    void Start()
    {
        Invoke("CargarSiguienteEscena", 25f); // Llama a la funci�n CargarSiguienteEscena despu�s de 30 segundos
    }
    void CargarSiguienteEscena()
    {
        // Obt�n el �ndice de la siguiente escena en la build
        int siguienteEscenaIndex = SceneManager.GetActiveScene().buildIndex + 2;

        // Verifica si la siguiente escena existe en la build
        if (siguienteEscenaIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(siguienteEscenaIndex); // Carga la siguiente escena
        }
        else
        {
            Debug.Log("No hay m�s escenas en la build."); // Si no hay m�s escenas, muestra un mensaje de error
        }
    }
}
