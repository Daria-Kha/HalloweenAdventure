using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    protected override void Die()
    {
        _animator.SetTrigger("death");
        isDead = true;

        {
            if (gameObject.GetComponentInParent<EnemyPatrol>() != null)
            {
                Debug.Log("found");
                gameObject.GetComponentInParent<EnemyPatrol>().enabled = false;
            }
            if (gameObject.GetComponentInParent<EnemyPatrol2>() != null)
                gameObject.GetComponentInParent<EnemyPatrol2>().enabled = false;
            

            if (gameObject.GetComponent<Enemy>() != null)
                gameObject.GetComponent<Enemy>().enabled = false;
        }
    }
}
