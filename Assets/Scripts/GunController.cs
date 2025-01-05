using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class GunController : MonoBehaviour
{
    public Transform bulletSpawnPoint; // Postion where the bullet will be spawned
    public GameObject bulletPrefab;
    public float bulletSpeed = 100.0f; // Speed factor of the bullet

    private ARRaycastManager rm;
    private ARPlaneManager pm;

    private void Awake()
    {
        rm = GetComponent<ARRaycastManager>();
        pm = GetComponent<ARPlaneManager>();
    }

    private void onEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += fingerDown;
    }

    private void fingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;
        
        var bullet = Instantiate(bulletPrefab); // Create a new bullet
        bullet.transform.position = bulletSpawnPoint.position; // Set the bullet position to the bulletSpawnPoint position
        bullet.transform.rotation = bulletSpawnPoint.rotation; // Set the bullet rotation to the bulletSpawnPoint rotation
        // Shoot the bullet by adding velocity to the rigigbody component of the bullet
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

    private void onDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= fingerDown;
    }

    void Update()
    {
        // Shoot();
    }
    public void Shoot()
    {
        // if the player press the space bar or left click, then shoot
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(bulletPrefab); // Create a new bullet
            bullet.transform.position = bulletSpawnPoint.position; // Set the bullet position to the bulletSpawnPoint position
            // Shoot the bullet by adding velocity to the rigigbody component of the bullet
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
        }
    }

}
