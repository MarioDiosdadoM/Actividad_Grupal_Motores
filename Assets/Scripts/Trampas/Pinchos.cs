using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contacto con pinchos");
        if (other.CompareTag("Jugador"))
        {
            if (other.TryGetComponent<SistemaVida>(out var reaparicion))
            {
                reaparicion.GetHit(100);
            }
            if (other.gameObject.TryGetComponent<SistemaPuntuacion>(out var sistemaPuntos))
            {
                sistemaPuntos.QuitarPuntos(100);
            }
        }
    }
}