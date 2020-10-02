using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    public Vector3 velocity = Vector3.zero;

    public float smoothSpeed = 0.125f;

    public float offsetForward;

    public float height;

    private void Update()
    {
        Vector3 pos = new Vector3();
        pos.x = target.position.x;
        pos.z = target.position.z - offsetForward;
        pos.y = target.position.y + height;
        transform.position = Vector3.SmoothDamp(transform.position, pos, ref velocity, smoothSpeed);
        //transform.LookAt(target);
    }
}
