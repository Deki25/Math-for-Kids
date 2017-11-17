using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FourthGradeScript : MonoBehaviour 
{
	public GameObject GameMenagering;
	public GameObject FillBar;

	public GameObject firstNumberBox;
	public GameObject secondNumberBox;
	public GameObject singBox;
	public GameObject equalsBox;
	public GameObject squareBox;
	public GameObject rectangleBox;

	public Text firstNumberText;
	public Text secondNumberText;
	public Text signText;
	public Text equalsText;
	public Text SquareText;

	public Text resultNumber;

	public InputField resultInputField;

	private string sign;

	private int firstNumber;
	private int secondNumber;
	private int result;
	private int minusOrPlus;
	private int a;
	private int b;

	void Start()
	{
		CalculatingSystem ();
		resultInputField.ActivateInputField ();
	}

	void Update()
	{
		if (minusOrPlus <= 3) 
		{
			firstNumberBox.SetActive (true);
			secondNumberBox.SetActive (true);
			singBox.SetActive (true);
			equalsBox.SetActive (true);
			squareBox.SetActive (false);
			rectangleBox.SetActive (false);
		} 
		else if (minusOrPlus >= 4) 
		{
			firstNumberBox.SetActive (false);
			secondNumberBox.SetActive (false);
			singBox.SetActive (false);
			equalsBox.SetActive (false);
			squareBox.SetActive (true);
			rectangleBox.SetActive (true);
		}
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
			else if (minusOrPlus == 2) 
			{
				if (firstNumber * secondNumber == result) 
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
			else if (minusOrPlus == 3) 
			{
				if (firstNumber / secondNumber == result) 
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
			else if (minusOrPlus == 4) 
			{
				if (a * a == result) 
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
			else if (minusOrPlus == 5) 
			{
				if (a * b == result) 
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
		minusOrPlus = Random.Range (0, 6);

		if (minusOrPlus == 0)
			Plus ();
		else if (minusOrPlus == 1)
			Minus ();
		else if (minusOrPlus == 2)
			Plural ();
		else if (minusOrPlus == 3)
			Division ();
		else if (minusOrPlus == 4)
			Square ();
		else if (minusOrPlus == 5)
			Rectangle ();
	}

	void Square()
	{
		a = Random.Range (2, 11);

		if (LanguageScript.isEnglish == true)
			SquareText.text = "What's the area of square if his side a = " + a + "cm";
		else if (LanguageScript.isSerbian == true)
			SquareText.text = "Kolika je povrsina kvadrata ako je njegova stranica a = " + a + "cm";

		Debug.Log (a * a);
	}

	void Rectangle()
	{
		a = Random.Range (2, 11);
		b = Random.Range (2, 11);

		if (LanguageScript.isEnglish == true)
			SquareText.text = "What's the area of rectangle if his side a = " + a + "cm and b = " + b + "cm";
		else if (LanguageScript.isSerbian == true)
			SquareText.text = "Kolika je povrsina pravougaonika ako je njegova stranica a = " + a + "cm i b = " + b + "cm";

		Debug.Log (a * b);
	}


	void Plural()
	{
		firstNumber = Random.Range (1, 20);
		secondNumber = Random.Range(1, 20);

		firstNumberText.text = firstNumber.ToString();
		secondNumberText.text = secondNumber.ToString();

		Debug.Log (firstNumber * secondNumber);

		sign = "x";
		signText.text = sign;
	}

	void Division()
	{
		firstNumber = Random.Range (2, 100);
		secondNumber = Random.Range(2, 100);

		if (firstNumber / secondNumber > 0 && firstNumber >= secondNumber && firstNumber % secondNumber == 0 && firstNumber != secondNumber) 
		{
			firstNumberText.text = firstNumber.ToString ();
			secondNumberText.text = secondNumber.ToString ();
			Debug.Log (firstNumber / secondNumber);
		} 
		else
		{
			Division ();
		}
			

		sign = "/";
		signText.text = sign;
	}

	void Plus()
	{
		firstNumber = Random.Range (1, 1000);
		secondNumber = Random.Range (1, 1000);

		firstNumberText.text = firstNumber.ToString();
		secondNumberText.text = secondNumber.ToString();

		Debug.Log (firstNumber + secondNumber);

		sign = "+";
		signText.text = sign;
	}

	void Minus()
	{
		firstNumber = Random.Range (1, 1000);
		secondNumber = Random.Range (1, 1000);

		if (firstNumber - secondNumber > 0 && firstNumber >= secondNumber) 
		{
			firstNumberText.text = firstNumber.ToString ();
			secondNumberText.text = secondNumber.ToString ();
			Debug.Log (firstNumber - secondNumber);
		} 
		else
		{
			Minus ();
		}
	
		sign = "-";
		signText.text = sign;
	}
}
