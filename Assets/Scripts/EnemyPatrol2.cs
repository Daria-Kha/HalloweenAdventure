using UnityEngine;
using UnityEngine.Serialization;

public class EnemyPatrol2 : MonoBehaviour
{
    [Header("Patrol Points")]
    [SerializeField] private Transform leftEdge;
    [SerializeField] private Transform rightEdge;

    [FormerlySerializedAs("_enemy")]
    [Header("Enemy")] 
    [SerializeField] private Transform enemy;

    [FormerlySerializedAs("_speed")]
    [Header("Movement parameters")] 
    [SerializeField]
    public float speed;
    private Vector3 _initScale;
    private bool _movingLeft;

    [FormerlySerializedAs("_animator")]
    [Header("Enemy Animator")] 
    [SerializeField] private Animator animator;

    private static readonly int Moving = Animator.StringToHash("Moving");

    private void Awake()
    {
      
        _initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        animator.SetBool(Moving, false);
    }
    private void Update()
    {
        //Debug.Log(gameObject.tag + " moving");
        if (_movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveInDirection(-1);
            else
                DirectionChange();
        }
        else 
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveInDirection(1);
            else
                DirectionChange();
        }
    }

    private void DirectionChange()
    {
        _movingLeft = !_movingLeft;
    }

    private void MoveInDirection(int direction)
    {
        animator.SetBool(Moving, true);
        
        enemy.localScale = new Vector3(Mathf.Abs(_initScale.x) * direction, _initScale.y, _initScale.z);

        var position = enemy.position;
        position = new Vector3(position.x + Time.deltaTime * direction * speed, 
            position.y, position.z);
        enemy.position = position;
    }
}