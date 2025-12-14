using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;
    public float dashDuration = 0.2f;
    public float dashCooldown = 1f;
    public Transform cameraTransform;
    
    private CharacterController controller;
    private bool isDashing = false;
    private bool canDash = true;
    private Vector3 dashDirection;
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canDash && !isDashing)
        {
            StartCoroutine(Dash());
        }
        
        if (isDashing)
        {
            controller.Move(dashDirection * dashSpeed * Time.deltaTime);
        }
    }
    
    IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        
        // Get camera forward, ignore Y
        dashDirection = cameraTransform.forward;
        dashDirection.y = 0;
        dashDirection.Normalize();
        
        yield return new WaitForSeconds(dashDuration);
        
        isDashing = false;
        
        yield return new WaitForSeconds(dashCooldown);
        
        canDash = true;
    }
}