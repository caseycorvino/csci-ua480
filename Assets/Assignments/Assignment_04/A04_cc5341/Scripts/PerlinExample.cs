using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace A04_cc5341
{

    public class PerlinExample : MonoBehaviour
    {
        public float scale = 100.25f;
        public GameObject wall;
        List<GameObject> walls;
        // Use this for initialization
        void Start()
        {
           
            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(i, 0, 10);
                newWall.transform.localScale = new Vector3(1,perlin, 1);
            }

            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(10, 0, i);
                newWall.transform.localScale = new Vector3(1, perlin, 1);
            }

            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(-10, 0, i);
                newWall.transform.localScale = new Vector3(1, perlin, 1);
            }

            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;

                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(i, 0, -10);
                newWall.transform.localScale = new Vector3(1, perlin, 1);
            }
        }

       
    }
}