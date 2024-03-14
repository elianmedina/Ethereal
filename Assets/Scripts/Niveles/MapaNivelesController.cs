using System.Collections;
using System.Collections.Generic;
using System.Threading;
using ActiveRagdoll;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapaNivelesController : MonoBehaviour
{
    [SerializeField] bool estaEnNivel1, estaEnNivel2, estaEnNivel3, estaEnAlgunPanel;

    public GameObject[] panelitosNiveles;
    public GameObject[] panelesPropiosNiveles;

    public GameObject[] botonesJugarNivel2y3;

    public Transform[] nivelesTransform;
    public LayerMask layerMask;
    public GameObject jugadorPrefab;
    void Start()
    {
        verificarNivelActualJugador();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            AbrirPanelNivel();
        }
        else if(!estaEnAlgunPanel)
        {
            HoverNivel();
        }
    }

    public void AbrirPanelNivel()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
        {
            GameObject obj = hit.collider.gameObject;
            estaEnAlgunPanel = true;
            if (obj.name.Equals("Nivel1"))
            {
                for(int i = 0; i < panelesPropiosNiveles.Length; i++)
                {
                    if (i == 0)
                    {
                        panelesPropiosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelesPropiosNiveles[i].SetActive(false);
                    }
                }
            }
            if (obj.name.Equals("Nivel2"))
            {
                for (int i = 0; i < panelesPropiosNiveles.Length; i++)
                {
                    if (i == 1)
                    {
                        panelesPropiosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelesPropiosNiveles[i].SetActive(false);
                    }
                }
                if (estaEnNivel2 || estaEnNivel3)
                {
                    botonesJugarNivel2y3[0].transform.GetChild(1).gameObject.SetActive(false);
                    botonesJugarNivel2y3[0].GetComponent<Button>().interactable = true;
                }
                else
                {
                    botonesJugarNivel2y3[0].transform.GetChild(1).gameObject.SetActive(true);
                    botonesJugarNivel2y3[0].GetComponent<Button>().interactable = false;
                }
            }
            if (obj.name.Equals("Nivel3"))
            {
                for (int i = 0; i < panelesPropiosNiveles.Length; i++)
                {
                    if (i == 2)
                    {
                        panelesPropiosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelesPropiosNiveles[i].SetActive(false);
                    }
                }
                if (estaEnNivel3)
                {
                    botonesJugarNivel2y3[1].transform.GetChild(1).gameObject.SetActive(false);
                    botonesJugarNivel2y3[1].GetComponent<Button>().interactable = true;
                }
                else
                {
                    botonesJugarNivel2y3[1].transform.GetChild(1).gameObject.SetActive(true);
                    botonesJugarNivel2y3[1].GetComponent<Button>().interactable = false;
                }
            }
        }
    }

    public void HoverNivel()
    {
        RaycastHit hoverHit;
        Ray hoverRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(hoverRay, out hoverHit, Mathf.Infinity, layerMask))
        {
            GameObject hoveredObj = hoverHit.collider.gameObject;
            if (hoveredObj.name.Equals("Nivel1"))
            {
                for (int i = 0; i < panelitosNiveles.Length; i++)
                {
                    if (i == 0)
                    {
                        panelitosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelitosNiveles[i].SetActive(false);
                    }
                }
            }
            if (hoveredObj.name.Equals("Nivel2"))
            {
                for (int i = 0; i < panelitosNiveles.Length; i++)
                {
                    if (i == 1)
                    {
                        panelitosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelitosNiveles[i].SetActive(false);
                    }
                }
            }
            if (hoveredObj.name.Equals("Nivel3"))
            {
                for (int i = 0; i < panelitosNiveles.Length; i++)
                {
                    if (i == 2)
                    {
                        panelitosNiveles[i].SetActive(true);
                    }
                    else
                    {
                        panelitosNiveles[i].SetActive(false);
                    }
                }
            }
        }
    }

    void verificarNivelActualJugador()
    {
        if (estaEnNivel1)
        {
            //Lo que sucede si ÚNICAMENTE tiene el bool "estaEnNivel1" true
            GameObject player = Instantiate(jugadorPrefab, nivelesTransform[0]);
            ConfiguracionInicialJugador(player);
            StartCoroutine(esperaDeMilisegundos(player));
        }
        if (estaEnNivel2)
        {
            //Lo que sucede si ÚNICAMENTE tiene el "estaEnNivel2" true 
            GameObject player = Instantiate(jugadorPrefab, nivelesTransform[1]);
            ConfiguracionInicialJugador(player);
            StartCoroutine(esperaDeMilisegundos(player));          
        }
        if (estaEnNivel3)
        {
            //Lo que sucede si ÚNICAMENTE tiene el "estaEnNivel3" true 
            GameObject player = Instantiate(jugadorPrefab, nivelesTransform[2]);
            ConfiguracionInicialJugador(player);
            StartCoroutine(esperaDeMilisegundos(player));
        }
    }

    void ConfiguracionInicialJugador(GameObject player)
    {
        // Desactiva los scripts del CLON para no generar errores y evitar el movimiento del jugador
        player.GetComponent<InputModule>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;
        player.GetComponent<CameraModule>().enabled = false;
        player.GetComponent<GripModule>().enabled = false;
        player.GetComponent<DefaultBehaviour>().enabled = false;
    }

    IEnumerator esperaDeMilisegundos(GameObject player)
    {
        // Desactiva los scripts del CLON para no generar errores en ANIMACIÓN y evitar el movimiento del jugador
        yield return new WaitForSeconds(0.41f);
        player.GetComponent<AnimationModule>().enabled = false;
    }

    public void BackButton()
    {
        for(int i = 0; i < panelesPropiosNiveles.Length; i++)
        {
            panelesPropiosNiveles[i].SetActive(false);
        }
        estaEnAlgunPanel = false;
    }
}
