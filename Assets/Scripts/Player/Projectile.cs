using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;
    private float direction;
    private bool hit;

    [SerializeField] float fallDelay = 0.5f;
    [SerializeField] float lifeTime = 3f;

    [SerializeField] AudioSource hitSFX;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    
    [SerializeField] private float minPitch = 0.6f;
    [SerializeField] private float maxPitch = 2f;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitSFX.pitch = Random.Range(minPitch, maxPitch);
        hit = true;
        boxCollider.enabled = false;
        hitSFX.Play();
    }

    public void Fire(float _direction)
    {
        direction = _direction;

        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
        {
            localScaleX = -localScaleX;
        }
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);

        rb.gravityScale = 0;
        rb.angularDamping = 0f;

        StopAllCoroutines();
        StartCoroutine(ArrowFall());
        StartCoroutine(Deactivate());

    }

    IEnumerator ArrowFall()
    {
        yield return new WaitForSeconds(fallDelay);
        rb.gravityScale = 0.2f;
        rb.angularDamping = 2f;
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(lifeTime);
        gameObject.SetActive(false);
    }

}
