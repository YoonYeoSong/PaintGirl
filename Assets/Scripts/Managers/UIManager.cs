using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
	UILabel label;
	// DontDestroyOnLoad 하지 않기 위해
	public override void Init()
	{
		label = transform.FindChild("GameOverLabel").GetComponent<UILabel>();
	}

	public void SetText(bool iskill, float data)
	{
		if(iskill)
		{
			label.text = "KILL COUNT : " + ((int)data).ToString();
		}
		else
		{
			label.text = string.Format("Time {0} : {1}", (int)data / 60, (int)data % 60);
		}
	}
}
