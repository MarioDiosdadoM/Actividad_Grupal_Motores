using UnityEngine;

public class SistemaVida : MonoBehaviour
{
    [Header("Punto respawn")]
    public Transform puntoRespawn;
    public static System.Action reseteoPinchos;
    [SerializeField] private AudioClip hit;
    private AudioSource audioSource;
    public static int vida = 100;

    public void Awake()
    {
        audioSource = GetComponent<AudioSource>();        
    }

    public void Reaparecer()
    {
        Muerte.menu.OcultarPanel();
        Debug.Log("Llamada a reaparicion");
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        transform.SetPositionAndRotation(puntoRespawn.position, puntoRespawn.rotation);
        if (cc != null) cc.enabled = true;
        reseteoPinchos?.Invoke();
        vida = 100;
    }   
    
    public void GetHit(int vidaQuitada)
    {
        vida -= vidaQuitada;
        audioSource.Stop();
        audioSource.clip = hit;       
        audioSource.Play();
        if (vida <= 0)
        {
            audioSource.Stop();
            Muerte.menu.MostrarPanel();            
        }             
    }
}