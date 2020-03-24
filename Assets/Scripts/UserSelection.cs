using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserSelection : MonoBehaviour {

	private Ray ray;
	private RaycastHit raycastHit;
	private GameObject touched;
	private bool timePassed = true;
	float lastTouch;
	bool dungeonOriginStored = false;
	public GameObject dungeon;
	public GameObject player;
	WallsGenerator generator;
	public Text DebugText;


	// Use this for initialization
	void Start () {
		generator = dungeon.GetComponent<WallsGenerator>();

	}

	// Update is called once per frame
	void Update()
	{
		/*if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)//Input.touches.Length == 1 && timePassed)
		{
			//timePassed = false;
			//lastTouch = Time.time;
			Touch touch = Input.GetTouch(0);
			FindTouchedObject(touch);
		}*/
		if (Input.GetMouseButtonUp(0))
		{
			//timePassed = false;
			//lastTouch = Time.time;
			Touch touch = new Touch();
			touch.position = Input.mousePosition;
			FindTouchedObject(touch);
		}
		/*if(timePassed == false && Time.time - lastTouch > .25)
		{
			timePassed = true;
		}*/
		
	}

	void FindTouchedObject(Touch touch)
	{
		
		
		DebugText.text = "";
		ray = Camera.main.ScreenPointToRay(touch.position);
		if (Physics.Raycast(ray.origin, ray.direction, out raycastHit, Mathf.Infinity))
		{
			GameObject touched = raycastHit.collider.gameObject;
			DebugText.text = touched.tag;
			if (touched.CompareTag("TouchableInsert") && dungeonOriginStored)
			{
				DebugText.text = "Object Added to Dungeon";
				//Material touchedMat = touched.GetComponent<Material>();
				//touchedMat.color = new Color(0, 0, 255);

				GameObject touchedCopy = Instantiate(touched);
				touchedCopy.transform.SetParent(dungeon.transform);
				touchedCopy.transform.position = touched.transform.position;
					
				touchedCopy.transform.localScale = dungeon.transform.localScale;
				touchedCopy.transform.localScale += new Vector3(.77f, .77f, .77f);

				//touched.transform.GetComponent<Renderer>().material.color = Color.blue;
				/*DebugText.text = "Original Transform Pos X: " + touched.transform.position.x + " Y: " + touched.transform.position.y + " Z: " + touched.transform.position.z +
					"\r + New Transform Pos X: " + touchedCopy.transform.position.x + " Y: " + touchedCopy.transform.position.y + " Z: " + touchedCopy.transform.position.z;*/
			}
			if (touched.CompareTag("TouchableCorner") && dungeonOriginStored)
			{
				DebugText.text = "Corner Added to Dungeon";
				//generator.AddCorner(dungeon.transform.position - touched.transform.position);
				GameObject touchedCopy = Instantiate(touched);
				touchedCopy.transform.rotation.Set(0, 0, 0, 0);
				touchedCopy.transform.SetParent(dungeon.transform);
				touchedCopy.transform.rotation.Set(0, 0, 0, 0);
				touchedCopy.transform.position = touched.transform.position;
				touchedCopy.transform.localScale = dungeon.transform.localScale;
					
				generator.AddCorner();
				Destroy(touchedCopy);
					
			}
			if (touched.CompareTag("DungeonHub") && !dungeonOriginStored)
			{
				DebugText.text = "Stored Dungeon Origin";
				dungeonOriginStored = true;	

				touched.transform.parent = null;
				//touched.transform.position = touched.transform.position;
				//touched.transform.localScale = dungeon.transform.localScale;
				touched.transform.rotation.Set(0, 0, 0, 0);
				//generator.AddCorner();
				//Destroy(touchedCopy);

			}
			if (!dungeonOriginStored)
			{
				DebugText.text = "Click on the dungeon \r origin first...";
			}
		}
		
		
	}
}
