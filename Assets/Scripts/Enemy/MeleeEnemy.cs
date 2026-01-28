using UnityEngine;

public class MeleeEnemy : MonoBehaviour
{

    [SerializeField] private float attackCD;
    [SerializeField] private float range;
    [SerializeField] private float colDistance;
    [SerializeField] private int damage;
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private LayerMask playerLayer;
    private float cdTimer = Mathf.Infinity;

    private Animator anim;

    private Health playerHealth;

    private EnemyPatrol enemyPatrol;

    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyPatrol = GetComponentInParent<EnemyPatrol>();
    }

    void Update()
    {
        cdTimer += Time.deltaTime;

        bool playerDetected = PlayerInSight();
        bool atEdge = enemyPatrol.IsAtEdge();

        if (playerDetected && !atEdge && cdTimer >= attackCD)
        {
            cdTimer = 0;
            anim.SetTrigger("MeleeAttack");
        }

        enemyPatrol.CanMove = !playerDetected;
    }

    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z),
        0 , Vector2.left, 0, playerLayer);

        if (hit.collider != null)
            playerHealth = hit.transform.GetComponent<Health>();

        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colDistance, 
        new Vector3(boxCollider.bounds.size.x * range, boxCollider.bounds.size.y, boxCollider.bounds.size.z));
    }

    private void damagePlayer()
    {
        if (PlayerInSight())
        {
            playerHealth.TakeDamage(damage);
        }
    }
}
