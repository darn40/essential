using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

// Controls Movements and Behaviors
public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Set player's movement speed.
    public float rotationSpeed = 120.0f; // Set player's rotation speed.

    private Rigidbody rb; // Reference to player's Rigidbody

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Access player's Rigibody
    }

    // Update is called once per frame
    void Update()
    {
        // Used for regular updates such as : timer, log, receive input, actions(shoot), animations 
        // called per frame --> independant of time

        // Debug.Log("Update time :" + Time.deltaTime);
    }

    // Handle physics-based movement and rotation
    private void FixedUpdate()
    {
        // Used for updating things such as : forces, torques, or other physics-related functions, (EX: physics consequences of an action)
        // = -Update -- > dependant of time (variation of physics value along the time) (called every deltaTime)
        //Move player based on vertical input. 
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = moveVertical * speed * Time.fixedDeltaTime * transform.forward;
        rb.MovePosition(rb.position + movement);

        // Rotate player based on horizontal input.
        float turn = Input.GetAxis("Horizontal") * rotationSpeed * (rotationSpeed / speed) * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        // Debug.Log("FixedUpdate time :" + Time.deltaTime);
    }
}
