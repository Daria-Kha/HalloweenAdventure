using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicTile : MonoBehaviour
{
    public float projectileSpeed;
    public GameObject impactEffect;

    private Rigidbody2D rigitbody;

    private void Start()
    {
        rigitbody = GetComponent<Rigidbody2D>();
        rigitbody.velocity = transform.right * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Instantiate(impactEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Ouch!");
            col.GetComponent<EnemyHealth>().TakeDamage(2);
        }
    }

}
 
