using UnityEngine;

public class SistemaPuntuacion : MonoBehaviour
{
    public static int puntuacion;

    public void Awake()
    {
        puntuacion = 0;
    }
    public void Puntuar(int puntos)
    {
        if (puntos <= 9999)
        {
            puntuacion += puntos;
        }
    }

    public void QuitarPuntos(int puntos)
    {
        if (puntos <= 9999)
        {
            puntuacion -= puntos;
        }
    }
}