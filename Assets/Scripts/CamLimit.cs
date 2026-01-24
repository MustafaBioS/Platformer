using UnityEngine;

public class CameraFollowWithLimit : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float minX = -10f;

    void Start()
    {
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (!player) return;

        Vector3 targetPos = player.position + offset;

        targetPos.x = Mathf.Max(targetPos.x, minX);

        transform.position = targetPos;
    }
}
