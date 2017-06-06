    using UnityEngine;
using System.Collections;

public class PlayerLaser : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onTriggerEnter(Collider collider)
    {
        EnemyA firstEnemy = collider.gameObject.GetComponent<EnemyA>();
        EnemyB secondEnemy = collider.gameObject.GetComponent<EnemyB>();

        if(firstEnemy || secondEnemy)
        {
            Destroy(gameObject);
        }
    }
}
