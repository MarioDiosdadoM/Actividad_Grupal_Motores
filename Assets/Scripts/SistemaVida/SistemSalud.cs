using UnityEditor;
using UnityEngine;

/* Autor: Daniel Heras Durán
 * Esta clase sirve para manejar el sistema de vida.
 * La vida inicial es 100, pero si llega a 0, transporta al jugador
 * al respawn incial y resetea la vida.
 */
/*
public class SistemaSalud: MonoBehaviour
{
    [SerializeField] private AudioClip musica;
    [SerializeField] private AudioClip gameover;
    [SerializeField] Canvas detectedCanvas;
    private GameObject player, spawn;
    private bool isGameover = false;
    public int vida = 100;
    private float tiempoTranscurrido = 0f;
    private float tiempoEspera = 10f;
    private AudioSource audioSource;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        detectedCanvas.gameObject.SetActive(false);
        this.GetComponent<Renderer>().enabled = false;
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = musica;
        audioSource.Play(); //Reproduce música de fondo.
        spawn = GameObject.FindGameObjectWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if (vida <= 0 && !isGameover)
        {
            GameOver();
        }
        if (isGameover)
        {
            tiempoTranscurrido += Time.deltaTime;
            if (tiempoTranscurrido > tiempoEspera)
            {
                ResetGame();
                tiempoTranscurrido = 0f;
            }
        }
    }

    private void GameOver()
    {
        isGameover = true;
        audioSource.Stop();
        audioSource.clip = gameover;
        audioSource.PlayDelayed(1f);
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerMovement>().enabled = false;
        detectedCanvas.gameObject.SetActive(true);
    }

    private void ResetGame()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("RESET");
        player.transform.SetPositionAndRotation(spawn.transform.position, Quaternion.Euler(0, 0, 0));
        audioSource.Stop();
        audioSource.clip = musica;
        isGameover = false;
        vida = 100;
        audioSource.Play();
        detectedCanvas.gameObject.SetActive(false);
        player.GetComponent<PlayerMovement>().enabled = true;

    }
}*/