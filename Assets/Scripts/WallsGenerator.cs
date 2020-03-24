using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallsGenerator : MonoBehaviour {

	public Material texture;
	public Text DebugText;
	GameObject walls;
	Vector3[] verts;
	Transform dungeon;
	int vertsCount = 0;
	// Use this for initialization
	void Start () {
		dungeon = GetComponent<Transform>();
		walls = new GameObject("Walls");
		walls.transform.SetParent(dungeon);
		walls.transform.localScale = new Vector3(1, 1, 1);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void AddCorner(Vector3 pos)
	{
		if(verts != null)
		{
			Vector3[] newVerts = new Vector3[verts.Length + 1];
			for (int i = 0; i < verts.Length; i++)
				newVerts[i] = verts[i];
			newVerts[verts.Length] = pos;
			verts = newVerts;
		}
		else
		{
			verts = new Vector3[1] { pos };
		}
		
		RenderWalls();
	}

	public void AddCorner()
	{
		foreach(Transform child in dungeon.transform)
		{
			if (child.CompareTag("TouchableCorner"))
			{
				Vector3 pos = child.transform.position;
				if (verts != null)
				{
					Vector3[] newVerts = new Vector3[verts.Length + 1];
					for (int i = 0; i < verts.Length; i++)
						newVerts[i] = verts[i];
					newVerts[verts.Length] = pos;
					verts = newVerts;
					Destroy(child.gameObject);
				}
				else
				{
					verts = new Vector3[1] { pos };
				}

				RenderWalls();
			}
		}
		
	}

	void RenderWalls()
	{
		
		foreach(Transform child in walls.transform)
		{
			Destroy(child.gameObject);
		}
		if(verts.Length == 1)
		{
			GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
			wall.transform.parent = walls.transform;
			wall.transform.position = verts[0];
			wall.transform.localScale.Set(1, 2, 1);
			
		}
		else
		{
			
			for (int i = 1; i < verts.Length; i++)
			{
				AddWall(verts[i - 1], verts[i]);
			}
			if(verts.Length > 2)
			{
				AddWall(verts[verts.Length - 1], verts[0]);
			}
			

		}
	}
	void AddWall(Vector3 point1, Vector3 point2)
	{
		
		GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
		wall.name = "Wall";
		wall.transform.SetParent(walls.transform);
		float length = (point2 - point1).magnitude;
		Vector3 scale = new Vector3(0, 0, length * 30);
		wall.transform.localScale = new Vector3(.025f,2,1);
		wall.transform.localScale += scale;
		wall.transform.position = point1 + ((point2 - point1) / 2.0f);
		wall.transform.LookAt(point2);
		
		
	}
}
