using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class EnterTrigger : MonoBehaviour
    {
        [SerializeField] private UnityEvent _action;

        private void OnTriggerEnter2D(Collider2D col)
      {
          if (col.gameObject.CompareTag("Item"))
          {
              _action?.Invoke();
          }
      }
        
        
    }
}
