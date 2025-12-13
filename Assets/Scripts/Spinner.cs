using UnityEngine;

public class Spinner : MonoBehaviour
{
    public Vector3 rotationspeed = new Vector3(0, 90, 0); //degrees per second

    void Update()
    {
        transform.Rotate(rotationspeed * Time.deltaTime);
    }
}
