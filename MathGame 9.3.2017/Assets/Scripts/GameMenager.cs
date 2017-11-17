using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenager : MonoBehaviour 
{
	public GameObject ChooseLanguage;
	public GameObject ChooseGender;
	public GameObject ChooseGrade;

	public GameObject FirstGrade;
	public GameObject SecondGrade;
	public GameObject ThirdGrade;
	public GameObject FourthGrade;

	public GameObject BoyImage;
	public GameObject GirlImage;

	public GameObject Score;

	public GameObject Question;

	public GameObject End;

	public GameObject RightImage;
	public GameObject WrongImage;

	public GameObject GoodJob;

	public GameObject Progress;
	public GameObject FillBar;

	private GameObject[] clones;

	public Text ChooseGradeText;
	public Text ChooseGenderText;

	public Text FirstGradeText;
	public Text SecondGradeText;
	public Text ThirdGradeText;
	public Text FourthGradeText;

	public Text BoyText;
	public Text GirlText;

	public Text rightAnswerText;
	public Text wrongAnswerText;

	public Text EndText;

	public Text QuestionText;

	public Text GoodJobText;

	public static bool isRight;
	public static bool isWrong;

	private float timer = 0f;
	private float timerExecute = 100f;

	private float endTimer = 0f;
	private float endTImerExecute = 100f;

	void Localisation()
	{
		if (LanguageScript.isEnglish == true)
		{
			ChooseGenderText.text = "Choose gender";
			BoyText.text = "Boy";
			GirlText.text = "Girl";
			ChooseGradeText.text = "Choose grade";
			FirstGradeText.text = "1st grade";
			SecondGradeText.text = "2nd grade";
			ThirdGradeText.text = "3rd grade";
			FourthGradeText.text = "4th grade";
			rightAnswerText.text = "Right Answers: " + ScoreScript.right;
			wrongAnswerText.text = "Wrong Answers: " + ScoreScript.wrong;
			QuestionText.text = ScoreScript.question + ". Question";
			EndText.text = "You had " + ScoreScript.right + " right answers and " + ScoreScript.wrong + " wrong answers. Click space to start again";
			if (ScoreScript.right == 1)
				GoodJobText.text = "Good job, keep on doing!";
			else if (ScoreScript.right == 5)
				GoodJobText.text = "You are very good";
			else if (ScoreScript.right == 10)
				GoodJobText.text = "Impresive knowlegde of matchematics!";
		}

		if (LanguageScript.isSerbian == true)
		{
			ChooseGenderText.text = "Izaberite pol";
			BoyText.text = "Decak";
			GirlText.text = "Devojcica";
			ChooseGradeText.text = "Izaberite razred";
			FirstGradeText.text = "1. razred";
			SecondGradeText.text = "2. razred";
			ThirdGradeText.text = "3. razred";
			FourthGradeText.text = "4. razred";
			rightAnswerText.text = "Tacni odgovori: " + ScoreScript.right;
			wrongAnswerText.text = "Pogresni odgovori: " + ScoreScript.wrong;
			QuestionText.text = ScoreScript.question + ". Pitanje";
			if (ChooseGenderScript.isBoy == true)
				EndText.text = "Imao si " + ScoreScript.right + " tacnih odgovora i " + ScoreScript.wrong + " pogresna odgovora. Klikni space da zapocnes ponovo";
			else if (ChooseGenderScript.isGirl == true)
				EndText.text = "Imala si " + ScoreScript.right + " tacnih odgovora i " + ScoreScript.wrong + " pogresna odgovora. Klikni space da zapocnes ponovo";
			if (ScoreScript.right == 1)
				GoodJobText.text = "Bravo, samo tako nastavi!";
			else if (ScoreScript.right == 5)
				GoodJobText.text = "Veoma dobro znas matematiku";
			else if (ScoreScript.right == 10)
				GoodJobText.text = "Imas impresivno znanje matematike!";
		}
	}

	void Update ()
	{
		clones = GameObject.FindGameObjectsWithTag ("klon");

		Localisation();

		if (LanguageScript.isEnglish == true || LanguageScript.isSerbian == true)
		{
			ChooseLanguage.SetActive (false);
			ChooseGender.SetActive (true);
		}

		if (GradeScript.firstGrade == true) 
		{
			ChooseGrade.SetActive (false);
			FirstGrade.SetActive (true);
		}
		else if (GradeScript.secondGrade == true)
		{
			ChooseGrade.SetActive (false);
			SecondGrade.SetActive (true);
		}
		else if (GradeScript.thirdGrade == true)
		{
			ChooseGrade.SetActive (false);
			ThirdGrade.SetActive (true);
		} 
		else if (GradeScript.fourthGrade == true) 
		{
			ChooseGrade.SetActive (false);
			FourthGrade.SetActive (true);
		}

		if (ChooseGenderScript.isBoy == true || ChooseGenderScript.isGirl == true)
		{
			ChooseGender.SetActive (false);
			ChooseGrade.SetActive (true);
		}
			
		if (ChooseGrade.activeInHierarchy == true && (FirstGrade.activeInHierarchy == true ||
		    SecondGrade.activeInHierarchy == true ||
		    ThirdGrade.activeInHierarchy == true ||
		    FourthGrade.activeInHierarchy == true)) 
		{
			ChooseGrade.SetActive (false);
		}

		if (ChooseGenderScript.isBoy == true && (FirstGrade.activeInHierarchy == true ||
			SecondGrade.activeInHierarchy == true ||
			ThirdGrade.activeInHierarchy == true ||
			FourthGrade.activeInHierarchy == true))
		{
			BoyImage.SetActive (true);
		}

		if (ChooseGenderScript.isGirl == true && (FirstGrade.activeInHierarchy == true ||
			SecondGrade.activeInHierarchy == true ||
			ThirdGrade.activeInHierarchy == true ||
			FourthGrade.activeInHierarchy == true))
		{
			GirlImage.SetActive (true);
		}

		if (FirstGrade.activeInHierarchy == true || SecondGrade.activeInHierarchy == true || ThirdGrade.activeInHierarchy == true || FourthGrade.activeInHierarchy == true) 
		{
			//Score.SetActive (true);
			Question.SetActive (true);
			Progress.SetActive (true);

			if (ScoreScript.right + ScoreScript.wrong <= ScoreScript.maxTest)
			{
				if(isRight == true || isWrong == true)
				{
					if (timer < timerExecute)
					{
						timer++;
						if(isRight == true)
						{
							RightImage.SetActive (true);
							if (ScoreScript.right == 1 || ScoreScript.right == 5 || ScoreScript.right == 10)
								GoodJob.SetActive (true);
						}
						else if (isWrong == true)
							WrongImage.SetActive(true);
					}
					else
					{
						timer = 0;
						if (GradeScript.firstGrade == true) 
						{
							FirstGrade.GetComponent<FirstGradeScript> ().resultInputField.text = "";
							FirstGrade.GetComponent<FirstGradeScript> ().resultInputField.ActivateInputField ();
							FirstGrade.GetComponent<FirstGradeScript> ().CalculatingSystem ();
						} 
						else if (GradeScript.secondGrade == true)
						{
							SecondGrade.GetComponent<SecondGradeScript> ().resultInputField.text = "";
							SecondGrade.GetComponent<SecondGradeScript> ().resultInputField.ActivateInputField ();
							SecondGrade.GetComponent<SecondGradeScript> ().CalculatingSystem ();
						}
						else if (GradeScript.thirdGrade == true)
						{
							ThirdGrade.GetComponent<ThirdGradeScript> ().resultInputField.text = "";
							ThirdGrade.GetComponent<ThirdGradeScript> ().resultInputField.ActivateInputField ();
							ThirdGrade.GetComponent<ThirdGradeScript> ().CalculatingSystem ();
						}
						else if (GradeScript.fourthGrade == true)
						{
							FourthGrade.GetComponent<FourthGradeScript> ().resultInputField.text = "";
							FourthGrade.GetComponent<FourthGradeScript> ().resultInputField.ActivateInputField ();
							FourthGrade.GetComponent<FourthGradeScript> ().CalculatingSystem ();
						}
							
						if(isRight == true)
						{
							RightImage.SetActive(false);
							GoodJob.SetActive(false);
							isRight = false;
						}
						else if (isWrong == true)
						{
							WrongImage.SetActive(false);
							isWrong = false;
						}
						ScoreScript.question++;
					}
				}
			}
		}

		if (ScoreScript.right + ScoreScript.wrong == ScoreScript.maxTest) 
		{ 	
			if (endTimer < endTImerExecute)
				endTimer++;
			else
			{
				FirstGrade.SetActive(false);
				SecondGrade.SetActive(false);
				ThirdGrade.SetActive(false);
				FourthGrade.SetActive(false);

				Score.SetActive(false);
				Question.SetActive(false);

				if (ChooseGenderScript.isBoy == true)
					BoyImage.SetActive(false);
				else if (ChooseGenderScript.isGirl == true)
					GirlImage.SetActive(false);

				foreach (GameObject clone in clones)
					Destroy(clone.gameObject);

				Progress.SetActive(false);
				End.SetActive(true);
			}
		}

		if (End.activeInHierarchy == true)
		{
			isRight = false;
			isWrong = false;
		
			if (Input.GetKeyDown (KeyCode.Space)) 
			{
				End.SetActive (false);

				if (GradeScript.firstGrade == true)
					FirstGrade.SetActive (true);
				else if (GradeScript.secondGrade == true)
					SecondGrade.SetActive (true);
				else if (GradeScript.thirdGrade == true)
					ThirdGrade.SetActive (true);
				else if (GradeScript.fourthGrade == true)
					FourthGrade.SetActive (true);
			
				ScoreScript.question = 1;
				ScoreScript.right = 0;
				ScoreScript.wrong = 0;
			    endTimer = 0;

				if (GradeScript.firstGrade == true) 
				{
					FirstGrade.GetComponent<FirstGradeScript> ().resultInputField.text = "";
					FirstGrade.GetComponent<FirstGradeScript> ().resultInputField.ActivateInputField ();
					FirstGrade.GetComponent<FirstGradeScript> ().CalculatingSystem ();
				} 
				else if (GradeScript.secondGrade == true)
				{
					SecondGrade.GetComponent<SecondGradeScript> ().resultInputField.text = "";
					SecondGrade.GetComponent<SecondGradeScript> ().resultInputField.ActivateInputField ();
					SecondGrade.GetComponent<SecondGradeScript> ().CalculatingSystem ();
				}
				else if (GradeScript.thirdGrade == true)
				{
					ThirdGrade.GetComponent<ThirdGradeScript> ().resultInputField.text = "";
					ThirdGrade.GetComponent<ThirdGradeScript> ().resultInputField.ActivateInputField ();
					ThirdGrade.GetComponent<ThirdGradeScript> ().CalculatingSystem ();
				}
				else if (GradeScript.fourthGrade == true)
				{
					FourthGrade.GetComponent<FourthGradeScript> ().resultInputField.text = "";
					FourthGrade.GetComponent<FourthGradeScript> ().resultInputField.ActivateInputField ();
					FourthGrade.GetComponent<FourthGradeScript> ().CalculatingSystem ();
				}
			}
		}

		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			Application.Quit ();
		}
	}
}