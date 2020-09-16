﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Vector2 _speed;

    private CapsuleCollider2D _capsuleEnemyCollider;
    private Rigidbody2D _enemyRigidBody;
    private void Awake()
    {
        _capsuleEnemyCollider = GetComponent<CapsuleCollider2D>();
        _enemyRigidBody = GetComponent<Rigidbody2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag!="Player") { return; }
        _capsuleEnemyCollider.isTrigger = true;
        StartCoroutine(Collision());
    }
    private IEnumerator Collision()
    {
        yield return new WaitForSeconds(0.2f);
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(0.2f,0.5f),Random.Range(20f,50f)),ForceMode2D.Impulse);
        //Play particles
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        _enemyRigidBody.AddForce(_speed,ForceMode2D.Force);
        
    }
}
