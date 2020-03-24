//using GracesGames.SimpleFileBrowser.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandlerScript : MonoBehaviour {
	public GameObject menu;
	public GameObject dungeon;
	public Material floorTexture;
	// Use this for initialization
	void Start ()
	{
		Screen.autorotateToPortrait = true;
		Screen.autorotateToLandscapeLeft = false;
		Screen.autorotateToLandscapeRight = false;
		Screen.autorotateToPortraitUpsideDown = false;
		Screen.orientation = ScreenOrientation.AutoRotation;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	public void LaunchCreatedScene()
	{
		//Ensure the created dungeon does not get deleted on load.
		DontDestroyOnLoad(dungeon);
		dungeon.GetComponent<MeshRenderer>().enabled = false;
		//Change values on the player character
		Rigidbody pRB = dungeon.transform.Find("Player(Clone)").gameObject.GetComponent<Rigidbody>();//player.GetComponent<Rigidbody>();
		pRB.isKinematic = false;

		//Create a floor to finish off the dungeon
		GameObject floor = GameObject.CreatePrimitive(PrimitiveType.Plane);
		Instantiate(floor);
		floor.name = "Floor";
		floor.transform.SetParent(dungeon.transform);
		floor.GetComponent<MeshRenderer>().material = floorTexture;
		floor.tag = "Ground";
		floor.transform.localScale += new Vector3(100, 100, 100);
		//Launch
		SceneManager.LoadScene("UserScene");
	}
	//Reset the dungeon if the user has an error.
	public void ResetScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
	public void ExitClick()
	{
		menu.SetActive(false);
	}
	public void MenuClick()
	{
		menu.SetActive(true);
	}
}
