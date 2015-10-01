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
	public AudioSource goodPickupSource;
	public AudioSource badPickupSource;
	public AudioSource wallCollideSource;

	public float speed;

	private Rigidbody body;
	private int powerUps; //how many greens are in the level

	void Start()
	{
		body = GetComponent<Rigidbody> ();
		powerUps = 10; 
	}

	void FixedUpdate()
	{
		if (Timer.instance.gameOver || !Timer.instance.timerRunning) {
			body.velocity = new Vector3(0,0,0);
			return;
		}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		body.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PowerUp"))
		{ 
			other.gameObject.SetActive(false);
			Timer.instance.UpdateScore(1);
			goodPickupSource.Play();
		}

		if(other.gameObject.CompareTag("PowerDown"))
		{
			other.gameObject.SetActive(false);
			Timer.instance.UpdateScore(-1);
			badPickupSource.Play();
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.tag == "Wall") {
			wallCollideSource.Play ();
		}
	}
}
