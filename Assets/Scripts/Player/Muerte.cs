using UnityEngine;

public class Muerte : MonoBehaviour
{
    public static Muerte menu;
    public GameObject panelMuerte;
    [SerializeField] private AudioClip gameOverSong;
    private AudioSource audioSource, audioSource2;

    private void Awake()
    {
        if (menu == null) {
            menu = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameOverSong;
        audioSource2 = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<AudioSource>();
    }
    void Start()
    {
        panelMuerte.SetActive(false);        
    }

    public void MostrarPanel()
    {
        audioSource2.Stop();
        audioSource.Play(); //reproduce cancion de game over
        panelMuerte.SetActive(true);        
        Time.timeScale = 0f;       
    }

    public void OcultarPanel()
    {
        audioSource.Stop();
        panelMuerte.SetActive(false);
        Time.timeScale = 1f;
        audioSource2.Play();
    }

    public void Abandonar()
    {
        Application.Quit();
    }
}
