using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A04_cc5341
{

    public class GeneratePerson : MonoBehaviour
    {
        public GameObject[] torsos;
        public GameObject[] heads;
        public GameObject[] legs;


        GameObject torso, head,l_leg, r_leg;

        public float torso_size;
        public float head_size;
        public float legs_size;

        // Use this for initialization
        void Start()
        {
            torso = Instantiate(torsos[Random.Range(0, torsos.Length)]);
            head = Instantiate(heads[Random.Range(0, heads.Length)]);
            l_leg = Instantiate(legs[Random.Range(0, legs.Length)]);
            r_leg = Instantiate(l_leg);

            torso.transform.localScale = new Vector3(torso_size,torso_size,torso_size);
            head.transform.localScale = new Vector3(head_size, head_size, head_size);
            l_leg.transform.localScale = new Vector3(legs_size, legs_size, legs_size);
                    
                        
            head.transform.localPosition = new Vector3(0, 2.9f, 7.8f);
            torso.transform.localPosition = new Vector3(0, 2.0f, 7.9f);
            l_leg.transform.localPosition = new Vector3(-0.2f, 0.75f, 8f);
            r_leg.transform.localPosition = new Vector3(0.2f, 0.75f, 8f);

            r_leg.transform.localScale = new Vector3(-1f * l_leg.transform.localScale.x, l_leg.transform.localScale.y, l_leg.transform.localScale.z);
        }
    }
}