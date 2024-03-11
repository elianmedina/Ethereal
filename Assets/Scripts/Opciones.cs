using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opciones : MonoBehaviour
{
    public GameObject[] paneles;
    public void InteractuarEntreCanvas(int _int) // Va el index del la lista de paneles +1 para que lo identifique
    {
        if(_int == 0) // en _int cuando se pone 0 quiere decir que cierra todos lo paneles
        {
            for (int i = 0; i < paneles.Length; i++)
            {
                if(i == 3) // Activa el botón de Opciones
                {
                    paneles[i].gameObject.SetActive(true);
                }
                else
                {
                    paneles[i].gameObject.SetActive(false);
                }
              
            }
        }
        else //Cuando se pone 1 o más activa dicho panel ubicado en arreglo
        {
            for (int i = 0; i < paneles.Length; i++)
            {
                if (i == _int-1)
                {
                    paneles[i].gameObject.SetActive(true);
                }
                else
                {
                    paneles[i].gameObject.SetActive(false);
                }
            }
        }    
    }

}