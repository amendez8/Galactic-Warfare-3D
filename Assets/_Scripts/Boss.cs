using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {

    public float movementSpeed;
    public float entrySpeed;
    public GameObject explosion;
    public AudioClip explosionSound;
    public GameObject winCanvas;
    public GameObject healthCanvas;
    private int health = 100;
    private int playerBullets;
    private bool dying = false;
    private bool inPosition = false;
    private bool shift = false;
    PlayerController player;
    private Health life;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        //life = GameObject.Find("Health").GetComponent<Health>();
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Enter());
       /* if (inPosition == true)
            healthCanvas.SetActive(true);*/

        playerBullets = player.numOfBullets();
    }

    IEnumerator Enter()
    {
        yield return new WaitForSeconds(40);
        // ship descending into it's position
        if (transform.position.y > 35.0f)
            transform.Translate(Vector3.down * entrySpeed * Time.deltaTime);
        // if the ship is in position, set bool true
        if (transform.position.y <= 35.0f)
            inPosition = true;
        // if greater than 5.9, set bool to have him move left
        if (transform.position.x >= 75.0f)
            shift = false;
        // if too far to left, set bool to false and move to right
        if (transform.position.x <= -72.0f)
            shift = true;
        // if ship in position, move it
        if (inPosition == true)
            SideToSide();

    }

    void SideToSide()
    {
        if (shift == true)
            transform.Translate(Vector3.left * movementSpeed * Time.deltaTime);
        if(shift == false)
            transform.Translate(Vector3.right * movementSpeed * Time.deltaTime);
    }

    public bool GetInPosition()
    {
        return inPosition;
    }
    
    void OnTriggerEnter(Collider collider)
    {
        PlayerLaser laser = collider.gameObject.GetComponent<PlayerLaser>();

        if (laser && inPosition == true)
        {
            health = health - (player.numOfBullets());
            Debug.Log(health);
          //  life.Damage(player.numOfBullets());
            if(health <= 0)
            {
                Destroy(gameObject);                
                GameObject deathExplosion = Instantiate(explosion, new Vector3(26.0f, 40.0f, -1690.0f), Quaternion.identity) as GameObject;
                Destroy(deathExplosion, 8.0f);
                AudioSource.PlayClipAtPoint(explosionSound, new Vector3(26.0f, 40.0f, -1690.0f));
                winCanvas.SetActive(true);

            }
        }

    }
}
