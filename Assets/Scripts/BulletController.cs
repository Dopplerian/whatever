using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BulletController : MonoBehaviour
{

    private Logger logger;
    // Start is called before the first frame update
    void Start()
    {
        logger = FindObjectOfType<Logger>();
        // Destroy the bullet after 3 seconds if it doesn't hit anything
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        logger.Log("NPC shot by the player!");
        // Check if the bullet hit an enemy or ally, and update the score accordingly.
        var whois = collision.gameObject.tag;
        if (whois == "Enemy")
        { // If the bullet hits an enemy, add 1 to the score.
            Scoring(1);
            Destroy(collision.gameObject);
        }
        else if (whois == "Ally")
        { // If the bullet hits an ally, subtract 1 to the score.
            Scoring(-1);
            Destroy(collision.gameObject);
        }
        else if (whois == "Env")
        {
            logger.Log("Environment shot");
        }
        // If the bullet hits anything else, log it.
        else
        {
            logger.Log("Unknown object: " + whois);
        }
        // Destroy the bullet and the object it hit.   
        Destroy(gameObject);
    }

    void Scoring(int score)
    {
        // Update the global score and print it in the UI.
        NPCController.POINTS += score;
        string Score = "Score: " + (NPCController.POINTS);
        GameObject.FindWithTag("UI").GetComponent<TMP_Text>().text = Score;
        // Find the game object with an UI tag, access to its text component and update the content.
        logger.Log("Score updated to: " + NPCController.POINTS);
    }
}
