using System.Collections;
using UnityEngine;

public class Jefe : Enemigo
{
    private float vidaMaxima;
    private Patrulla patrulla;
    private Animator animator;
    private bool recuperandose;

    private void Awake()
    {
        vidaMaxima = vida;
        patrulla = GetComponent<Patrulla>();
        animator = GetComponentInChildren<Animator>();
    }

    public override void RecibirDano(float dano)
    {
        if (recuperandose) { return; }

        vida -= dano;
        Debug.Log("Enemigo ha recibido " + dano + " de Dano. Le queda " + vida + " de vida.");
        if (vida <= 0)
        {
            recuperandose = true;
            vida = vidaMaxima;
            StartCoroutine(Recuperarse());
        }
    }

    private IEnumerator Recuperarse()
    {
        patrulla.enabled = false;
        animator.enabled = false;
        float tiempo = 10;
        float tiempoTranscurrido = 0;
        while (tiempoTranscurrido < tiempo)
        {
            tiempoTranscurrido += Time.deltaTime;
            yield return null;
        }
        patrulla.enabled = true;
        animator.enabled = true;
        recuperandose = false;
    }
}
