using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonUIHandlerScript : MonoBehaviour {
	public GameObject menu;
	public GameObject dungeon;
	// Use this for initialization
	void Start () {
		dungeon = GameObject.FindGameObjectWithTag("DungeonHub");
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NewDungeonButtonClick()
	{
		Destroy(dungeon);
		SceneManager.LoadScene("Main");
	}
}
