using Mono.Cecil;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaPorZonas : MonoBehaviour
{
    public Transform centroZona;
    public float radioPatrulla = 20f;
    public float tiempoEspera = 0.5f;

    public float radioVision = 8f;
    public LayerMask layerJugador;

    public float radioPerdida = 20f;

    private NavMeshAgent agente;
    private float espera;
    private bool esperando;

    private Transform target;
    private bool persiguiendo = false;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        IrAPuntoAleatorio();
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
            esperando = false;
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
        IrAPuntoAleatorio();
    }

    void Patrullar()
    {
        if (!agente.pathPending && agente.remainingDistance < 0.5f)
        {
            if (!esperando)
            {
                esperando = true;
                espera = tiempoEspera;
            }
        }

        if (esperando)
        {
            espera -= Time.deltaTime;
            if (espera <= 0f)
            {
                esperando = false;
                IrAPuntoAleatorio();
            }
        }
    }

    void IrAPuntoAleatorio()
    {
        Vector3 direccion = Random.insideUnitSphere * radioPatrulla;
        direccion += centroZona.position;

        NavMeshHit hit;
        if (NavMesh.SamplePosition(direccion, out hit, radioPatrulla, NavMesh.AllAreas))
        { agente.SetDestination(hit.position); }
    }
}
