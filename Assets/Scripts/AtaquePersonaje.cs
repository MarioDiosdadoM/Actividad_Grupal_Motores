using UnityEngine;

public class AtaquePersonaje : MonoBehaviour
{
    [SerializeField] private Camera m_Cam;
    [SerializeField] private float Dano = 5;

    private void Update()
    {
        if (!Input.GetMouseButtonDown(0)) { return; }

        //Creamos el rayo desde la camara hasta la posicion del mouse
        Ray ray = m_Cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit; //Variable para almacenar la informacion del impacto

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

        if (Physics.Raycast(ray, out hit))
        {
            //Si el rayo impacta con un objeto, obtenemos su transform
            Transform obj = hit.transform;
            Enemigo enemigo = obj.GetComponent<Enemigo>();

            //Si el objeto tiene un componente enemigo y se persiona clic izquierdo, se activa el eveneto
            if (enemigo != null)
            {
                Debug.Log("Enemigo detectado");
                enemigo.RecibirDano(Dano);
            }
        }
    }
}
