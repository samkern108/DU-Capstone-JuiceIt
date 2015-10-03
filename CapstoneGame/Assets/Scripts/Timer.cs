using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	public static Timer instance;

	public AudioSource tickingTimerSource;

	public GameObject scorePanel;
	public GameObject timerGameObject;

	private Animator scoreAnimator;
	private Animator timerAnimator;

	public Text winText;
	public Text	instructionsText;
	public Text scoreText;

	public int score = 0;

	
	private float timerFullTimeSeconds = 45.49f;  //#superhackytimecrunch
	private int tickTracker = 45;
	public static float timerCountdownSeconds;
	private Text timerText;
	public bool gameOver = false;
	public bool timerRunning = false;
	private bool finalCountdown = false;

	void Start () {
		timerText = timerGameObject.GetComponent ("Text") as Text;
		Reset();

		scoreAnimator = scorePanel.GetComponent ("Animator") as Animator;
		timerAnimator = timerText.gameObject.GetComponent ("Animator") as Animator;

		instance = this;
	}

	void Reset() {
		timerCountdownSeconds = timerFullTimeSeconds;
		gameOver = false;
		//this isn't pretty, but hey!  4 hours.
		instructionsText.gameObject.transform.parent.gameObject.SetActive (true);
		winText.gameObject.transform.parent.gameObject.SetActive (false);
		score = 0;
		finalCountdown = false;
	}

	public void StartTimer(){
		timerRunning = true;
		instructionsText.gameObject.transform.parent.gameObject.SetActive (false);
	}

	void Update () {
		if (gameOver || !timerRunning) {
			return;
		}

		if (timerCountdownSeconds <= 10 && !finalCountdown) {
			finalCountdown = true;
			tickingTimerSource.Play ();
		}

		if (timerCountdownSeconds <= tickTracker + .5) {   //#superduperhackytimecrunch
			tickTracker--;
			if (finalCountdown) {
				timerAnimator.SetTrigger ("LowTimeTick");
			} else {
				timerAnimator.SetTrigger ("Tick");
			}
		}

		timerCountdownSeconds -= Time.deltaTime;
		float truncatedTime = Mathf.Round (timerCountdownSeconds);

		if (timerCountdownSeconds <= 0) {
			timerCountdownSeconds = 0;
			gameOver = true;
			winText.text = "Waita go! you scored " + score + " points!"  ; 
			winText.gameObject.transform.parent.gameObject.SetActive (true);
			timerRunning = false;
		}

		timerText.text = truncatedTime + "";
	}

	public void UpdateScore(int add)
	{
		if(add > 0){
			scoreAnimator.SetTrigger("Increment");
		}
		else{
			scoreAnimator.SetTrigger("Decrement");
		}
		score += add;
		scoreText.text = "Score: " + score;
	}
}
