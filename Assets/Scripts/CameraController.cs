using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector2 rotation; // vector for manage rotation
    public float speedRotation = 100.0f; // speed factor for rotation
    public float speedMovement = 20.0f; // speed factor for movement
    public float speedBonus = 3.0f; // speed factor for shift
    void Start()
    {
        // Lock the cursor at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the mouse movement and set the rotation vector
        rotation.x += Input.GetAxis("Mouse X") * speedRotation * Time.deltaTime;
        rotation.y += Input.GetAxis("Mouse Y")  * speedRotation * Time.deltaTime;
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);
        // Set the rotation of the camera with the new vector
        transform.localRotation = Quaternion.Euler(-rotation.y, rotation.x, 0);

        Vector3 mov = new Vector3();
        // This could be better but I'm tired
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            mov += Vector3.forward;
        if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            mov += Vector3.back;
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            mov += Vector3.left;
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            mov += Vector3.right;
        if(Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift))
            mov *= speedBonus;

        mov *= speedMovement * Time.deltaTime;
        mov = Quaternion.Euler(0, rotation.x, 0) * mov;
        transform.Translate(mov, Space.World);
    }
}
