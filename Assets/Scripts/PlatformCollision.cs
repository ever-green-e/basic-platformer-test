using UnityEngine;

public class PlatformCollision : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";

    // Drag the PHYSICAL spinner part here (mesh / collider / child)
    [SerializeField] Transform platform;

    private Transform platformRoot;

    void Awake()
    {
        // Go one level higher than the dragged object
        platformRoot = platform.parent;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        other.transform.SetParent(platformRoot, true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag)) return;

        other.transform.SetParent(null, true);
    }
}
