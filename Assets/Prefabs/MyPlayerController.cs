using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyPlayerController : MonoBehaviour {
	//Values used to control player behaviour
	private Rigidbody rb;
	private string player;
	public bool grounded = true;
	public float speed = .0025f;
	private float jumpForce = 30.0f;
	//public GameObject camera;

	//Values used to keep track of score
	private static int count;
	private int score;
	public Text countText;
	public Text winText;
	
	//Values used for resetting the game
	public GameObject spawn;
	private List<GameObject> collected = new List<GameObject>();
	private bool isPlay = false;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		player = this.gameObject.tag;

		count = 0;
		//winText.text = "";
		//SetCountText();
	}
	// Update is called once per frame
	void FixedUpdate ()
	{
		//if (isPlay)
		{
			/*if (!rb.isKinematic && camera.transform.parent != null)
				camera.transform.parent = null;*/
				//rb.isKinematic = false;
			//float moveHorizontal = 0, moveVertical = 0, moveJump = 0;
			/*if (player == "Player1" && grounded)
			{
				if (Input.GetKey("w"))
				{
					moveVertical = 1.0f;
				}
				if (Input.GetKey("a"))
				{
					moveHorizontal = -1.0f;
				}
				if (Input.GetKey("s"))
				{
					moveVertical = -1.0f;
				}
				if (Input.GetKey("d"))
				{
					moveHorizontal = 1.0f;
				}
				if (Input.GetKey(KeyCode.LeftShift))
				{
					moveJump = jumpForce;
				}
				Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

				rb.AddForce(movement * speed);
			}
			if (player == "Player2" && grounded)
			{
				if (Input.GetKey(KeyCode.UpArrow))
				{
					moveVertical = 1.0f;
				}
				if (Input.GetKey(KeyCode.LeftArrow))
				{
					moveHorizontal = -1.0f;
				}
				if (Input.GetKey(KeyCode.DownArrow))
				{
					moveVertical = -1.0f;
				}
				if (Input.GetKey(KeyCode.RightArrow))
				{
					moveHorizontal = 1.0f;
				}
				if (Input.GetKey(KeyCode.RightControl))
				{
					moveJump = jumpForce;
				}
				Vector3 movement = new Vector3(moveHorizontal, moveJump, moveVertical);

				rb.AddForce(movement * speed);
			}*/

			Vector3 movement = Input.acceleration;
			rb.AddForce(movement.x * -speed, 0, movement.y * -speed);
			//Debug.Log("Got here");
			/*if (rb == null && isPlay)
			{
				gameObject.AddComponent<Rigidbody>();
				rb = gameObject.GetComponent<Rigidbody>();
			}*/
				

		}
		

		

	}
	private void OnCollisionStay(Collision collision)
	{
		if(collision.gameObject.CompareTag("Ground"))
			grounded = true;
	}
	private void OnCollisionExit(Collision collision)
	{
		grounded = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.name.Contains("Pickup"))
		{
			collected.Add(other.gameObject);
			other.gameObject.SetActive(false);
			count++;
			score++;
			//SetCountText();
		}
		
	}
	/*void SetCountText()
	{
		countText.text = "Score: " + score.ToString();
		if(count >= 12 && score > count / 2)
		{
			winText.text = tag + " wins!";
		}
		if (count >= 12 && score == count / 2)
		{
			winText.text = "It's a tie!";
		}
	}*/

	//Additional Methods
	public int getCount()
	{
		return count;
	}

	//Originally just reloaded the scene, but that seemed to easy, and while worked for something this simple, is likely bad practice for larger apps
	//Sends players back to start. Takes all the collected objects and returns them to "Active" status, returns score counts to 0.
	/*public void Reset()
	{
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		foreach (var c in collected)
			c.SetActive(true);
		count = 0;
		score = 0;
		SetCountText();
		gameObject.transform.position = spawn.gameObject.transform.position;
		rb.isKinematic = true;
	}*/

}
