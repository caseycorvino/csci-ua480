using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*This script is attached to the wall Game Object*/
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
           
            // create front wall
            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(i, 0, 10);
                newWall.transform.localScale = new Vector3(1,perlin, 1);
            }

            //create left wall
            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(10, 0, i);
                newWall.transform.localScale = new Vector3(1, perlin, 1);
            }

            //create back wall
            for (float i = -10; i <= 10; i++)
            {

                float perlin = Mathf.PerlinNoise(i * scale, 20f * scale) * 10;
               
                GameObject newWall = Instantiate(wall);
                newWall.transform.position = new Vector3(-10, 0, i);
                newWall.transform.localScale = new Vector3(1, perlin, 1);
            }

            //CreateAssetMenuAttribute right wall

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