using UnityEngine;
using TMPro;
using System.Collections;

public class Estatuas : MonoBehaviour, Interactuable
{
    [Header("Puertas que controla")]
    public Puertas[] puertas;
    [Header("Texto")]
    [TextArea] public string textoPre = "¿Quieres abrir el paso?";
    [TextArea] public string textoAct = "La puerta esta abierta";
    [Header("Feedback")]
    public TextMeshProUGUI textoPista;
    public float temporizador = 3f;
    public MonoBehaviour[] trampa;
    private bool activada = false;
    private GameObject puntos;
    private ManagerEstatuas manager;
    
    void Start()
    {
        manager = FindFirstObjectByType<ManagerEstatuas>();
    }
    public void Interactuar()
    {
        if (activada) return;
        activada = true;
        manager.EstatuaActivada();
        foreach (MonoBehaviour t in trampa)
        {
            Interfaztrampas trampa = t as Interfaztrampas;
            if (t != null) trampa.Desactivar();
        }

        foreach (Puertas puerta in puertas)
        {
            puerta.Abrir();
        }

        if (textoPista != null)
        {
            StartCoroutine(MostrarAviso("Algo retumba a lo lejos...", temporizador));
        }
        puntos = GameObject.FindWithTag("Jugador");
        puntos.GetComponent<SistemaPuntuacion>().Puntuar(50);
    }

    public string textoInteraccion()
    {
        return activada ? textoAct : textoPre;
    }

    private IEnumerator MostrarAviso(string mensaje, float duracion)
    {
        textoPista.text = mensaje;
        textoPista.gameObject.SetActive(true);   
        yield return new WaitForSeconds(duracion);
        textoPista.gameObject.SetActive(false);      
    }
}