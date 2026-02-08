using UnityEngine;

public class ActivarPinchos : MonoBehaviour
{
    public PlataformaPinchos trampa;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            trampa.Activar();
        }
    }
}