using UnityEngine;

public class PuertaPista : MonoBehaviour, Interactuable
{
    [TextArea]
    public string textoPista;
    public void Interactuar()
    {
        Debug.Log("Pista mostrada");
    }

    public string textoInteraccion()
    {
        return textoPista;
    }
}