using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogos : MonoBehaviour
{
    public TextMeshProUGUI dialogoText;
    public string[] lines;
    public float textSpeed = 0.1f;
    private int index;
    private bool escribiendo = false; // Variable para controlar si el di�logo se est� escribiendo

    public GameObject panelDespuesDelTexto; // Referencia al panel que se mostrar� despu�s de la �ltima l�nea de texto
    public GameObject panelCierraDespuesDelTexto;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Si se presiona clic derecho
        {
            NextLine(); // Avanzar al siguiente di�logo
        }
    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteLine());
    }

    IEnumerator WriteLine()
    {
        escribiendo = true; // Establecer que se est� escribiendo
        foreach (char letter in lines[index].ToCharArray())
        {
            dialogoText.text += letter;
            yield return new WaitForSeconds(textSpeed);
        }
        escribiendo = false; // Establecer que ha terminado de escribirse

        if (index == lines.Length - 1)
        {
            MostrarPanelDespuesDelTexto(); // Mostrar el panel despu�s de la �ltima l�nea de texto
        }
    }

    public void NextLine()
    {
        if (!escribiendo) // Verificar si no se est� escribiendo actualmente
        {
            if (index < lines.Length - 1)
            {
                index++;
                dialogoText.text = string.Empty;
                StartCoroutine(WriteLine());
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Panel"))
        {
            StartDialogue();
        }
    }

    private void MostrarPanelDespuesDelTexto()
    {
        if (panelDespuesDelTexto != null)
        {
            panelDespuesDelTexto.SetActive(true); // Activar el panel despu�s de la �ltima l�nea de texto
            panelCierraDespuesDelTexto.SetActive(false);
        }
    }
}