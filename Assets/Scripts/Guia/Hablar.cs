using UnityEngine;

public class Hablar : MonoBehaviour
{
    public Opciones Opciones;

    void Update()
    {
        // Si se presiona la tecla de espacio
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Mostrar el canvas legal
            Opciones.InteractuarEntreCanvas(2);
        }
    }

}
