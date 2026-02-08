using UnityEngine;

public class Respawn : MonoBehaviour
{
    [Header("Punto respawn")]
    public Transform puntoRespawn;
    public static System.Action reseteoPinchos;

    public void Morir()
    {
        Muerte.menu.MostrarPanel();
    }

    public void Reaparecer()
    {
        Muerte.menu.OcultarPanel();
        Debug.Log("Llamada a reaparicion");
        CharacterController cc = GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;
        transform.SetPositionAndRotation(puntoRespawn.position, puntoRespawn.rotation);
        if (cc != null) cc.enabled = true;
        reseteoPinchos?.Invoke();
    }    
}