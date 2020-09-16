using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0, 30)]
    private int _numOfBullets =  5;
    [SerializeField]
    private Transform _bulletStartPosition;
    [SerializeField]
    private float _attackDistance = 10f;

    private float _timeToNextShoot = 1f;
    private GameObject _lastAttackedObject;
    private void Update()
    {
        TryAttack();
    }

    private void TryAttack()
    {
        _timeToNextShoot -= Time.deltaTime;
        if (_timeToNextShoot >= 0) return;
        RaycastHit2D hit = Physics2D.Raycast(_bulletStartPosition.position, Vector2.right, _attackDistance);
        if (hit.collider != null && hit.collider.tag == "Enemy")
        {
            
            GameObject bulletInstance = ObjectPooler.Instance.GetObject();
            bulletInstance.transform.position = _bulletStartPosition.position;
            bulletInstance.SetActive(true);
            bulletInstance.GetComponent<Bullet>()?.AddBulletForce();
            
            Debug.Log("WTF");
            _timeToNextShoot = 0.5f;
        }
    }
    
}
