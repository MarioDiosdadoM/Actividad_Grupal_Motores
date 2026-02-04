using UnityEngine;

public class Pinchos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Contacto con pinchos");

        if (other.CompareTag("Jugador"))
        {
            Respawn reaparicion = other.GetComponent<Respawn>();

            if (reaparicion != null)
            {
                reaparicion.Morir();
            }
        }
    }
}
