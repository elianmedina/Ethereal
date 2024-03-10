using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InhalarExhalarMecanica : MonoBehaviour
{
    public GameObject presionarTextGO;

    [SerializeField]float timePressedInhalar, timePressedAguantar, timePressedExhalar;

    [SerializeField]float timerParaPerderAguantar = 2f, timerParaPerderExhalar = 2f;

    bool debeAguantarAire, debeExhalarAire;
    private void Update()
    {
        if (!debeAguantarAire)
        {
            if (!debeExhalarAire)
            {
                presionarTextGO.GetComponent<TMP_Text>().text = "Mantén presionado F para inhalar";
                if (Input.GetKey(KeyCode.F))
                {

                    presionarTextGO.GetComponent<Animator>().SetBool("presionando", true);
                    timePressedInhalar += Time.deltaTime;
                    if (timePressedInhalar > 6)
                    {
                        timePressedInhalar = 6f;
                        debeAguantarAire = true;
                    }
                }
                else
                {
                    presionarTextGO.GetComponent<Animator>().SetBool("presionando", false);
                    timePressedInhalar -= Time.deltaTime;
                    if (timePressedInhalar < 0)
                    {
                        timePressedInhalar = 0f;
                    }
                }
            }
            else
            {
                presionarTextGO.GetComponent<TMP_Text>().text = "Mantén presionado F para exhalar";
                if (Input.GetKey(KeyCode.F))
                {

                    presionarTextGO.GetComponent<Animator>().SetBool("presionando", true);
                    timePressedExhalar += Time.deltaTime;
                    if (timePressedExhalar > 6)
                    {
                        timePressedExhalar = 6f;
                        Debug.Log("Completado");
                    }
                }
                else
                {
                    presionarTextGO.GetComponent<Animator>().SetBool("presionando", false);
                    timePressedExhalar -= Time.deltaTime;
                    if (timePressedExhalar < 0)
                    {
                        timePressedExhalar = 0f;
                    }
                    IniciarContadorSegundos(timerParaPerderExhalar, timePressedAguantar);
                }
            }
        }
        else
        {
            IniciarContadorSegundos(timerParaPerderAguantar, timePressedAguantar);
            presionarTextGO.GetComponent<TMP_Text>().text = "Mantén presionado G para aguantare el aire";
            if (Input.GetKey(KeyCode.G))
            {
                presionarTextGO.GetComponent<Animator>().SetBool("presionando", true);
                timePressedAguantar += Time.deltaTime;
                if (timePressedAguantar > 3)
                {
                    timePressedAguantar = 3f;
                    debeAguantarAire = false;
                    debeExhalarAire = true;
                }
            }
            else
            {
                presionarTextGO.GetComponent<Animator>().SetBool("presionando", false);
                timePressedAguantar -= Time.deltaTime;
                if (timePressedAguantar < 0)
                {
                    timePressedAguantar = 0f;
                }
            }
        }
    }

    void IniciarContadorSegundos(float timer, float suTimer)
    {
        if(suTimer == 0f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                debeAguantarAire = false;
                debeExhalarAire = false;
            }
        } 
    }
}
