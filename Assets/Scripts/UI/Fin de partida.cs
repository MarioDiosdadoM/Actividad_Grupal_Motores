//Script para mostrar menú de fin de partida al llegar a la meta

using UnityEngine;
using UnityEngine.SceneManagement;

public class Findepartida : MonoBehaviour
{
    public GameObject menuFinal;   

    //Función para mostrar el menú
    public void MostrarMenu()
    {
        menuFinal.SetActive(true);
        Time.timeScale = 0f;                       // Pausa el juego
    }

    //Función para volver a empezar el laberinto
    public void Reintentar()
    {
        Time.timeScale = 1f;                                                  //Reanuda el juego
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);     //Carga la escena de juego
    }

    //Función para volver al menú inicial
    public void VolverAMenu()
    {
        Time.timeScale = 1f;                    //Reanuda el juego
        SceneManager.LoadScene("Main Menu");    //Carga la escena del menú inicial
    }
}