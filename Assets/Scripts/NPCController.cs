using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.XR.ARFoundation;

public class NPCController : MonoBehaviour
{
    private Logger logger;
    public static int POINTS = 0; // Static variable to store the points
    public float timeSpawn = 3f; // NPC spawn period
    private float nextSpawn; // Time to spawn the next NPC
    public float xRangeCoord = 20f; // Range of x coordinate to spawn the NPC
    public float yDisplacement = 0.0f;
    public float zDisplacement = 0.0f;
    public bool generateNPCs = true;
    [Range(0, 100)]
    public int enemyRate = 50; // Rate of enemy spawn
    public GameObject PrefabEnemy; // Prefab of the enemy NPC
    public GameObject PrefabAlly; // Prefab of the ally NPC
    private ARPlaneManager arPlaneManager;

    void Start()
    {
        logger = FindObjectOfType<Logger>();
        // Set the time to spawn the next NPC
        nextSpawn = Time.time + timeSpawn;
        arPlaneManager = FindObjectOfType<ARPlaneManager>();
    }

    void Update() {
        // Check if it is time to spawn the next NPC. If so, spawn the NPC and set the time to the next one
        if(Time.time > nextSpawn && generateNPCs) {
            SpawnAndDespawn();
            nextSpawn = Time.time + timeSpawn;
        }
    }

    public void SpawnAndDespawn(){
        if (arPlaneManager == null || arPlaneManager.trackables.count == 0)
        {
            Debug.LogWarning("No planes detected to spawn NPCs.");
            logger.Log("No planes detected to spawn NPCs.");
            return;
        }

        // set x position randomly for spawning the NPC and create the new location
        float xPos = UnityEngine.Random.Range(-xRangeCoord, xRangeCoord);
        Vector3 newLocation = new Vector3(transform.position.x + xPos, transform.position.y + yDisplacement, transform.position.z + zDisplacement);

        // Filter only horizontal planes
        List<ARPlane> horizontalPlanes = new List<ARPlane>();
        foreach (var plane in arPlaneManager.trackables)
        {
            if (plane.alignment == UnityEngine.XR.ARSubsystems.PlaneAlignment.HorizontalUp)
            {
                horizontalPlanes.Add(plane);
            }
        }

        if (horizontalPlanes.Count == 0)
        {
            Debug.LogWarning("No horizontal planes detected for spawning NPCs.");
            return;
        }

        // Get a random horizontal plane
        ARPlane selectedPlane = horizontalPlanes[UnityEngine.Random.Range(0, horizontalPlanes.Count)];

        // Generate a random position within the bounds of the selected plane
        Vector3 randomPoint = GetRandomPointOnPlane(selectedPlane);

        // Instantiate the NPC and destroy it after 3 seconds. Randomizing if it is an enemy or an ally
        GameObject NPC = null;
        bool isEnemy = UnityEngine.Random.Range(0, 100) <= enemyRate;
        logger.Log("New NPC created!");
        if (isEnemy) { 
            NPC = Instantiate(PrefabEnemy, randomPoint, Quaternion.identity);
            logger.Log("This NPC is an enemy");
        }
        else { 
            NPC = Instantiate(PrefabAlly, randomPoint, Quaternion.identity);
            logger.Log("This NPC is an ally");
        }
        Destroy(NPC, 3f);
        logger.Log("NPC destroyed!");
    }

    private Vector3 GetRandomPointOnPlane(ARPlane plane)
    {
        // Get the plane's center and size
        Vector3 planeCenter = plane.transform.position;
        Vector2 planeSize = plane.size;

        // Generate a random position within the plane's bounds
        float randomX = UnityEngine.Random.Range(-planeSize.x / 2, planeSize.x / 2);
        float randomZ = UnityEngine.Random.Range(-planeSize.y / 2, planeSize.y / 2);

        // Return the random point in world space
        return planeCenter + plane.transform.right * randomX + plane.transform.forward * randomZ;
    }

    public void stopGenerating()
    {
        this.generateNPCs = false;
    }

}
