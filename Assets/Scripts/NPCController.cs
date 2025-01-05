using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

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

    void Start()
    {
        logger = FindObjectOfType<Logger>();
        // Set the time to spawn the next NPC
        nextSpawn = Time.time + timeSpawn;
    }

    void Update() {
        // Check if it is time to spawn the next NPC. If so, spawn the NPC and set the time to the next one
        if(Time.time > nextSpawn && generateNPCs) {
            SpawnAndDespawn();
            nextSpawn = Time.time + timeSpawn;
        }
    }

    public void SpawnAndDespawn(){
        // set x position randomly for spawning the NPC and create the new location
        float xPos = UnityEngine.Random.Range(-xRangeCoord, xRangeCoord);
        Vector3 newLocation = new Vector3(transform.position.x + xPos, transform.position.y + yDisplacement, transform.position.z + zDisplacement);

        // Instantiate the NPC and destroy it after 3 seconds. Randomizing if it is an enemy or an ally
        GameObject NPC = null;
        bool isEnemy = UnityEngine.Random.Range(0, 100) <= enemyRate;
        logger.Log("New NPC created!");
        if (isEnemy) { 
            NPC = Instantiate(PrefabEnemy, newLocation, Quaternion.identity);
            logger.Log("This NPC is an enemy");
        }
        else { 
            NPC = Instantiate(PrefabAlly, newLocation, Quaternion.identity);
            logger.Log("This NPC is an ally");
        }
        Destroy(NPC, 3f);
        logger.Log("NPC destroyed!");


    }

    public void stopGenerating()
    {
        this.generateNPCs = false;
    }

}
