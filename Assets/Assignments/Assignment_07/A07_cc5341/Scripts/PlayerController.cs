using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
        if (!isLocalPlayer)
        {
            return;
        }
        Vector3 cameraPos = new Vector3(transform.position.x, 0.5f, transform.position.z);
        cameraPos = cameraPos + (transform.forward / 2f);
        Camera.main.transform.position = cameraPos;
        Vector3 cameraRot = Camera.main.transform.eulerAngles;
        cameraRot.x = 0;
        transform.eulerAngles = cameraRot;
        //Change to key press, only forward movement
        if (Input.GetMouseButton(0))
        {
            Vector3 forward = transform.forward;
            forward.y = 0;
            transform.position += forward * Time.deltaTime;
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
