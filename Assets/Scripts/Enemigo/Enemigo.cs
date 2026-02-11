using System.Runtime.CompilerServices;
using UnityEngine;
public class Enemigo : MonoBehaviour
{
    [SerializeField] protected float vida = 100;
    [SerializeField] protected int dano = 5;

    protected void OnTriggerEnter(Collider col)
    {
        SistemaVida sitemaVida = col.gameObject.GetComponent<SistemaVida>();
        if (sitemaVida != null)
        {
            sitemaVida.GetHit(dano);
        }
    }

    //Metodo para que el enemigo pierda vida y vuelva a su punto de spawn al llegar a 0 de vida
    public virtual void RecibirDano(float dano)
    {
        vida -= dano;
        Debug.Log("Enemigo ha recibido " + dano + " de Dano. Le queda " + vida + " de vida.");
        if (vida <= 0) 
        {
            Destroy(gameObject);
        }
    }
}