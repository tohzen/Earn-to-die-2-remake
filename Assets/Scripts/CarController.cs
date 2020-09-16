using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[RequireComponent(typeof(Rigidbody2D))]
public class CarController : MonoBehaviour
{
    [SerializeField]
    private WheelJoint2D _wheel;
    [SerializeField]
    private float _motorForce=0f;
    [SerializeField]
    private float _rotationForce = 0f;
    [SerializeField]
    private Booster _carBooster;
    [SerializeField]
    private Transform _boosterPosition;

    private float _horizontalMovement;
    private float _rotationMovement;
    private JointMotor2D _carMotor;
    private Rigidbody2D _carRigidBody;
    [Range(-1f, 1f)]
    private float _rotationRatio;
    [Range(-1f, 1f)]
    private float _movementRatio;
    private bool _needToUseBooster = false;
    private float _leftTimeToUseBooster = 10f;
    private ParticleSystem _carBoosterParticals;
    public void SetBoosterTrigger(bool needToUseBooster)
    {
        _needToUseBooster = needToUseBooster;
    }
    public void AddRotationRatio(float rotationRatio)
    {
        _rotationRatio = rotationRatio;
    }
    public void AddMovementRatio(float movementRatio)
    {
        _movementRatio = movementRatio;
    }


    private void Awake()
    {
        _carRigidBody = GetComponent<Rigidbody2D>();
        _carMotor = new JointMotor2D();
    }
    // Start is called before the first frame update
    void Start()
    {
        _leftTimeToUseBooster = _carBooster.GetTimeToUse();
        _carMotor.maxMotorTorque = _wheel.motor.maxMotorTorque;
    }
    private void Update()
    {
        _horizontalMovement = - Input.GetAxis("Horizontal") * _motorForce;
        _rotationMovement = Input.GetAxis("Vertical") * _rotationForce;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        HorizontalMovement();
        RotationMovement();
        UsingBooster();
    }
    void UsingBooster()
    {
        if (!_needToUseBooster || _leftTimeToUseBooster <= 0) { return; }
        _carBooster.UseBooster(_carRigidBody,_boosterPosition.position);
        _leftTimeToUseBooster -= Time.deltaTime;
      
    }
    void RotationMovement()
    {
        _carRigidBody.AddTorque(_rotationForce * _rotationRatio);
    }
    void HorizontalMovement()
    {
        _horizontalMovement =  -_motorForce * _movementRatio;
        if (_horizontalMovement == 0f)
        {
            _wheel.useMotor = false;
        }
        else
        {
            _wheel.useMotor = true;
            _carMotor.motorSpeed = _horizontalMovement;
            _wheel.motor = _carMotor;

        }
       
    }
}
