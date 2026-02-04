using UnityEngine;

public class PlataformaPinchos : MonoBehaviour, Interfaztrampas
{
    [Header("Bajada")]
    public float distancia = 3f;
    public float velBajada = 1f;
    public float velSubida = 3f;
    public float velDesactivacion = 1f;

    private Vector3 posInicial;
    private Vector3 posFinal;
    private bool bajando = false;
    private bool subiendo = false;

    private bool desactivar = false;

    void Start()
    {
        posInicial = transform.position;
        posFinal = posInicial + Vector3.down * distancia;
    }

    // Update is called once per frame
    void Update()
    {
        if (desactivar) return;

        if (bajando)
        {
            transform.position = Vector3.MoveTowards(transform.position, posFinal, velBajada * Time.deltaTime);

            if (Vector3.Distance(transform.position, posFinal) < 0.01f)
            {
                bajando = false;
                subiendo = true;
            }
            
        }

        if (subiendo)
        {
            transform.position = Vector3.MoveTowards(transform.position, posInicial, velSubida * Time.deltaTime);

            if (Vector3.Distance(transform.position, posInicial) < 0.01f) {
                subiendo = false;
            }
        }
    }

    public void Activar()
    {
        if (!bajando && !subiendo) bajando = true;
    }


    public void Resetear()
    {
        bajando = false;
        subiendo = false;
        transform.position = posInicial;
    }

    public void Desactivar()
    {
        desactivar = true;
        PararTrampa();
    }

    void PararTrampa()
    {
        transform.position = Vector3.MoveTowards(transform.position, posInicial, velDesactivacion * Time.deltaTime);
    }

    private void OnEnable()
    {
        Respawn.reseteoPinchos += Resetear;
    }

    private void OnDisable()
    {
        Respawn.reseteoPinchos -= Resetear;
    }

}
