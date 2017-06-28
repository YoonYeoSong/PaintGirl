using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Option_Main : MonoBehaviour {

	UIButton Close = null;
	UIButton Facebook = null;
	UIButton Google = null;

	Transform trans = null;

	private void Awake()
	{
		Close = transform.FindChild("BackGround").FindChild("Close").FindChild("Btn").GetComponent<UIButton>();

		EventDelegate.Add(Close.onClick, new EventDelegate(this, "ClosePanel"));

	}

	void ClosePanel()
	{
		gameObject.SetActive(false);
	}


}
