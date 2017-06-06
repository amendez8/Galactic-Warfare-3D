using UnityEngine;
using System.Collections;

public class BossShoot : MonoBehaviour {

    public float shootingRate;
    public float laserSpeed;
    public GameObject enemyLaser;
    public AudioClip laserSound;
    private bool inPosition;
    Boss boss;

    // Use this for initialization
    void Start () {
        boss = GameObject.Find("Boss").GetComponent<Boss>();
	}
	
	// Update is called once per frame
	void Update () {
        inPosition = boss.GetInPosition();
        float prob = Time.deltaTime * shootingRate; // probability used to determine shooting rate
        if (inPosition == true)
        {
            if (Random.value < prob)                    // works between 0 and 1
                Shoot();
        }
    }

    void Shoot()
    {
        Vector3 startingPosition = transform.position + new Vector3(0.0f, 1.0f, -8.0f);
        GameObject laser = Instantiate(enemyLaser, startingPosition, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -laserSpeed);
        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }
}
