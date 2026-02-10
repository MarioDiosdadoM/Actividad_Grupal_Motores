using UnityEngine;

public class ManagerEstatuas : MonoBehaviour
{

    public int totalEstatuas = 3;
    private int estatuasActivadas = 0;

    [Header("Spawn del boss")]
    public GameObject bossPrefab;
    public Transform puntoAparicion;
    public Transform[] bossPuntosPatrulla;

    private bool bossSpawned = false;

    public Avisoboss aviso;

    public void EstatuaActivada()
    {
        estatuasActivadas++;

        if (estatuasActivadas >= totalEstatuas && !bossSpawned) { SpawnearBoss(); }
    }

    void SpawnearBoss()
    {
        bossSpawned = true;
        GameObject boss = Instantiate(bossPrefab, puntoAparicion.position, puntoAparicion.rotation);

        if (aviso != null) { aviso.iniciarAviso(); }

        Patrulla patrulla = boss.GetComponent<Patrulla>();
        patrulla.EstablecerPatrulla(bossPuntosPatrulla);
    }
    
}
