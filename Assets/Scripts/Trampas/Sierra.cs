using UnityEngine;

public class Sierra : MonoBehaviour, Interfaztrampas
{
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;
    public float velRotacion = 3f;
    private Vector3 objetivoActual;
    private bool activa = true;
    void Awake()
    {
        objetivoActual = puntoB.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!activa) return;       
        transform.Rotate(Vector3.up * 360f * velRotacion * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, objetivoActual, velocidad * Time.deltaTime);
        if (Vector3.Distance(transform.position, objetivoActual) < 0.05f)
        {
            objetivoActual = objetivoActual == puntoA.position ? puntoB.position : puntoA.position;
        }
    }

    public void Desactivar()
    {
        activa = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))
        {
            Debug.Log("Contacto con sierra");
            if (other.TryGetComponent<SistemaVida>(out var reaparicion))
            {
                reaparicion.GetHit(5);
            }
            if (other.gameObject.TryGetComponent<SistemaPuntuacion>(out var sistemaPuntos))
            {
                sistemaPuntos.QuitarPuntos(10);
            }
        }
    }
}