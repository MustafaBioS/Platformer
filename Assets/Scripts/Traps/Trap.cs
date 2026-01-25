using UnityEngine;

public class Trap : MonoBehaviour
{

    [SerializeField] GameObject player;
    private Animator anim;
    [SerializeField] private float damage;
    private Health health;

    void Awake()
    {
        anim = player.GetComponent<Animator>();
        health = player.GetComponent<Health>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetTrigger("Die");
            health.TakeDamage(damage);
            Debug.Log("Anim Playing");
        }
    }
}
