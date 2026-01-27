//Script para la funcionalidad del menú inicial
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    //Función que carga la escena de juego
    public void Jugar()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Función que permite abandonar el juego
    public void Salir()
    {
        Debug.Log("Salir del juego");
        Application.Quit();
    }
}
