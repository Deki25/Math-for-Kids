using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour 
{
	public static int right = 0;
	public static int wrong = 0;
	public static int question = 1;
	public static int maxTest = 15;

	public static void AddPointRight()
	{
		right++;
	}

	public static void AddPointWrong()
	{
		wrong++;
	}
}
