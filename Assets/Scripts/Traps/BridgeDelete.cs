using UnityEngine;

public class BridgeDelete : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    [SerializeField] GameObject bridge;
    [SerializeField] PlayerMovement player;

    void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.enabled = false;
            Destroy(bridge, 0.5f);
            Debug.Log("Delete");
        }
    }
}
