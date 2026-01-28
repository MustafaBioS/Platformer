using UnityEngine;

public class CamLimit : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;
    public float minX = -10f;

    Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (!player) return;

        Vector3 targetPos = player.position + offset;

        float camHalfWidth = cam.orthographicSize * cam.aspect;

        targetPos.x = Mathf.Max(targetPos.x, minX + camHalfWidth);

        transform.position = targetPos;
    }
}
