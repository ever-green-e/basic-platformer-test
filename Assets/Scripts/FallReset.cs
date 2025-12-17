using UnityEngine;

public class FallReset : MonoBehaviour
{
    public float fallY = -1f;
    public Transform respawnPoint;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (transform.position.y < fallY)
        {
            Respawn();
        }
    }

    void Respawn()
    {
        // Disable controller to safely teleport
        controller.enabled = false;
        transform.position = respawnPoint.position;
        transform.rotation = respawnPoint.rotation;
        controller.enabled = true;
    }
}
