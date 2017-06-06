using UnityEngine;
using System.Collections;

public class DestroyerBack : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        EnemyLaser eLaser = collider.gameObject.GetComponent<EnemyLaser>();
        Upgrade upgrade = collider.gameObject.GetComponent<Upgrade>();

        if (eLaser || upgrade)
        {
            Destroy(collider.gameObject);
        }
    }
}
