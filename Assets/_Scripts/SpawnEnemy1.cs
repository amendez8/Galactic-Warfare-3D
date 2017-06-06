using UnityEngine;
using System.Collections;

public class SpawnEnemy1 : MonoBehaviour {

    Vector3 upgradeLocation;
    public GameObject upgradePrefab;
    public float formationX;
    public float formationY;
    public float formationSpeed;
    private int position = 1;
    private bool spawnUpgrade = false; // used to determine when to spawn the upgrade. True = spawn, false = don't spawn
    private bool moveLeft = true;
    private bool moveBack = true;
    private bool moveVertical = true;
    private PointSystem pointSystem;

    // Use this for initialization
    void Start () {
        pointSystem = GameObject.Find("Points").GetComponent<PointSystem>(); // gets the points attribute from the pointsystem component
        upgradeLocation = new Vector3(21.0f, 30.0f, -1362.0f); //constant location when upgrade spwawns
    }

    // Update is called once per frame
    void Update() {

        MoveToLocation();
        if (transform.position.x <= 24.0f) // stop moving left
            moveLeft = false;
        if (transform.position.z >= -1366) // stop moving back
            moveBack = false;

        if (EnemyWaveDead() && spawnUpgrade == true) 
        {
            GameObject upgrade = Instantiate(upgradePrefab, upgradeLocation, Quaternion.identity) as GameObject;
            pointSystem.DoubleScore1();
            spawnUpgrade = false;
        }
    }

    void MoveToLocation()
    {
        {
            if(moveBack == true)
                transform.Translate(Vector3.forward * formationSpeed * Time.deltaTime); // move back
            if (moveLeft == true && moveBack == false)
                transform.Translate(Vector3.left * formationSpeed * Time.deltaTime); // move left
        }
    }

    bool EnemyWaveDead()
    {
        foreach (Transform child in transform)
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
