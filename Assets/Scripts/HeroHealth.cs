using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroHealth : Health
{
    protected override void Die()
    {
        Debug.Log("tu");
        _animator.SetTrigger("death");
        isDead = true;
    }
}
