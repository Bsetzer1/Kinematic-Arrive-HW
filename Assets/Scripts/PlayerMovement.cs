using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    //Holds static data for character
    [SerializeField] private Transform trans;
    [SerializeField] private Rigidbody rb;

    //Holds max character speed and Satisfaction Radius
    private float maxSpeed;
    private float satRadius;

    public Camera camera;
    public Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        maxSpeed = 6f;
        satRadius = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = camera.ScreenToWorldPoint(Input.mousePosition);
        }
        
        Vector3 towards = target - trans.position;
        trans.rotation = Quaternion.LookRotation(target);

        if (towards.magnitude > satRadius)
        {
            towards.Normalize();
            towards *= maxSpeed;

            rb.velocity = towards;
        }
    }
}
