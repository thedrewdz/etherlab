using UnityEngine;

public class SimpleFollowCam : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, 0f);
    public float followSpeed = 8f;
    public float rotateSpeed = 180f;

    void LateUpdate()
    {
        if (!target) return;

        // Rotate player with mouse X
        float mouseX = Input.GetAxis("Mouse X");
        target.Rotate(Vector3.up, mouseX * rotateSpeed * Time.deltaTime);

        // Follow behind the player
        Vector3 desiredPos = target.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, desiredPos, followSpeed * Time.deltaTime);

        // Look at chest/head area
        Vector3 lookPos = target.position + Vector3.up * 1.3f;
        transform.rotation = Quaternion.LookRotation(lookPos - transform.position, Vector3.up);
    }
}
