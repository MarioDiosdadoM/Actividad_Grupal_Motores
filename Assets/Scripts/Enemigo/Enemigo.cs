using UnityEngine;
public class Enemigo : MonoBehaviour
{
    [SerializeField] protected float vida = 100;
    [SerializeField] protected int dano = 15;

    protected void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.TryGetComponent<SistemaVida>(out var sitemaVida))
        {
            sitemaVida.GetHit(dano);            
        }
        if (col.gameObject.TryGetComponent<SistemaPuntuacion>(out var sistemaPuntos))
        {
            sistemaPuntos.QuitarPuntos(10);
        }
    }

    //Metodo para que el enemigo pierda vida y vuelva a su punto de spawn al llegar a 0 de vida
    public virtual void RecibirDano(float dano)
    {
        vida -= dano;
        Debug.Log("Enemigo ha recibido " + dano + " de Dano. Le queda " + vida + " de vida.");
        if (vida <= 0) 
        {
            if (gameObject.TryGetComponent<SistemaPuntuacion>(out var sistemaPuntos))
            {
                sistemaPuntos.Puntuar(20);
            }
            Destroy(gameObject);
        }
    }
}