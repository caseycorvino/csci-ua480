using UnityEngine;
using UnityEngine.Networking;

public class EnemyController : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    private float interval = 1f;
    private float timeToRotate = 0.0f;

    public float walk_range = 5f;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 forward = transform.forward;

       if (Time.time > timeToRotate){
            if (transform.position.x > walk_range || transform.position.z > walk_range || 
                transform.position.z < -walk_range || transform.position.x < -walk_range)
            {
                transform.Rotate(0, 180, 0);
                timeToRotate += interval;
            } else {
                timeToRotate += interval;
                transform.Rotate(0, Random.Range(-90, 90), 0);
            }
        }
        transform.position += forward * Time.deltaTime;
	}
    void CmdFire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

        NetworkServer.Spawn(bullet);

        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);
    }
}
