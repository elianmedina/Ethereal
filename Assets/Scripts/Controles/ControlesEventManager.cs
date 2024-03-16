using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlesEventManager : MonoBehaviour
{
    public GameObject slider;
    public GameObject cortinaFinal;

    [SerializeField] float tiempoPresionado, tiempoMaximoPresionado, tiempoMinimoPresionado;

    bool salio;
    private void Start()
    {
        slider.GetComponent<Slider>().minValue = tiempoMinimoPresionado;
        slider.GetComponent<Slider>().maxValue = tiempoMaximoPresionado;
    }
    private void Update()
    {
        slider.GetComponent<Slider>().value = tiempoPresionado;

        if (Input.GetKey(KeyCode.Escape))
        {
            if (!slider.activeSelf) 
               slider.SetActive(true);

            tiempoPresionado += Time.deltaTime;
            if(tiempoPresionado > tiempoMaximoPresionado)
            {
                tiempoPresionado = tiempoMaximoPresionado;
                salio = true;
                VolverAlMenuPrincipal();
            }
        }
        else
        {
            tiempoPresionado -= Time.deltaTime;
            if (tiempoPresionado < tiempoMinimoPresionado)
            {
                tiempoPresionado = tiempoMinimoPresionado;
                slider.SetActive(false);                
            }
        }

        if (salio)
            tiempoPresionado = tiempoMaximoPresionado;
    }

    void VolverAlMenuPrincipal()
    {
        Cursor.lockState = CursorLockMode.Locked;
        cortinaFinal.GetComponent<Animator>().SetBool("termino", true);
    }
}
