using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EventManager : MonoBehaviour
{
    public static event Action<string> OnSceneChangeRequested;

    public static void RequestSceneChange(string sceneName)
    {
        OnSceneChangeRequested?.Invoke(sceneName);
    }

    public static event Action OnQuitRequested;

    public static void RequestQuit()
    {
        OnQuitRequested?.Invoke();
    }
}

public class CambioDeScena : MonoBehaviour
{
    private void Start()
    {
        EventManager.OnSceneChangeRequested += CambiarEscena;
        EventManager.OnQuitRequested += Salir;
    }

    private void OnDestroy()
    {
        EventManager.OnSceneChangeRequested -= CambiarEscena;
        EventManager.OnQuitRequested -= Salir;
    }

    public void Bienvenida()
    {
        EventManager.RequestSceneChange("Bienvenida");
    }

    public void IrNivel2()
    {
        EventManager.RequestSceneChange("Nivel#2");
    }

    public void IrNivel3()
    {
        EventManager.RequestSceneChange("Nivel#3");
    }

    public void Salir()
    {
        EventManager.RequestQuit();
    }

    private void CambiarEscena(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
