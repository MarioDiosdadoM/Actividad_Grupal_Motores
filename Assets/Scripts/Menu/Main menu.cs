/*
 * Motores de videojuegos 1
 * 
 * Este script gestiona el menu principal.
 */

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private AudioClip clip;
    private AudioSource audioSource;
    private Slider audioVolume;
    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        //audioSource.volume = audioVolume;
        audioSource.Play();
    }
    public void Update()
    {
        cam.transform.Rotate(0.0f, 0.05f, 0.0f, Space.World); //rotar camara
       // audioSource.volume = audioVolume;
    }    

    //Funcion que carga la escena de juego
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Funcion que permite abandonar el juego
    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}