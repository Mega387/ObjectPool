using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int startPoolSize = 5;
    [SerializeField] private int maxPoolSize = 20;

    private List<GameObject> pool = new List<GameObject>();
    private int totalObjects = 0;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < startPoolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject CreateNewObject()
    {
        if (totalObjects >= maxPoolSize)
            return null;

        GameObject newObj = Instantiate(prefab);
        newObj.SetActive(false);
        pool.Add(newObj);
        totalObjects++;
        return newObj;
    }

    public GameObject TryGetFromPool()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        return CreateNewObject();
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
        pool.Add(obj);
    }
}