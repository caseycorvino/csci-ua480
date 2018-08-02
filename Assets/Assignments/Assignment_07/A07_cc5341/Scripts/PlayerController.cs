using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    private float last_click = 0;
    public float double_click_interval = 0.2f;
    private GameObject camController = GameObject.Find("camera controller");

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }

        Vector3 cameraPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        cameraPos = cameraPos + (transform.forward / 2f);
        camController.transform.position = cameraPos;
        Vector3 cameraRot = Camera.main.transform.eulerAngles;
        cameraRot.x = 0;
        transform.eulerAngles = cameraRot;
        //Change to key press, only forward movement
        if (Input.GetMouseButton(0))
        {
            //last_click = Time.time;
            if (Time.time - last_click <= double_click_interval && Time.time - last_click > 0.1f)
            {
                CmdFire();
            }
            else
            {
                Vector3 forward = transform.forward;
                forward.y = 0;
                transform.position += forward * Time.deltaTime;
            }
            last_click = Time.time;
        }
    }

    [Command]
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
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
