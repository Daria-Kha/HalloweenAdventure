using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMagic : MonoBehaviour
{
    private void Awake()
    {
        Destroy(gameObject, 0.4f);
    }
}
