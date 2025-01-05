using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Logger : MonoBehaviour
{
    private string logFilePath;

    void Start()
    {
        // Define the path for the log file
        logFilePath = Application.persistentDataPath + "/log.txt";

        // Optional: Clear or initialize the log file at the start
        File.WriteAllText(logFilePath, "Log Initialized: " + System.DateTime.Now + "\n");
        Debug.Log("Logging to: " + logFilePath);
    }

    public void Log(string message)
    {
        // Add a timestamp to each log entry
        string logEntry = $"{System.DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}\n";

        // Append the log entry to the file
        File.AppendAllText(logFilePath, logEntry);

        // Optionally, display the log in Unity's console for debugging
        Debug.Log(logEntry);
    }
}
