using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float Velocidad = 15;
    [SerializeField] private float Dano = 5;
    [SerializeField] private float Tiempo = 5;

    private Vector3 Direccion;

    public void Inicializar(Vector3 dir)
    {
        Direccion = dir;
    }

    private void OnTriggerEnter(Collider col)
    {
        Enemigo enemigo = col.GetComponent<Enemigo>();
        if (enemigo != null)
        {
            enemigo.RecibirDano(Dano);
        }
        StopCoroutine(ContarTiempo(this));
        PoolManager.ReturnToPool(gameObject);
    }

    private void Update()
    {
        transform.position += Direccion * Velocidad * Time.deltaTime;
    }

    public IEnumerator ContarTiempo(Bala bala)
    {
        float tiempoTrancurrido = 0;
        while(tiempoTrancurrido < Tiempo)
        {
            tiempoTrancurrido += Time.deltaTime;
            yield return null;
        }
        PoolManager.ReturnToPool(gameObject);
    }
}

