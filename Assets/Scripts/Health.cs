using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour
{
    public int maxHealth;
    private bool isInvulnerable;
    public float currentHealth;
    private float invulnerabilityTimer;
    private float invulnerabilityDuration = 1f;
    public Rigidbody2D _rigidbody;
    protected Animator _animator;
    public bool isDead;
    [SerializeField] private Behaviour[] components;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }
    
    private void Update()
    {
        if (isInvulnerable)
        {
            invulnerabilityTimer += Time.deltaTime;
            if (invulnerabilityTimer >= invulnerabilityDuration)
            {
                isInvulnerable = false;
            }
        }
    }
    
    
    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        
        Debug.Log(gameObject.tag + " got damage");
        if (!isInvulnerable)
        {
            currentHealth -= amount;
        }

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            isInvulnerable = true;
            invulnerabilityTimer = 0f;
            _animator.SetTrigger("damage");
        }
    }
    
    protected abstract void Die();
    
}
