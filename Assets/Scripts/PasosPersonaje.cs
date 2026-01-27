//Script para generar sonido cuando el personaje se mueve
using UnityEngine;

public class PasosPersonaje : MonoBehaviour
{
    public AudioSource pasosArena;
    public AudioClip[] pasos;
    public float intervaloPasos = 0.5f;

    private float pasosTiempo = 0f;
    private CharacterController controlador;

    private void Start()
    {
        controlador = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controlador.velocity.magnitude > 0.2f && controlador.isGrounded)
        {
            pasosTiempo -= Time.deltaTime;

            if (pasosTiempo <= 0)
            {
                pasosArena.PlayOneShot(pasos[Random.Range(0, pasos.Length)]);
                pasosTiempo = intervaloPasos;
            }
        }
        else
        {
            pasosTiempo = 0f;
        }
    }
}
