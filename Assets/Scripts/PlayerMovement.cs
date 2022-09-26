using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //Holds static data for player
    [SerializeField] private Transform trans;
    [SerializeField] private Rigidbody rb;

    //Holds max character speed and Satisfaction Radius
    private float maxSpeed;
    private float satRadius;

    //Camera and Click Target 
    public Camera camera;
    public Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        //Max movement speed and the radius of satisfaction
        maxSpeed = 6f;
        satRadius = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        //Detects left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            //Creates target at pixel position and translates it to world point
            target = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        
        //Calculate vector from player to target
        Vector3 towards = target - trans.position;
        //Adjust rotation of character towards target
        trans.rotation = Quaternion.LookRotation(target);

        //if player has not reached the targeted spot aka satisfaction radius
        if (towards.magnitude > satRadius)
        {
            //Normalize vector for direction
            towards.Normalize();
            towards *= maxSpeed;

            //Move player towards target
            rb.velocity = towards;
        }
    }
}
