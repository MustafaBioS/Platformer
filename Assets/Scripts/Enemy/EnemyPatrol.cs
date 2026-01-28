using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] Transform leftEdge;
    [SerializeField] Transform rightEdge;

    [SerializeField] Transform enemy;

    [SerializeField] private float speed;
    private Vector3 initScale;
    private bool movingLeft;

    [SerializeField] private float idleDuration;
    private float idleTimer;
    public bool CanMove = true;


    [SerializeField] private Animator anim;

    private void Awake()
    {
        initScale = enemy.localScale;
    }

    private void OnDisable()
    {
        anim.SetBool("Run", false);
    }

    public bool IsAtEdge()
    {
        if (movingLeft)
            return enemy.position.x < leftEdge.position.x;
        else
            return enemy.position.x > rightEdge.position.x;
    }

    private void Update()
    {

        if (!CanMove)
        {
            anim.SetBool("Run", false);
            return;
        }

        if (movingLeft)
        {
            if (enemy.position.x >= leftEdge.position.x)
                MoveDir(-1);
            else
            {
                DirChange();
            }
        }
        else
        {
            if (enemy.position.x <= rightEdge.position.x)
                MoveDir(1);
            else
            {
                DirChange();
            }
        }
    }

    private void DirChange()
    {
        anim.SetBool("Run", false);

        idleTimer += Time.deltaTime;

        if (idleTimer > idleDuration)
            movingLeft = !movingLeft;
    }

    private void MoveDir(int _dir)
    {
        idleTimer = 0;
        anim.SetBool("Run", true);

        enemy.localScale = new Vector3(Mathf.Abs(initScale.x) * _dir, initScale.y, initScale.z);

        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * _dir * speed, enemy.position.y, enemy.position.z);
    } 
}
