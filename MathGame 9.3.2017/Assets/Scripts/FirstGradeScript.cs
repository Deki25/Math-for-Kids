using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstGradeScript : MonoBehaviour 
{
	public GameObject GameMenagering;
	public GameObject FillBar;

	public Text firstNumberText;
	public Text secondNumberText;
	public Text signText;
	public Text equalsText;

	public Text resultNumber;

	public InputField resultInputField;

	private string sign;

	private int firstNumber;
	private int secondNumber;
	private int result;
	private int minusOrPlus;

	void Start()
	{
		CalculatingSystem ();
		resultInputField.ActivateInputField ();
	}

	public void ExecuteMath()
	{
		result = int.Parse (resultNumber.text);

		if (ScoreScript.right + ScoreScript.wrong <= ScoreScript.maxTest)
		{
			if (minusOrPlus == 0)
			{
				if (firstNumber + secondNumber == result) 
				{
					ScoreScript.AddPointRight ();
					GameMenagering.GetComponent<GameMenager>().FillBar.GetComponent<Image>().color = Color.green;
					GameMenager.isRight = true;
				} 
				else 
				{
					ScoreScript.AddPointWrong ();
					GameMenagering.GetComponent<GameMenager>().FillBar.GetComponent<Image>().color = Color.red;
					GameMenager.isWrong = true;
				}
			}
			else if (minusOrPlus == 1) 
			{
				if (firstNumber - secondNumber == result) 
				{
					ScoreScript.AddPointRight ();
					GameMenagering.GetComponent<GameMenager>().FillBar.GetComponent<Image>().color = Color.green;
					GameMenager.isRight = true;
				}
				else 
				{
					ScoreScript.AddPointWrong ();
					GameMenagering.GetComponent<GameMenager>().FillBar.GetComponent<Image>().color = Color.red;
					GameMenager.isWrong = true;
				}
			}
			GameObject newBar = Instantiate (FillBar, FillBar.transform.parent) as GameObject;
			newBar.SetActive (true);
		}
	}

	public void CalculatingSystem()
	{
		minusOrPlus = Random.Range (0, 2);

		if (minusOrPlus == 0)
			Plus ();
		else
			Minus ();
	}

	void Plus()
	{
		firstNumber = Random.Range (1, 11);
		secondNumber = Random.Range (1, 11);

		firstNumberText.text = firstNumber.ToString();
		secondNumberText.text = secondNumber.ToString();

		Debug.Log (firstNumber + secondNumber);

		sign = "+";
		signText.text = sign;
	}

	void Minus()
	{
		firstNumber = Random.Range (1, 11);
		secondNumber = Random.Range (1, 11);

		if (firstNumber - secondNumber > 0 && firstNumber >= secondNumber) 
		{
			firstNumberText.text = firstNumber.ToString ();
			secondNumberText.text = secondNumber.ToString ();
		} 
		else
		{
			Minus ();
		}

		Debug.Log (firstNumber - secondNumber);
		sign = "-";
		signText.text = sign;
	}
}
