using UnityEngine;
public class Enemigo : MonoBehaviour
{
    [SerializeField] private float vida = 100;
    private Vector3 spawnPos;

    private void Awake()
    {
        spawnPos = transform.position;
    }

    //Método para que el enemigo pierda vida y vuelva a su punto de spawn al llegar a 0 de vida
    public void RecibirDano(float dano)
    {
        vida -= dano;
        Debug.Log("Enemigo ha recibido " + dano + " de Dano. Le queda " + vida + " de vida.");
        if (vida <= 0) { transform.position = spawnPos; }
    }
}