using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_LoadingBar : MonoBehaviour
{

	UIProgressBar ProgressBar;

	private void OnEnable()
	{
		if (ProgressBar == null)
		{
			ProgressBar = this.GetComponentInChildren<UIProgressBar>();
		}
	}

	public void SetValue(float _value)
	{
		if (ProgressBar == null)
			return;
		ProgressBar.value = _value;
	}

}