using UnityEngine;

public class Dialoguito : MonoBehaviour
{
    public GameObject canvas;

    void Update()
    {
        // Si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mostrar el canvas legal
            canvas.SetActive(true);
        }
    }

    // Método para desactivar el canvas legal
    public void Ocultarcanvas()
    {
        canvas.SetActive(false);
    }
}
