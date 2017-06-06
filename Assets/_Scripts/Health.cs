using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

    public int health = 50;
    private Text bossHealth;

	// Use this for initialization
	void Start () {
        bossHealth = GetComponent<Text>();
        Restart();
    }

    public void Damage(int damage)
    {
        health -= damage;
        bossHealth.text = health.ToString();
    }

    public void Restart()
    {
        health = 50;
        bossHealth.text = health.ToString();
    }

    // Update is called once per frame
    void Update () {
	
	}
}
