using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public float shipSpeed;
    public float laserSpeed;
    public float rateOfFire;
    public GameObject laser;
    public GameObject explosion;
    public AudioClip laserSound;
    public GameObject loseCanvas;
    public AudioClip explosionSound;
    private int bullets = 1;
    GameObject laserBeam1;
    GameObject laserBeam2;
    GameObject laserBeam3;
	// Use this for initialization
	void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {

        //clamp ship to screen
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(transform.position.y, -10f, 70f);
        pos.x = Mathf.Clamp(transform.position.x, -20f, 75.0f);
        transform.position = pos;

        // ship movements
        if (Input.GetKey("d"))
            transform.position += Vector3.right * shipSpeed * Time.deltaTime;
        if (Input.GetKey("a"))
            transform.position += Vector3.left * shipSpeed * Time.deltaTime;
        if (Input.GetKey("w"))
            transform.position += Vector3.up * shipSpeed * Time.deltaTime;
        if (Input.GetKey("s"))
            transform.position += Vector3.down * shipSpeed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
            InvokeRepeating("Shoot", 0.00001f, rateOfFire);

        // hits floor
        if(transform.position.y <= 1)
        {
            Destroy(gameObject);
            GameObject deathExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
            Destroy(deathExplosion, 1.0f);
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
            loseCanvas.SetActive(true);
        }

    }

    public void Shoot()
    {
        if (bullets == 1)
        {
            Vector3 startingPosition = transform.position + new Vector3(0.0f, 0.0f, 8.0f);       // making sure laser is ahead of ship
            laserBeam1 = Instantiate(laser, startingPosition, Quaternion.identity) as GameObject; // instantiate laser to ship
            laserBeam1.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        }
        if(bullets == 2)
        {
            Vector3 leftLaser = transform.position + new Vector3(-5.0f, 0.0f, 3.5f);       // making sure laser is ahead of ship
            Vector3 rightLaser = transform.position + new Vector3(5.0f, 0.0f, 3.5f);
            laserBeam1 = Instantiate(laser, leftLaser, Quaternion.identity) as GameObject; // instantiate laser to ship
            laserBeam2 = Instantiate(laser, rightLaser, Quaternion.identity) as GameObject;
            laserBeam1.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            laserBeam2.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        }
        if(bullets == 3)
        {
            Vector3 middleLaser = transform.position + new Vector3(0.0f, 0.0f, 8.0f);
            Vector3 leftLaser = transform.position + new Vector3(-5.0f, 0.0f, 3.5f);       // making sure laser is ahead of ship
            Vector3 rightLaser = transform.position + new Vector3(5.0f, 0.0f, 3.5f);
            laserBeam1 = Instantiate(laser, middleLaser, Quaternion.identity) as GameObject; // instantiate laser to ship
            laserBeam2 = Instantiate(laser, leftLaser, Quaternion.identity) as GameObject;
            laserBeam3 = Instantiate(laser, rightLaser, Quaternion.identity) as GameObject;
            laserBeam1.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            laserBeam2.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            laserBeam3.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, laserSpeed);
            AudioSource.PlayClipAtPoint(laserSound, transform.position);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        EnemyLaser laser = collider.gameObject.GetComponent<EnemyLaser>();
        Upgrade upgrade = collider.gameObject.GetComponent<Upgrade>();
        if (laser)
        {
            bullets--;
            if (bullets == 0)
            {
                Destroy(gameObject);
                GameObject deathExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
                Destroy(deathExplosion, 1.0f);
                AudioSource.PlayClipAtPoint(explosionSound, transform.position);
                loseCanvas.SetActive(true);
            }
        }
        if (upgrade)
        {
            if(bullets < 3)
                bullets++;
        }
    }

    public int numOfBullets()
    {
        return bullets;
    }
}
