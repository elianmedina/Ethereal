using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioDeScena : MonoBehaviour
{
    public void Bienvenida()
    {
        SceneManager.LoadScene("Bienvenida");
    }

    public void Continuar()
    {
        SceneManager.LoadScene("Bosque");
    }

    public void Personalizacion()
    {
        SceneManager.LoadScene("Personalización");
    }

    public void Instrucciones()
    {
        SceneManager.LoadScene("Instrucciones");
    }

    public void Bosque()
    {
        SceneManager.LoadScene("Bosque");
    }


    public void Nivel1()
    {
        SceneManager.LoadScene("Nivel1");
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Inicio");
    }


    public void Niveles()
    {
        SceneManager.LoadScene("Niveles");
    }

    public void Configuracion()
    {
        SceneManager.LoadScene("Configuracion");
    }

    public void Salir()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}
