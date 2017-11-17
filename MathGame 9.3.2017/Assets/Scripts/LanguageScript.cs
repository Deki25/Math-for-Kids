using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguageScript : MonoBehaviour
{
	public static bool isEnglish = false;
	public static bool isSerbian = false;

	public void OnClickEnglish()
	{
		isEnglish = true;
	}

	public void OnClickSerbian()
	{
		isSerbian = true;
	}
}
