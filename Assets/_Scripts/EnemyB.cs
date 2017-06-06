using UnityEngine;
using System.Collections;

public class EnemyB : MonoBehaviour {

    public float shootingRate;
    public float laserSpeed;
    public float fallingSpeed;
    public int enemyPointValueB = 200;
    public GameObject enemyLaser;
    public GameObject explosion;
    public AudioClip laserSound;
    public AudioClip explosionSound;
    private bool dying = false;
    private PointSystem pointSystemB;
  
    // Use this for initialization
    void Start () {
        pointSystemB = GameObject.Find("Points").GetComponent<PointSystem>();
    }

    // Update is called once per frame
    void Update()
    {
         float prob = Time.deltaTime * shootingRate; // probability used to determine shooting rate
        if (Random.value < prob)                    // works between 0 and 1
            Shoot();
        if (dying)
        {
            transform.Translate(Vector3.down * fallingSpeed * Time.deltaTime);
            transform.Rotate(33.0f * Time.deltaTime, Time.deltaTime, Time.deltaTime);
        }
        if (transform.position.y < -5.0f)
        {
            Death();
        }
    }

    void Shoot()
    {
        Vector3 startingPosition = transform.position + new Vector3(0.0f, 0.5f, -6.5f);
        GameObject laser = Instantiate(enemyLaser, startingPosition, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, -laserSpeed);
        AudioSource.PlayClipAtPoint(laserSound, transform.position);
    }

    void OnTriggerEnter(Collider collider)
    {
        PlayerLaser laser = collider.gameObject.GetComponent<PlayerLaser>();
        if (laser)
            dying = true; // enemy ship has been shot
    }

    void Death()
    {
        Destroy(gameObject);
        GameObject deathExplosion = Instantiate(explosion, transform.position, Quaternion.identity) as GameObject;
        Destroy(deathExplosion, 0.3f);
        pointSystemB.Points(enemyPointValueB);
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);
    }
}
