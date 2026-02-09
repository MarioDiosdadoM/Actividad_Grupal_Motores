using UnityEngine;

public class ManagerEstatuas : MonoBehaviour
{

    public int totalEstatuas = 3;
    private int estatuasActivadas = 0;

    [Header("Spawn del boss")]
    public GameObject bossPrefab;
    public Transform puntoAparicion;

    private bool bossSpawned = false;

    public void EstatuaActivada()
    {
        estatuasActivadas++;

        if (estatuasActivadas >= totalEstatuas && !bossSpawned) { SpawnearBoss(); }
    }

    void SpawnearBoss()
    {
        bossSpawned = true;
        Instantiate(bossPrefab, puntoAparicion.position, puntoAparicion.rotation);
    }
    
}
