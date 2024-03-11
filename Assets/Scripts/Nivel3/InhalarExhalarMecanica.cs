using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InhalarExhalarMecanica : MonoBehaviour
{
    public GameObject presionarTextGO;
    public Slider sliderTiempo;
    public Slider sliderTiempoParaPerder;

    [SerializeField]float timePressedInhalar, timePressedAguantar, timePressedExhalar;
    [SerializeField]float timerParaPerderAguantar = 2f, timerParaPerderExhalar = 2f;

    bool debeAguantarAire, debeExhalarAire;

    [SerializeField] bool retoCompletado;
    private void Update()
    {
        if (!retoCompletado)
        {
            if (!debeAguantarAire)
            {
                if (!debeExhalarAire)
                {
                    sliderTiempo.value = timePressedInhalar;
                    sliderTiempo.minValue = 0f;
                    sliderTiempo.maxValue = 6f;

                    sliderTiempoParaPerder.gameObject.SetActive(false);

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
                    sliderTiempo.value = timePressedExhalar;
                    sliderTiempo.minValue = 0f;
                    sliderTiempo.maxValue = 6f;

                    sliderTiempoParaPerder.gameObject.SetActive(true);
                    sliderTiempoParaPerder.value = timerParaPerderExhalar;
                    sliderTiempoParaPerder.minValue = 0f;
                    sliderTiempoParaPerder.maxValue = 2f;

                    presionarTextGO.GetComponent<TMP_Text>().text = "Mantén presionado F para exhalar";
                    if (Input.GetKey(KeyCode.F))
                    {

                        presionarTextGO.GetComponent<Animator>().SetBool("presionando", true);
                        timePressedExhalar += Time.deltaTime;
                        if (timePressedExhalar > 6)
                        {
                            timePressedExhalar = 6f;
                            retoCompletado = true;
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
                        if (timePressedExhalar == 0f)
                        {
                            timerParaPerderExhalar -= Time.deltaTime;

                            if (timerParaPerderExhalar <= 0)
                            {
                                debeAguantarAire = false;
                                debeExhalarAire = false;

                                timerParaPerderExhalar = 2f; //Se reinicia el Timer 
                                timerParaPerderAguantar = 2f; //Se reinicia el Timer

                                timePressedInhalar = 0f;
                                timePressedAguantar = 0f;
                            }
                        }
                    }
                }
            }
            else
            {
                sliderTiempo.value = timePressedAguantar;
                sliderTiempo.minValue = 0f;
                sliderTiempo.maxValue = 3f;

                sliderTiempoParaPerder.gameObject.SetActive(true);
                sliderTiempoParaPerder.value = timerParaPerderAguantar;
                sliderTiempoParaPerder.minValue = 0f;
                sliderTiempoParaPerder.maxValue = 2f;

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
                    if (timePressedAguantar == 0f)
                    {
                        timerParaPerderAguantar -= Time.deltaTime;

                        if (timerParaPerderAguantar <= 0)
                        {
                            debeAguantarAire = false;
                            debeExhalarAire = false;

                            timerParaPerderExhalar = 2f; //Se reinicia el Timer 
                            timerParaPerderAguantar = 2f; //Se reinicia el Timer

                            timePressedInhalar = 0f;
                            timePressedAguantar = 0f;
                        }
                    }
                }
            }
        }
        else
        {
            //RETO COMPLETADO
           if(presionarTextGO != null)
            {
                presionarTextGO.SetActive(false);
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
