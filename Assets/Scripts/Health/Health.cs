using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 3;
    public float currentHealth { get; private set; }
    private Animator anim;


    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
    }

    void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            anim.SetTrigger("Hurt");
        }
        else
        {
            anim.SetTrigger("Die");
        }
    }
}
