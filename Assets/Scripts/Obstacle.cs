using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy=1f;
    [SerializeField]
    private float _obstacleHardness = 10f;
    [SerializeField]
    private Animation _anim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Player") { return; }
        if (collision.relativeVelocity.magnitude > 10)
        {
            //Play anim
            Destroy(gameObject);
         
        }
        else
        {
            StartCoroutine(DestroyObstacle());
        }
    }
   
    private IEnumerator DestroyObstacle()
    {
        yield return new WaitForSeconds(_timeToDestroy);
        Destroy(gameObject);
    }
}
