using UnityEngine;
using UnityEngine.SceneManagement;

public class Hero : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private LayerCheck groundCheck;

    public Vector2 direction;
    public new Rigidbody2D rigidbody;
    private Animator _animator;

    public bool knockbackFlag;
    private bool _knockbackAdded;
    
    private Vector3 _pushDirection;
    public int keysCollected;
    private static readonly int IsGround = Animator.StringToHash("Is_ground");
    private static readonly int VerticalVelocity = Animator.StringToHash("vertical_velocity");
    private static readonly int IsRunning = Animator.StringToHash("Is_running");

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        groundCheck = GetComponentInChildren<LayerCheck>();
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
    
    private void FixedUpdate()
    {
        if (knockbackFlag && !_knockbackAdded)
        {
            rigidbody.AddForce(_pushDirection.normalized * 700f);
            _knockbackAdded = true;
        }
        else if (IsGrounded())
        {
            knockbackFlag = false;
            _knockbackAdded = false;
        }

        if (knockbackFlag) 
            return;
        
        rigidbody.velocity = new Vector2(direction.x * speed, rigidbody.velocity.y);
            
        var isJumping = direction.y > 0;
        var grounded = IsGrounded();
            
        if (isJumping)
        {
            if (IsGrounded() && rigidbody.velocity.y <= 0)
            {
                rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
            }
        }
        else if (rigidbody.velocity.y > 0)
        {
            var velocity = rigidbody.velocity;
            velocity = new Vector2(velocity.x, velocity.y * 0.5f);
            rigidbody.velocity = velocity;
        }
            
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;

        _animator.SetBool(IsGround, grounded);
        _animator.SetFloat(VerticalVelocity, rigidbody.velocity.y);
        _animator.SetBool(IsRunning, direction.x != 0);

        UpdateSpriteDirection();
    }

    private void UpdateSpriteDirection()
    {
        if (direction.x > 0)
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        
        else if (direction.x < 0)
            transform.eulerAngles = new Vector3(0f, 180f, 0f);
    }

    private bool IsGrounded()
    {
        return groundCheck.IsTouchingLayer;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Trap"))
        {
            GetComponent<Health>().TakeDamage(1);
            _pushDirection = rigidbody.transform.position - col.transform.position;
            knockbackFlag = true;
        }
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            GetComponent<Health>().TakeDamage(1);
            _pushDirection = rigidbody.transform.position - col.transform.position;
            knockbackFlag = true;
        }
    }
    
    public void AddKey()
    {
        keysCollected++;
        Debug.Log("Keys collected: " + keysCollected);
    }
    
    public void RemoveKey()
    {
        keysCollected--;
        if (keysCollected < 0)
        {
            keysCollected = 0;
        }
    }
    
        
    public void Reload()
    {
        var scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
        GetComponent<HeroHealth>().isDead = false;
    }

    public void SaySomething()
    {
        Debug.Log(message:"Something!");
    }
    
}
