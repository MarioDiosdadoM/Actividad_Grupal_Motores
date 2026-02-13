//Script para configurar el trigger que hace aparecer el menú final
using UnityEngine;

public class Salida : MonoBehaviour
{
    public Findepartida findepartida;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Jugador"))//"If" que hace saltar el menú si el objeto con el tag "Jugador" colisiona con el trigger
        {
            findepartida.MostrarMenu();
        }
    }
}