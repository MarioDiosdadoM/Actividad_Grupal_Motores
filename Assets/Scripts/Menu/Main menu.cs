/*
 * Autores: 
 * Motores de videojuegos 1
 * 
 * Este script gestiona el menu principal.
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    [SerializeField] private Camera cam;
    
    public void Update()
    {
        cam.transform.Rotate(0.0f, 0.05f, 0.0f, Space.World);
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
