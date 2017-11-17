using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseGenderScript : MonoBehaviour 
{
	public static bool isBoy = false;
	public static bool isGirl = false;

	public void OnClickBoy()
	{
		isBoy = true;
	}

	public void OnClickGirl()
	{
		isGirl = true;
	}
}
