using UnityEngine;

public class SistemaPuntuacion : MonoBehaviour
{
    public static int puntuacion = 0;

    public void puntuar(int puntos)
    {
        puntuacion += puntos;
    }

    public void quitarPuntos(int puntos)
    {
        puntuacion -= puntos;
    }
}
