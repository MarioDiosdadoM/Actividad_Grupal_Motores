using UnityEngine;

public class Puertas : MonoBehaviour
{
    public Transform posAbierta;
    public float velocidad = 2f;

    private Vector3 posCerrada;
    private bool abierta = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        posCerrada = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 objetivo = abierta ? posAbierta.position : posCerrada;
        transform.position = Vector3.Lerp(transform.position, objetivo, Time.deltaTime * velocidad);
    }

    public void Abrir()
    {
        abierta = true;
    }

    public void Cerrar()
    {
        abierta = false;
    }

    public bool EstaAbierta()
    {
        return abierta;
    }
}
