using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour
{

    [Header ("Health")]
    [SerializeField] private float startingHealth = 3;
    public float currentHealth { get; private set; }
    private Animator anim;

    [Header ("iFrames")]
    [SerializeField] private float invincibleDuration;
    [SerializeField] private int flashNum;
    private SpriteRenderer spriteRend;


    void Awake()
    {
        currentHealth = startingHealth;
        anim = GetComponent<Animator>();
        spriteRend = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(float _damage)
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

    private IEnumerator Invincible()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < flashNum; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(invincibleDuration / (flashNum * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(invincibleDuration / (flashNum * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, true);
        
    }
}
