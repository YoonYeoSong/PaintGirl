using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Store : MonoBehaviour {

	UIButton Gold = null;

	private void Awake()
	{
		Gold = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Little").FindChild("Btn").GetComponent<UIButton>();

		EventDelegate.Add(Gold.onClick, new EventDelegate(this, "ClickGold"));
	}
	void ClickGold()
	{
		Debug.Log("gold");
	}


}
