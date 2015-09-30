using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	private float timerFullTimeSeconds = 60;
	public static float timerCountdownSeconds;
	public GameObject timerGameObject;
	private Text timerText;
	private bool gameOver = false;
	
	void Start () {
		timerText = timerGameObject.GetComponent ("Text") as Text;
		ResetTimer ();
	}

	void ResetTimer() {
		timerCountdownSeconds = timerFullTimeSeconds;
		gameOver = false;
	}

	void Update () {
		if (gameOver) {
			return;
		}
		timerCountdownSeconds -= Time.deltaTime;
		float truncatedTime = Mathf.Round (timerCountdownSeconds);

		if (timerCountdownSeconds <= 0) {
			SendGameOverNotification();
			timerCountdownSeconds = 0;
			gameOver = true;
		}

		timerText.text = truncatedTime + "";
	}

	public void SendGameOverNotification(){
		//SendMessage ("GameOver");
	}
}
