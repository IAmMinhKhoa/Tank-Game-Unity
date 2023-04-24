using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
  

    [SerializeField]
    protected GameObject objectToPool;
    public int poolsize = 5;
    protected Queue<GameObject> objectPool;
    public Transform spawnObjectParent;

    private void Awake()
    {
        objectPool = new Queue<GameObject>();
    }
    public void Innit(GameObject objectPool,int poolsize )
    {
        this.objectToPool = objectPool;
        this.poolsize = poolsize;
    }

    public GameObject CreateObject()
    {
        CreateObjectParentIfNeeded();

        GameObject spawnedObject = null;

        if (objectPool.Count < poolsize)
        {
            spawnedObject = Instantiate(objectToPool);
            spawnedObject.name = transform.root.name + "_" + objectToPool.name + "_" + objectPool.Count;
            spawnedObject.transform.SetParent(spawnObjectParent);

        }
        else
        {
            spawnedObject=objectPool.Dequeue(); //là thao tác xóa ph?n t? ? ??u hàng ??i
           
            spawnedObject.SetActive(true);
        }

        objectPool.Enqueue(spawnedObject);//là thao tác thêm m?t ph?n t? vào cu?i c?a hàng ??i.
        return spawnedObject;
    }

    private void CreateObjectParentIfNeeded()
    {
        if (spawnObjectParent == null)
        {
            string name ="Objectpool_"+objectToPool.name;
            var parentObject = GameObject.Find(name);
            if (parentObject != null)
            {
                spawnObjectParent = parentObject.transform;
            }
            else
            {
                spawnObjectParent = new GameObject(name).transform;
            }
        }
    }
}
