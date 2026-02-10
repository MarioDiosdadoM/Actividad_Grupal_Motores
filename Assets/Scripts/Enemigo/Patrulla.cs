using UnityEngine;
using UnityEngine.AI;

public class Patrulla : MonoBehaviour
{
    public Transform[] puntosPatrulla;
    public float radioVision = 8f;
    public LayerMask layerJugador;

    public float radioPerdida = 20f;

    private NavMeshAgent agente;
    private int puntoActual = 0;
    private Transform target;
    private bool persiguiendo = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        agente.destination = puntosPatrulla[puntoActual].position;
    }

    
    void Update()
    {
        if (!persiguiendo) { DetectarJugador(); }
        else { PerderJugador(); }


        if (persiguiendo) { agente.SetDestination(target.position); }
        else { Patrullar(); }
    }

    void DetectarJugador()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radioVision, layerJugador);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
            persiguiendo = true;
        }
    }

    void PerderJugador()
    {
        if (target == null)
        {
            DejarPerseguir();
            return;
        }

        float distancia = Vector3.Distance(transform.position, target.position);
        if (distancia > radioPerdida) { DejarPerseguir(); }
    }

    void DejarPerseguir()
    {
        persiguiendo = false;
        target = null;
        Patrullar();
    }

    public void EstablecerPatrulla(Transform[] puntos)
    {
        puntosPatrulla = puntos;
        puntoActual = 0;
    }

    void Patrullar()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.5f)
        {
            puntoActual = (puntoActual + 1) % puntosPatrulla.Length;
            agente.destination = puntosPatrulla[puntoActual].position;
        }
    }
}
