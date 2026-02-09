using System.Collections.Generic;
using UnityEngine;

public static class PoolManager
{
    //Esta clase estactica se enecarga de maneja el Pooling de los objetos

    private static Dictionary<int, Queue<GameObject>> _pools = new Dictionary<int, Queue<GameObject>>();

    //Liberar un objeto del Pool
    public static GameObject Release(GameObject prefab, Vector3 position, Quaternion rotation)
    {
        int key = prefab.GetInstanceID();

        //Si el Pool no existe, se crea
        if (!_pools.ContainsKey(key))
        {
            _pools[key] = new Queue<GameObject>();
        }

        GameObject obj;

        //Si hay un objeto en el pool, se vuelve a usar
        if (_pools[key].Count > 0)
        {
            obj = _pools[key].Dequeue();
            obj.transform.position = position;
            obj.transform.rotation = rotation;
            obj.SetActive(true);
        }
        else
        {
            obj = Object.Instantiate(prefab, position, rotation);
            //Se agrega el componente PoolMember para rastrear su pool correspondiente
            obj.AddComponent<PoolMember>().myPoolKey = key;
        }

        return obj;
    }

    //Devolver un objeto al pool
    public static void ReturnToPool(GameObject obj)
    {
        PoolMember member = obj.GetComponent<PoolMember>();
        if (member != null && _pools.ContainsKey(member.myPoolKey))
        {
            obj.SetActive(false);
            _pools[member.myPoolKey].Enqueue(obj);
        }
        else
        {
            //Si el objeto no pertence a ning�n pool, se destruye
            Object.Destroy(obj);
        }
    }
}


public class PoolMember : MonoBehaviour
{
    public int myPoolKey;
}
