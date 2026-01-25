using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCD;
    [SerializeField] private float arrowCD;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] arrows;

    [SerializeField] private AudioSource throwSFX;
    [SerializeField] private AudioSource attackSFX;

    [SerializeField] private float minPitch = 0.6f;
    [SerializeField] private float maxPitch = 2f;

    private Animator anim;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && cooldownTimer > attackCD && playerMovement.canAttack())
        {
            attackSFX.pitch = Random.Range(minPitch, maxPitch);
            attackSFX.Play();
            Attack();
            Debug.Log("Attack!");
        }


        else if (Input.GetMouseButtonDown(1) && cooldownTimer > arrowCD && playerMovement.canAttack())
        {
            throwSFX.pitch = Random.Range(minPitch, maxPitch);
            throwSFX.Play();
            FireArrow();
            Debug.Log("Fire!");
        }

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        cooldownTimer = 0;
    }

    private void FireArrow()
    {
        int index = FindArrow();
        GameObject arrow = arrows[index];

        arrow.transform.position = firePoint.position;
        arrow.SetActive(true);

        arrow.GetComponent<Projectile>().Fire(Mathf.Sign(transform.localScale.x));

        cooldownTimer = 0;
    }

    private int FindArrow()
    {
        for (int i = 0; i < arrows.Length; i++)
        {
            if (!arrows[i].activeInHierarchy)
            {
                return i;
            }
        }
        return 0;

    }
}