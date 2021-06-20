using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pooler
{
    ///A gameobject pooling class


    private GameObject poolerPrefab;

    private Stack<GameObject> unusedPoolObjects = new Stack<GameObject>();

    public Pooler(GameObject objectPrefab)
    {
        poolerPrefab = objectPrefab;
    }

    public GameObject GetPooledObject()
    {
        if (unusedPoolObjects.Count < 1)
        {
            return CreatePooledObject();
        }
        return ReusePooledObject();
    }

    private GameObject ReusePooledObject()
    {
        GameObject obj = unusedPoolObjects.Pop();
        obj.SetActive(true);
        return obj;
    }

    private GameObject CreatePooledObject()
    {
        GameObject obj = MonoBehaviour.Instantiate(poolerPrefab);
        return obj;
    }

    public void DestroyPooledObject(GameObject obj)
    {
        unusedPoolObjects.Push(obj);
        obj.SetActive(false);
    }
}
