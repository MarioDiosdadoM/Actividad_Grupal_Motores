using UnityEngine;
using System.Collections;

public class LanzaLlamas : MonoBehaviour, Interfaztrampas
{
    private ParticleSystem llamas;
    private Collider peligro;
    public float tiempoEncendido = 2f;
    public float tiempoApagado = 2f;
    private bool activa = true;

    private void Awake()
    {
        llamas = GetComponent<ParticleSystem>();
        peligro = GetComponent<Collider>();
        peligro.enabled = false;
    }
    void Start()
    {
        StartCoroutine(CicloLlamas());
    }

    private System.Collections.IEnumerator CicloLlamas()
    {
        while (activa)
        {
            Encender();
            yield return new WaitForSeconds(tiempoEncendido);

            Apagar();
            yield return new WaitForSeconds(tiempoApagado);
        }
    }

    void Encender()
    {
        llamas.Play();
        peligro.enabled = true;
    }

    void Apagar()
    {
        llamas.Stop();
        peligro.enabled = false;
    }

    public void Desactivar()
    {
        activa = false;
        llamas.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        peligro.enabled = false;
        enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contacto con lanzallamas");
        if (other.CompareTag("Jugador"))
        {
            if (other.TryGetComponent<SistemaVida>(out var reaparicion))
            {
                reaparicion.GetHit(5);
            }
        }
    }
}