using UnityEngine;
using UnityEngine.Audio;
public class Enemigo : MonoBehaviour
{
    [SerializeField] protected float vida = 60;
    [SerializeField] protected int dano = 10;
    [SerializeField] AudioClip clip;
    private AudioSource audioSource;
    private GameObject puntos;
    private float tiempo = 2f;


    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 3.0f;
        audioSource.clip = clip;
    }
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

    void OnTriggerStay(Collider col)
    {
        tiempo -= Time.fixedDeltaTime;
        if (tiempo < 0.0f)
        {
            if (col.gameObject.TryGetComponent<SistemaVida>(out var sitemaVida))
            {
                sitemaVida.GetHit(dano);
            }
            if (col.gameObject.TryGetComponent<SistemaPuntuacion>(out var sistemaPuntos))
            {
                sistemaPuntos.QuitarPuntos(10);
            }
            tiempo = 2f;
        }        
    }

    //Metodo para que el enemigo pierda vida y vuelva a su punto de spawn al llegar a 0 de vida
    public virtual void RecibirDano(float dano)
    {
        vida -= dano;        
        audioSource.Play();
        Debug.Log("Enemigo ha recibido " + dano + " de Dano. Le queda " + vida + " de vida.");
        if (vida <= 0) 
        {
            audioSource.Play();
            puntos = GameObject.FindWithTag("Jugador");
            puntos.GetComponent<SistemaPuntuacion>().Puntuar(50);
            Destroy(gameObject);
        }
    }
}