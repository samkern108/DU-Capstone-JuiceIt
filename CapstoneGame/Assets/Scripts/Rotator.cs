﻿/*
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

public class Rotator : MonoBehaviour 
{
	
	void Update () 
	{
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
