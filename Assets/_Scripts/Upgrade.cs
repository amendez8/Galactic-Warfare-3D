using UnityEngine;
using System.Collections;

public class Upgrade : MonoBehaviour {

    public AudioClip upgradeSound;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.back * 150.0f * Time.deltaTime);
    }

    void OnTriggerEnter(Collider collider)
    {
        PlayerController ship = collider.gameObject.GetComponent<PlayerController>();
        if (ship)
        {
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(upgradeSound, transform.position);
        }
    }
}
