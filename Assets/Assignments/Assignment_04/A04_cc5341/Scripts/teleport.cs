using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace A04_cc5341
{
    [RequireComponent(typeof(Collider))]
    public class teleport : MonoBehaviour, IPointerClickHandler
    {
        
        private Collider _collider;

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            float c = eventData.pointerPressRaycast.distance;//raycast to hit
            float a = 1; // height of player
            float b = Mathf.Sqrt(Mathf.Pow(c, 2) - a);//distace forward to hit from floor
            if (b <= 10)
            {
                Vector3 forward = Camera.main.transform.forward;
                forward.y = 0;

                GameObject.Find("Player").transform.position += forward * b;//need to change
            }
        }


        //used your code
        private void OnTriggerEnter(Collider other)
        {
            //Disable the collision detection on this collider when the camera is inside of it, so the casting ray won't be blocked by it.
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = true;
            }
        }

        //used your code
        private void OnTriggerExit(Collider other)
        {
            //Re-enable the collision detection when camera exits the collider
            if (other.CompareTag("MainCamera"))
            {
                _collider.isTrigger = false;
            }
        }
    }
}
