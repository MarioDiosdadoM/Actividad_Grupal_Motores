using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;

public class PatrullaPorZonas : MonoBehaviour
{
    public Transform centroZona;
    public float radioPatrulla = 20f;
    public float tiempoEspera = 0.5f;

    private NavMeshAgent agente;
    private float espera;
    private bool esperando;

    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        IrAPuntoAleatorio();
    }

    
    void Update()
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
            if(espera <= 0f)
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
