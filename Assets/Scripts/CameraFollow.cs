using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Camera Movement")]
    [SerializeField] private Transform player;
    [SerializeField] private float speed;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float rotationSpeed;

    private Vector3 desiredPos;

    void Update()
    {
        // Update camera position
        desiredPos = player.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPos, speed * Time.deltaTime);

        // Update camera rotation
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
