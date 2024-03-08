using System.Collections;
using System.Collections.Generic;
using ActiveRagdoll;
using UnityEngine;

public class PersonalizationEventManager : MonoBehaviour
{
    public GameObject player;
    public GameObject[] opcionesPersonalizacion;

    [SerializeField] float DesactiveAnimationModuleConstantTime = 0.41f;

    private void Start()
    {
        Invoke("DesactiveAnimationModule", DesactiveAnimationModuleConstantTime);
    }
    public void OnSelectedCustomOption(int index)
    {
        for (int i = 0; i < opcionesPersonalizacion.Length; i++)
        {
            if(index == i)
                opcionesPersonalizacion[i].SetActive(true);
            else
                opcionesPersonalizacion[i].SetActive(false);
        }
    }

    void DesactiveAnimationModule()
    {
        player.GetComponent<AnimationModule>().enabled = false;
    }
}
