using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private BoxCollider2D _boxCollider2D;
    private EnemyHealth health;
    private HeroHealth _heroHealth;

    private EnemyPatrol _enemyPatrol;

    [SerializeField] private float attack;
    [SerializeField] private float range;
    [SerializeField] private float colliderDistance;
    [SerializeField] private int damage;
    [SerializeField] private LayerMask _heroLayer;
    private float cooldownTimer = Mathf.Infinity;
        
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
        _enemyPatrol = GetComponentInParent<EnemyPatrol>();
        health = GetComponent<EnemyHealth>();
        _heroHealth = GameObject.Find("Hero_0").GetComponent<HeroHealth>();

    }

    void Update()
    {
        cooldownTimer += Time.deltaTime;
        
        if (HeroInSight())
        {
            if (cooldownTimer >= attack)
            {
                cooldownTimer = 0;
                _animator.SetTrigger("Attack");
            }
        }

        if (_enemyPatrol != null)
            _enemyPatrol.enabled = !HeroInSight();
    }

    private bool HeroInSight()
    {
        RaycastHit2D hit2D = Physics2D.BoxCast(_boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(_boxCollider2D.bounds.size.x, _boxCollider2D.bounds.size.y, _boxCollider2D.bounds.size.z), 
            0, Vector2.left, 0, _heroLayer);

      // if (hit2D.collider != null) 
        //   health = hit2D.transform.GetComponent<EnemyHealth>();

        return hit2D.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(
            _boxCollider2D.bounds.center + transform.right * range * transform.localScale.x * colliderDistance, 
            new Vector3(_boxCollider2D.bounds.size.x, _boxCollider2D.bounds.size.y, _boxCollider2D.bounds.size.z));
    }

    private void DamageHero()
    {
        if (HeroInSight())
            _heroHealth.TakeDamage(damage);
    }        
}
