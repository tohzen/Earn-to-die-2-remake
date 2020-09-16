using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float _timeToDisablingBullet = 2f;
    [SerializeField]
    private Vector2 _speed;
    private Rigidbody2D _bulletRigidBody;
    public void AddBulletForce()
    {
        _bulletRigidBody.AddForce(_speed, ForceMode2D.Impulse);
        StartCoroutine(DisableBullet(_timeToDisablingBullet));
    }
    private void Awake()
    {
        _bulletRigidBody = GetComponent<Rigidbody2D>();
    }
    private IEnumerator DisableBullet(float timeToDisable)
    {
        yield return new WaitForSeconds(timeToDisable);
        gameObject.SetActive(false);
    }
   
}
