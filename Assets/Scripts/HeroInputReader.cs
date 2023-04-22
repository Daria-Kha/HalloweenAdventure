using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField] private Hero _hero;

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        _hero = GameObject.Find("Hero_0").GetComponent<Hero>();
        _hero.SetDirection(direction);
    }
    
    public void OnSaySomething(InputAction.CallbackContext context)
    {
        _hero = GameObject.Find("Hero_0").GetComponent<Hero>();
            _hero.SaySomething();
    }
}



