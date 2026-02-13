using UnityEngine;
public class Enemigo : MonoBehaviour
{
    [SerializeField] protected float vida = 60;
    [SerializeField] protected int dano = 10;
    private GameObject puntos;

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
            puntos = GameObject.FindWithTag("Jugador");
            puntos.GetComponent<SistemaPuntuacion>().Puntuar(50);
            Destroy(gameObject);
        }
    }
}