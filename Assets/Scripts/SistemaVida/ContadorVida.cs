using TMPro;
using UnityEngine;

/* Autor: Daniel Heras Durán
 * Esta clase sirve para manejar el contador de vida del sistema de vida.
 */

public class ContadorVida : MonoBehaviour
{
    TextMeshProUGUI texto;

    void Awake()
    {
        texto = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {        
        if (SistemaVida.vida > 0)
        {
            texto.text = "Vida: " + SistemaVida.vida;
        }
        else
        {
            texto.text = " ";
        }
    }
}