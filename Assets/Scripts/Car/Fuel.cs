using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [SerializeField]
    private float _timeToEndFuel = 20f;
    private CarController _car;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        _timeToEndFuel -= Time.deltaTime;
        if (_timeToEndFuel < 0)
        {
         //   _car.SetCarForce(0);
        }
    }
}
