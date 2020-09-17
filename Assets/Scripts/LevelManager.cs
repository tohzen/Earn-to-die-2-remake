using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    [SerializeField]
    private List<LevelObject> _scenePrefabs;
    [SerializeField]
    private int _numOfLoadedScenes;
 

    public void PerformRelocationEnviroment(int currentEnviromentObjectIndex)
    {
        if (currentEnviromentObjectIndex > 0)
        {
            Debug.Log("Hueta");
           _scenePrefabs[currentEnviromentObjectIndex - 1].gameObject.SetActive(false);
        }
        Debug.Log("Hueta vne" +currentEnviromentObjectIndex);
        if(_scenePrefabs.Count>currentEnviromentObjectIndex+2)
        _scenePrefabs[currentEnviromentObjectIndex+2].gameObject.SetActive(true);
    }
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        for (int index = 0; index < _scenePrefabs.Count;index++) 
        {
            if(index>1) _scenePrefabs[index].gameObject.SetActive(false);
        }

    }


    void Update()
    {
        
    }
}
