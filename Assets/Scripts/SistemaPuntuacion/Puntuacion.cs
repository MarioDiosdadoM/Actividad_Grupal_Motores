using TMPro;
using UnityEngine;

/* Autor: Daniel Heras Duran
 * Esta clase sirve para manejar el contador de vida del sistema de vida.
 */

public class Puntuacion : MonoBehaviour
{
    TextMeshProUGUI texto;

    void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        texto.text = "Puntos: " + SistemaPuntuacion.puntuacion;
    }
}