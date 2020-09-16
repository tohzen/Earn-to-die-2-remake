using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Create new Booster",order =0)]
public class Booster : ScriptableObject
{
    [SerializeField]
    private float _workingPeriod = 10f;
    public GameObject _particalBooster;
    [SerializeField]
    private Vector2 _addedForce;

    public void UseBooster(Rigidbody2D carRigidBody, Vector2 boosterPotition)
    {
      carRigidBody.AddForceAtPosition(_addedForce, boosterPotition);
     
    }
    public float GetTimeToUse()
    {
        return _workingPeriod;
    }



}
