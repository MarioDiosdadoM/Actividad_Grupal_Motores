using System.Collections;
using UnityEngine;

public class Bala : MonoBehaviour
{
    [SerializeField] private float Velocidad = 1;
    [SerializeField] private float Dano = 20;
    [SerializeField] private float Tiempo = 5;

    private Vector3 Direccion;

    public void Inicializar(Vector3 dir)
    {
        Direccion = dir;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.TryGetComponent<Enemigo>(out var enemigo))
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

