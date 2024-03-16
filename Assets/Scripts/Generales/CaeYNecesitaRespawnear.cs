using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaeYNecesitaRespawnear : MonoBehaviour
{
    public Transform respawnPlayer;
    public GameObject playerPrefab;

    public GameObject actualPlayer;
    [SerializeField] float TiempoSpawnPlayer;

    public GameObject PantallaRespawn;

    private void Awake()
    {
        actualPlayer = Instantiate(playerPrefab, respawnPlayer);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name.Equals("Head"))
        {
            Destroy(actualPlayer);
            StartCoroutine(EsperarUnMomentoYSpawneaPlayer());
        }
    }

    IEnumerator EsperarUnMomentoYSpawneaPlayer()
    {
        PantallaRespawn.SetActive(true);
        yield return new WaitForSeconds(TiempoSpawnPlayer);
        actualPlayer = Instantiate(playerPrefab, respawnPlayer);
        PantallaRespawn.SetActive(false);
    }
}
