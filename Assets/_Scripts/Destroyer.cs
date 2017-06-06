using UnityEngine;
using System.Collections;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter(Collider collider)
    {
        PlayerLaser laser = collider.gameObject.GetComponent<PlayerLaser>();
        if (laser)
            Destroy(collider.gameObject);
    }
}
