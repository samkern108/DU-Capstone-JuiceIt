/*
 * Beginning "Roll a Ball game" code provided by Unity learn tutorials 
 * http://unity3d.com/learn/tutorials/projects/roll-ball-tutorial
 * I claim no ownership over the code provided by Unity and it's tutorials 
 * as the basis of this project. 
 * Modified code by Kelia Murata 
 * Individual 8 Hour Game
 * Fall Capstone 2015 
 * Last Modified: 9/25
*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class PlayerController : MonoBehaviour 
{
	public float speed;
	public int timer; 
	public Text countText;
	public Text	winText;
	public Text startScreenText; 



	private Rigidbody body;
	private int score;
	private int beginningCounter; 
	private int powerUps; //how many greens are in the level
	private bool over; 

	void Start()
	{
		body = GetComponent<Rigidbody> ();
		SetCountText();
		winText.text = "";
		startScreenText.text = "Collect green cubes for points. Avoid red cubes for a better score."; 
		beginningCounter = 0; 
		powerUps = 10; 
		score = 0 ; 
		over = false; 
	}

	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		beginningCounter++;

		if (timer > 0) 
		{
			if (beginningCounter < 150) 
			{ //instruction delay
				//do nothing 
			} 
			else 
			{
				startScreenText.text = ""; 
				body.AddForce (movement * speed);
				timer--; 
			}
		} 
		else
		{
			body.AddForce (movement * 0);
			over = true; 
		}
		if(over == true)
		{
			winText.text = "Waita go! you scored " + score.ToString() + " points!"  ; 
		} 

	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PowerUp"))
		{ 
			other.gameObject.SetActive(false);
			score = score + 1;
			SetCountText();
		}

		if(other.gameObject.CompareTag("PowerDown"))
		{
			other.gameObject.SetActive(false);
			score = score - 1;
			SetCountText();
		}
	}

	void SetCountText()
	{
		countText.text = "Score: " + score.ToString(); 
	}

}
