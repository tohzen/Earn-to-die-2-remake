using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObject : MonoBehaviour
{

    [SerializeField]
    private int _numOfObjectInScene;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player") return;
        LevelManager.Instance.PerformRelocationEnviroment(_numOfObjectInScene);
    }
}
