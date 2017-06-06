using UnityEngine;
using System.Collections;

public class Ground : MonoBehaviour
{
    public GameObject canvas;
    public float scrollSpeed;
    public float tileSize;
    bool play;
    LevelManager RTP; // ready to play

    private Vector3 startPosition;

    // Use this for initialization
    void Start()
    {
       // RTP = GameObject.Find("Play").GetComponent<Canvas>();
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
       // if (play == false)
        //{
            float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
            transform.position = startPosition + Vector3.back * newPosition;
        //}
    }

    public void SetSpeed(float speed)
    {
        scrollSpeed = speed;
    }
}
