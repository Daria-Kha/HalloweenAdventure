using System;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerAttack : MonoBehaviour

{
    public Transform firePosition;
    public GameObject projectile;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Instantiate(projectile, firePosition.position, firePosition.rotation);
    }

}
    