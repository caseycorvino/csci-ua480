using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace A04_cc5341
{
    public class move_player_with_acceleration : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            rb = transform.GetComponent<Rigidbody>();


        }

        bool moving = false;
        public float movementSpeed = 2f;
        // Update is called once per frame

        Rigidbody rb;
        bool decelerate = false;
        bool accelerate = false;
        float decelerateAmount = 0f;
        float accelerateAmount = 0f;
        float headY = 0f;
        void Update()
        {

            if (Input.GetMouseButton(0))
            {

                //start walking
                if (accelerate == false && moving == false)//and no ray cast
                {
                    accelerate = true;
                    moving = true;
                   
                    //then accelerate
                }
                else if (accelerate == true)
                {
                   
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = Mathf.Sin(headY + Time.time * 8) / 5;
                    transform.position += forward * Time.deltaTime * (accelerateAmount / 100);

                    if (accelerateAmount >= 200f)
                    {
                        accelerate = false;
                        accelerateAmount = 0f;
                    }
                    accelerateAmount += 1f;
                    //then move normally 
                    decelerateAmount += 1f;
                }
                else
                {
                   
                    moving = true;
                    Vector3 forward = Camera.main.transform.forward;
                    forward.y = Mathf.Sin(headY + Time.time * 8) / 5;
                    transform.position += forward * Time.deltaTime * movementSpeed;
                }

            }

            //stop clicking
            if (moving && !Input.GetMouseButton(0))
            {

                // rb.AddForce(-(Camera.main.transform.forward) * Time.deltaTime * movementSpeed);
                moving = false;
                decelerate = true;
            }

            //decelerate when done
            if (decelerate)
            {
                
                Vector3 forward = Camera.main.transform.forward;
                forward.y = Mathf.Sin(headY + Time.time * 8) / 5;
                transform.position += forward * Time.deltaTime * (decelerateAmount / 100);

                if (decelerateAmount <= 0f)
                {
                    decelerate = false;
                    decelerateAmount = 0f;
                }
                decelerateAmount -= 1f;
            }
            //stop accelerating
            if (!Input.GetMouseButton(0))
            {
                accelerate = false;
                accelerateAmount = 0f;
            }



        }
    }
}