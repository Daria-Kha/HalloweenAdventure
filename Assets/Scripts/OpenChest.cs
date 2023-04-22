using System;
using System.Collections;
using System.Collections.Generic;
using PixelCrew.Components;
using UnityEngine;

public class OpenChest : MonoBehaviour
{ 
    private Animator _animator;
    private int _keysNeeded = 1;

    private void Awake() 
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Hero hero = col.gameObject.GetComponent<Hero>();
        Debug.Log(col.gameObject.tag);
       // Debug.Log(_keysCollected);
       if (col.gameObject.CompareTag("Player") && hero.keysCollected >= _keysNeeded)
        {
            Debug.Log("Chest triggered");
            _animator.SetTrigger("Chest");
            hero.RemoveKey();

        }
    }

    
}
