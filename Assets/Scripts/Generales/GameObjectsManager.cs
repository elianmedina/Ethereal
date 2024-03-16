using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectsManager : MonoBehaviour
{
    public void ActivarObjetoHijoPorIndice(int _index)
    {
        this.gameObject.transform.GetChild(_index).gameObject.SetActive(true);
    }

    public void DesactivarObjetoHijoPorIndice(int _index)
    {
        this.gameObject.transform.GetChild(_index).gameObject.SetActive(false);
    }
}
