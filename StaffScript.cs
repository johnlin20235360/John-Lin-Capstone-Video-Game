using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffScript : MonoBehaviour
{
    public Transform player;
    public Transform cam;
    public float teleportRange = 10f;
    public Animator staffAnimator;
    public LayerMask whatIsGround;
    public GameObject indicationPointPrefab;
    public float teleportCooldown = 5f;

    private bool isStaffDrawn = false;
    private GameObject indicationPoint;
    private bool isTeleporting = false;
    private bool isCooldown = false;
    private float cooldownTimer = 0f;

    private void Start()
    {
        // Instantiate the indication point
        indicationPoint = Instantiate(indicationPointPrefab);
        indicationPoint.SetActive(false);
    }

    private void Update()
    {
        // Check if the staff is in the staffdrawn state
        isStaffDrawn = staffAnimator.GetCurrentAnimatorStateInfo(0).IsName("StaffDrawn");

        // Shoot a raycast from the staff's position forward
        if (isStaffDrawn && !isCooldown && Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, teleportRange, whatIsGround))
        {
            // Update the indication point position
            indicationPoint.transform.position = hit.point;
            indicationPoint.SetActive(true);

            // Check if the left mouse button is pressed
            if (Input.GetMouseButtonDown(0))
            {
                // Teleport the player to the hit point
                player.position = hit.point;
                isTeleporting = true;
                isCooldown = true;
                cooldownTimer = teleportCooldown;
            }
        }
        else
        {
            indicationPoint.SetActive(false);
        }

        // Cooldown timer
        if (isCooldown)
        {
            cooldownTimer -= Time.deltaTime;
            if (cooldownTimer <= 0)
            {
                cooldownTimer = 0;
                isCooldown = false;
            }
        }

    }
}







