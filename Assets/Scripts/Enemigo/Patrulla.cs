using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    public Transform[] puntosPatrulla;
    private NavMeshAgent agente;
    private int puntoActual = 0;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = puntosPatrulla[puntoActual].position;
    }

    
    void Update()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.5f) 
        {
            puntoActual = (puntoActual + 1) % puntosPatrulla.Length;
            agente.destination = puntosPatrulla[puntoActual].position;
        }
    }
}
