using UnityEngine;
using System.Collections;

public class BossShootFollow : MonoBehaviour {

    public float shootingRate;
    public float laserSpeed;
    public GameObject enemyLaser;
    public AudioClip laserSound;

    PlayerController player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        float prob = Time.deltaTime * shootingRate; // probability used to determine shooting rate
        if (Random.value < prob)                    // works between 0 and 1
            Shoot();

        if (player == null) // prevents game from crashing when player is destroyed
        {
            Destroy(gameObject);
        }
    }

    void Shoot()
    {

        if (player != null)
        {
            GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
            Vector3 direction = player.transform.position - transform.position;
            laser.GetComponent<Rigidbody>().velocity = direction * (-laserSpeed);
            Debug.Log("Shooting following Laser");
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        }
    }
}
