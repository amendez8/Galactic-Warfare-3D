using UnityEngine;
using System.Collections;

public class FormationSpawner1 : MonoBehaviour {

    public GameObject enemyPosition1;
    private int pos = 1;

    // Use this for initialization
    void Start () {
        // create stationary moving enemy
        InvokeRepeating("CreateEnemy1", 3, 10);
        StartCoroutine(EnemyWaveComplete());
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void CreateEnemy1()
    {
        //greater than or equal to 0, spawn on top. If less then 0, spawn on bottom
        float randomNum = Random.Range(-4, 4);
        if (pos % 2.0f == 0)
            randomNum = 55.0f;
        if (pos % 2.0f != 0)
            randomNum = 24.0f;

        Vector3 formationPosition = new Vector3(transform.position.x, randomNum, transform.position.z);
        transform.position = formationPosition;
        GameObject enemyFormation = Instantiate(enemyPosition1, transform.position, Quaternion.identity) as GameObject;

        pos++;
    }

    IEnumerator EnemyWaveComplete()
    {
        yield return new WaitForSeconds(30);
        CancelInvoke("CreateEnemy1");
    }
}
