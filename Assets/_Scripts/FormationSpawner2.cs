using UnityEngine;
using System.Collections;

public class FormationSpawner2 : MonoBehaviour {

    public GameObject enemyPosition2;
	
    // Use this for initialization
	void Start () {

        // create sideways moving enemy
        InvokeRepeating("CreateEnemy2", 2, 15);
        StartCoroutine(EnemyWaveComplete());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CreateEnemy2()
    {
        GameObject enemyFormation2 = Instantiate(enemyPosition2, transform.position, Quaternion.identity) as GameObject;
    }

    IEnumerator EnemyWaveComplete()
    {
        yield return new WaitForSeconds(30);
        CancelInvoke("CreateEnemy2");
    }
}
