using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradeScript : MonoBehaviour
{
	public static bool firstGrade = false;
	public static bool secondGrade = false;
	public static bool thirdGrade = false;
	public static bool fourthGrade = false;

	public void OnClickFirst()
	{
		firstGrade = true;
	}

	public void OnClickSecond()
	{
		secondGrade = true;
	}

	public void OnClickThird()
	{
		thirdGrade = true;
	}

	public void OnClickFourth()
	{
		fourthGrade = true;
	}
}
