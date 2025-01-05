using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;
using UnityEngine.XR.Interaction.Toolkit.Samples;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class BulletSpawner : MonoBehaviour
{
    public float bulletSpeed = 10.0f; // Speed factor of the bullet
    [SerializeField]
    Camera m_CameraToFace;
    public Camera cameraToFace
    {
        get
        {
            EnsureFacingCamera();
            return m_CameraToFace;
        }
        set => m_CameraToFace = value;
    }
    [SerializeField]
    public GameObject m_BulletPrefab;

    void Awake()
    {
        EnsureFacingCamera();
    }
    void EnsureFacingCamera()
    {
        if (m_CameraToFace == null)
            m_CameraToFace = Camera.main;
    }

    public void Shoot()
    {
        EnsureFacingCamera();
        var bullet = Instantiate(m_BulletPrefab);
        bullet.transform.position = m_CameraToFace.transform.position;
        bullet.transform.rotation = m_CameraToFace.transform.rotation;
        bullet.transform.position += 0.25f * bullet.transform.forward;
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
    }
}
