using UnityEngine;
using System.Collections;

public class SpawnEnemy2 : MonoBehaviour {

    Vector3 upgradeLocation;
    public GameObject upgradePrefab;
    public float formationX;
    public float formationY;
    public float formationSpeed;
    private int movingCounter = 0;
    private bool spawnUpgrade = false; // used to determine when to spawn the upgrade. True = spawn, false = don't spawn
    private PointSystem pointSystem;

    // Use this for initialization
    void Start () {
        pointSystem = GameObject.Find("Points").GetComponent<PointSystem>(); // gets the points attribute from the pointsystem component
        upgradeLocation = new Vector3(25.0f, transform.position.y, transform.position.z); //constant location when upgrade spwawns
    }
	
	// Update is called once per frame
	void Update () {

        SideToSide();

        if(EnemyWaveDead() && spawnUpgrade == true)
        {                                         
            GameObject upgrade = Instantiate(upgradePrefab, upgradeLocation, Quaternion.identity) as GameObject;
            pointSystem.DoubleScore2();
            spawnUpgrade = false;
        }
      
	}

    void SideToSide()
    {
        if (movingCounter == 0)
        {
            transform.Translate(Vector3.right * formationSpeed * Time.deltaTime); // move right
            if (transform.position.x >= 285.0f)
            {
                transform.Translate(Vector3.back * formationSpeed * Time.deltaTime); // move forward
                if (transform.position.z <= -1400.0f)
                    movingCounter = 1;
            }
        }
        if (movingCounter == 1)
        {
            transform.Translate(Vector3.left * formationSpeed * Time.deltaTime); // move left
            if(transform.position.x <= -243.0f)
            {
                transform.Translate(Vector3.back * formationSpeed * Time.deltaTime); // move forward
                if (transform.position.z <= -1480)
                    movingCounter = 2;
            }
        }
        if(movingCounter == 2)
        {
            transform.Translate(Vector3.right * formationSpeed * Time.deltaTime); // move right
            if(transform.position.x >=  19)
            {
                movingCounter = 3;
                return; // stop moving
            }
        }
    }

    bool EnemyWaveDead()
    {
        foreach(Transform child in transform)
        {
            if (child.childCount > 0)
            {
                spawnUpgrade = true;
                return false;
            }
        }
        return true; // all enemies destroyed
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(formationX, formationY));
    }
}
