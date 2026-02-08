using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;

public class Bala : MonoBehaviour
{
    [SerializeField] private float Velocidad = 15;
    [SerializeField] private float Dano = 5;
    [SerializeField] private float Tiempo = 5;

    private Vector3 Direccion;

    private static Dictionary<int, Queue<Bala>> Pool = new Dictionary<int, Queue<Bala>>();

    public void Inicializar(Vector3 dir)
    {
        Direccion = dir;
    }

    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.CompareTag("Enemigo"));
        if (col.CompareTag("Enemigo"))
        {
            Enemigo enemigo = col.gameObject.GetComponent<Enemigo>();
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

