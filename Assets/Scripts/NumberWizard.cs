using UnityEngine;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	public Text main;
	public GameObject NextButton, CorrectButton, RestartButton,HigherButton,LowerButton;
	private int guess = 0;
	private int max, min,attempts;
	private bool win=false;
	void Start () {
		max = 1000;
		min = 1;
		Welcome ();
		Guess ();
	}

	void Welcome () {
		main.text = "Pick a Number! Lowest Number is : " + min + " Highest Number is : " + max;
		NextButton.SetActive (true);
		CorrectButton.SetActive (false);
		RestartButton.SetActive (false);
		HigherButton.SetActive (false);
		LowerButton.SetActive (false);
		attempts=5;
	}

	void Guess () {		
		guess = Random.Range (min, max + 1);
	}

	public void UpdateGuess () {
		if (attempts!=0)
		{
			main.text = "Is it ? " + guess + " Or click higher or lower ?";
			NextButton.SetActive (false);
			RestartButton.SetActive (false);
			CorrectButton.SetActive (true);		
			HigherButton.SetActive (true);
			LowerButton.SetActive (true);
		}		
		
	}

	void CpuLose()
	{
		main.text="You have defeated me ! I will get you next time... ";
		NextButton.SetActive (false);
		CorrectButton.SetActive (false);
		RestartButton.SetActive (true);
		HigherButton.SetActive (false);
		LowerButton.SetActive (false);		
	}

	public void is_Higher () {
		attempts-=1;
		min = guess;
		Guess ();
		UpdateGuess ();
	}

	public void is_Lower () {
		attempts-=1;
		max = guess;
		Guess ();
		UpdateGuess ();
	}

	public void is_Correct () {
		win=true;
		main.text = "I Guess the Number is : " + guess;
		HigherButton.SetActive (false);
		LowerButton.SetActive (false);	
		CorrectButton.SetActive (false);
		RestartButton.SetActive (true);
	}

	void Update()
	{
		if (attempts==0&&!win)
		{
			CpuLose();		
		}
	}

}