using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Game : MonoBehaviour {

	UIButton OptionBtn = null;
	UIButton JumpBtn = null;
	UIButton SlideBtn = null;
	UIButton MapBtn = null;
	UIButton MapCloseBtn = null;

	GameObject MapPrefab;
	GameObject MiniMap = null;
	private void Awake()
	{
		MapPrefab = Resources.Load("Prefabs/UI/PF_UI_MiniMap") as GameObject;
		
		OptionBtn =	transform.FindChild("Top").FindChild("Option").FindChild("Btn").GetComponent<UIButton>();
		if (OptionBtn == null)
			Debug.Log("OptionBtn is null");

		EventDelegate.Add(OptionBtn.onClick, new EventDelegate(this,"ShowOption"));

		JumpBtn = transform.FindChild("BackGround").FindChild("JumpBtn").GetComponent<UIButton>();
		if (JumpBtn == null)
			Debug.Log("JumpBtn is null");

		EventDelegate.Add(JumpBtn.onClick, new EventDelegate(this, "PlayerJump"));

		SlideBtn = transform.FindChild("BackGround").FindChild("SlideBtn").GetComponent<UIButton>();
		if (SlideBtn == null)
			Debug.Log("SlideBtn is null");

		EventDelegate.Add(SlideBtn.onClick, new EventDelegate(this, "PlayerSlide"));

		MapBtn = transform.FindChild("BackGround").FindChild("MiniMapBtn").GetComponent<UIButton>();
		if (MapBtn == null)
			Debug.Log("MapBtn is null");

		EventDelegate.Add(MapBtn.onClick, new EventDelegate(this, "ShowMap"));



	}

	void ShowOption()
	{
		GameObject OptionPrefab;
		OptionPrefab = Resources.Load("Prefabs/UI/PF_UI_OptionPanel_InGame") as GameObject;
		NGUITools.AddChild(gameObject.transform.parent.gameObject, OptionPrefab);
		Debug.Log("옵션오픈");
	}

	void PlayerJump()
	{
		Debug.Log("점프!");
	}

	void PlayerSlide()
	{
		Debug.Log("슬라이드!");
	}

	void ShowMap()
	{

		MiniMap = NGUITools.AddChild(gameObject.transform.parent.gameObject, MapPrefab);
		//MiniMap.transform.localPosition = new Vector3(-388, 87, 0);
		MapCloseBtn = MiniMap.GetComponent<UIButton>();
		EventDelegate.Add(MapCloseBtn.onClick, new EventDelegate(this, "CloseMap"));
	}

	void CloseMap()
	{
		Debug.Log("미니맵종료");
		Destroy(MiniMap);
	}

}
