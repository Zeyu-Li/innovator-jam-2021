using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 14f;

    // gravity
    public float gravity = -10f;
    Vector3 velocity;

    // slope
    public bool isSliding = false;
    public float slopeLimit = 35f;
    private Vector3 slopeParallel;

    public GameObject robot;

    // Update is called once per frame
    void Update()
    {

        float x = -Input.GetAxis("Horizontal");
        float z = -Input.GetAxis("Vertical");

        // get one of 8 position rotations
        if (x == 0 && z == 0) {
            // do nothing
            ;
        } else if (x == 0) {
            if (z > 0) {
                robot.transform.rotation = Quaternion.Euler(0, -45, 0);
            } else {
                robot.transform.rotation = Quaternion.Euler(0, 135, 0);
            }
        } else if (z == 0) {
            if (x > 0) {
                robot.transform.rotation = Quaternion.Euler(0, 45, 0);
            } else {
                robot.transform.rotation = Quaternion.Euler(0, 225, 0);
            }
        } else {
            if (x > 0) {
                if (z > 0) {
                    robot.transform.rotation = Quaternion.Euler(0, 0, 0);
                } else {
                    robot.transform.rotation = Quaternion.Euler(0, 90, 0);
                }
            } else {
                if (z > 0) {
                    robot.transform.rotation = Quaternion.Euler(0, 270, 0);
                } else {
                    robot.transform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }

        // debug
        // if (!(x == 0 && z == 0))
        //     Debug.Log(robot.transform.rotation);

        // stop from going faster diagonally
        if (x != 0f && z != 0f) {
            x *= 0.707f;
            z *= 0.707f;
        }

        // float x = (float)(-Input.GetAxis("Horizontal") * 0.5 - Input.GetAxis("Vertical") * 0.5);
        // float z = (float)(-Input.GetAxis("Vertical") * 0.5 - Input.GetAxis("Vertical") * 0.5);

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*movementSpeed*Time.deltaTime);

        // slopes, modified from https://answers.unity.com/questions/1502223/sliding-down-a-slope-with-a-character-controller.html
        RaycastHit hit;
        Physics.Raycast(transform.position, Vector3.down, out hit);
        // Saving the normal
        Vector3 n = hit.normal;

        // Crossing my normal with the player's up vector (if your player rotates I guess you can just use Vector3.up to create a vector parallel to the ground
        Vector3 groundParallel = Vector3.Cross(transform.up, n);

        // Crossing the vector we made before with the initial normal gives us a vector that is parallel to the slope and always pointing down
        slopeParallel = Vector3.Cross(groundParallel, n);
        Debug.DrawRay(hit.point, slopeParallel * 10, Color.green);

        // Just the current angle we're standing on
        float currentSlope = Mathf.Round(Vector3.Angle(hit.normal, transform.up));

        // If the slope is on a slope too steep and the player is Grounded the player is pushed down the slope.
        if (currentSlope >= slopeLimit) {
            isSliding = true;
        }
        // If the player is standing on a slope that isn't too steep, is grounded, as is not sliding anymore we start a function to count time
        else if (currentSlope < slopeLimit && isSliding) {
            isSliding = false;
        }

        if (isSliding) {
            controller.Move(slopeParallel.normalized / 2 * Time.deltaTime);
        }

        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
