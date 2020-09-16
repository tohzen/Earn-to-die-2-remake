using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler :MonoBehaviour
{
    public static ObjectPooler Instance;
    public List<GameObject> PooledObjects;
    [SerializeField]
    private GameObject _objectToPool;
    [SerializeField]
    private int _amountToPool;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PooledObjects = new List<GameObject>();
        GameObject tmp;
        for(int i = 0; i < _amountToPool; i++)
        {
            tmp = Instantiate(_objectToPool);
            tmp.SetActive(false);
            PooledObjects.Add(tmp);
        }
    }
    public GameObject GetObject()
    {
        for (int i = 0; i < _amountToPool; i++)
        {
            if (!PooledObjects[i].activeInHierarchy)
            {
                return PooledObjects[i];
            }
        }
        PooledObjects.Add(_objectToPool);
        _amountToPool++;
        return PooledObjects[_amountToPool-1];

    }
}
