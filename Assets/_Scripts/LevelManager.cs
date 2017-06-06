using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public GameObject canvas;
    private bool play;

	public void LoadLevel(string name){
		Debug.Log ("New Level load: " + name);
		Application.LoadLevel (name);
	}

    public void CloseCanvas()
    {
        canvas.SetActive(false);
        play = true;
    }

	public void QuitRequest(){
		Debug.Log ("Quit requested");
		Application.Quit();
	}

    public bool ReturnPlay()
    {
        return play;
    }

}
