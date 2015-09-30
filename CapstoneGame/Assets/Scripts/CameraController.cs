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
using System.Collections;

public class CameraController : MonoBehaviour 
{

	public GameObject player;

	private Vector3 offset;


	void Start () 
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate () 
	{
		transform.position = player.transform.position + offset;

	}
}
