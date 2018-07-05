using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_player_with_acceleration : MonoBehaviour {
    
	// Use this for initialization
	void Start () {
        rb = transform.GetComponent<Rigidbody>();
        decelerateAmount = movementSpeed*20;
	}

    bool moving = false;
    public float movementSpeed = 2f;
    // Update is called once per frame

    Rigidbody rb;
    bool decelerate = false;
    float decelerateAmount = 2f;
	void Update () {
		
        if(Input.GetMouseButton(0)){
            moving = true;
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            transform.position += forward * Time.deltaTime * movementSpeed;
        }
        if (moving && !Input.GetMouseButton(0))
        {

            // rb.AddForce(-(Camera.main.transform.forward) * Time.deltaTime * movementSpeed);
            moving = false;
            decelerate = true;
        }

        if (decelerate)
        {
            Vector3 forward = Camera.main.transform.forward;
            forward.y = 0;
            transform.position += forward * Time.deltaTime * (decelerateAmount/20);
           
            if (decelerateAmount == 0f) {
                decelerate = false;
                decelerateAmount = movementSpeed*20;
            }
            decelerateAmount -= 1f;
        }




	}
}
