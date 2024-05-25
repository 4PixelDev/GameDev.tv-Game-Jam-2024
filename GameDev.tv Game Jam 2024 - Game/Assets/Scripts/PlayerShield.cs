using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerShield : MonoBehaviour
{
    [SerializeField] private Transform shieldTransform;
    [SerializeField] private float shieldDistance;

    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        // Cache the main camera
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse position in the game world
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the direction from the player to the mouse
        Vector3 mouseDirection = mousePos - transform.position;

        // Calculate the angle in degrees
        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;

        // Rotate the shield to face the mouse direction
        shieldTransform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Calculate the new position for the shield
        Vector3 shieldOffset = Quaternion.Euler(0, 0, angle) * new Vector3(shieldDistance, 0, 0);
        shieldTransform.position = transform.position + shieldOffset;
    }
}
