using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    public GameObject menuPsusa;
    public bool menuOn;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (menuOn){

                Continuar();
            }
            else{
                Pause();
            }
        }
        
    }

    public void Continuar()
    {
        menuPsusa.SetActive(false);
        Time.timeScale = 1;
        menuOn = false;
    }

   public void Pause(){
         menuPsusa.SetActive(true);  
            Time.timeScale = 0;
            menuOn = true;
}

public void Jugar() {
        SceneManager.LoadScene("Inicio");
    }
    public void Cambiar(){
            SceneManager.LoadScene("Inicio");
    }
    public void Salir(){
        SceneManager.LoadScene("Inicio");
    }
}

