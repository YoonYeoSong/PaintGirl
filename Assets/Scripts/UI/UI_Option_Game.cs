﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Option_Game : MonoBehaviour {

	UIButton CloseBtn = null;
	UIButton GameOutBtn = null;

	Transform trans = null;

	UIProgressBar BgmPro = null; //배경음
	UIButton BgmPlus = null;
	UIButton BgmMinus = null;

	UIProgressBar SoundPro = null; //효과음
	UIButton SoundPlus = null;
	UIButton SoundMinus = null;

	private void Awake()
	{
		CloseBtn = transform.FindChild("BackGround").FindChild("Top").FindChild("Close").GetComponent<UIButton>();
		if (CloseBtn == null)
			Debug.Log("CloseBtn is null");
		EventDelegate.Add(CloseBtn.onClick, new EventDelegate(this, "ClosePanel")); //닫기버튼

		GameOutBtn = transform.FindChild("BackGround").FindChild("GameOutBtn").GetComponentInChildren<UIButton>();
		if (GameOutBtn == null)
			Debug.Log("GameOutBtn is null");
		EventDelegate.Add(GameOutBtn.onClick, new EventDelegate(this, "GoLobby")); // 게임포기 버튼

		

		BgmPro = transform.FindChild("BackGround").FindChild("BGM").FindChild("Progress").GetComponent<UIProgressBar>();
		if (BgmPro == null)
			Debug.Log("BgmPro is null");

		BgmPlus = transform.FindChild("BackGround").FindChild("BGM").FindChild("Plus").GetComponent<UIButton>();
		if (BgmPlus == null)
			Debug.Log("BgmPlus is null");
		EventDelegate.Add(BgmPlus.onClick, new EventDelegate(this, "PlusBGM")); // BGM+ 버튼

		BgmMinus = transform.FindChild("BackGround").FindChild("BGM").FindChild("Minus").GetComponent<UIButton>();
		if (BgmMinus == null)
			Debug.Log("BgmMinus is null");
		EventDelegate.Add(BgmMinus.onClick, new EventDelegate(this, "MinusBGM")); // BGM- 버튼


		SoundPro = transform.FindChild("BackGround").FindChild("Sound").FindChild("Progress").GetComponent<UIProgressBar>();
		if (SoundPro == null)
			Debug.Log("SoundPro is null");

		SoundPlus = transform.FindChild("BackGround").FindChild("Sound").FindChild("Plus").GetComponent<UIButton>();
		if (SoundPlus == null)
			Debug.Log("SoundPlus is null");
		EventDelegate.Add(SoundPlus.onClick, new EventDelegate(this, "PlusSound")); // Sound+ 버튼

		SoundMinus = transform.FindChild("BackGround").FindChild("Sound").FindChild("Minus").GetComponent<UIButton>();
		if (SoundMinus == null)
			Debug.Log("SoundMinus is null");
		EventDelegate.Add(SoundMinus.onClick, new EventDelegate(this, "MinusSound")); // Sound- 버튼
	}

	void ClosePanel() //닫기버튼클릭
	{
		Destroy(this.gameObject);
		//gameObject.SetActive(false);
		Debug.Log("닫기 클릭");
	}

	void PlusBGM() //배경음 볼륨조절
	{
		BgmPro.value += 0.1f;
		Debug.Log("bgm 볼륨상승");
	}

	void MinusBGM()
	{
		BgmPro.value -= 0.1f;
		Debug.Log("bgm 볼륨감소");
	}

	void PlusSound() //효과음 볼륨조절
	{
		SoundPro.value += 0.1f;
		Debug.Log("sound 볼륨상승");
	}

	void MinusSound()
	{
		SoundPro.value -= 0.1f;
		Debug.Log("sound 볼륨감소");
	}

	void GoLobby()
	{
		//UI_Popup
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(
			() =>
			{
				Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);

				
				
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			"게임 포기",
			"메인화면으로 돌아가시겠습니까?"
			);
		

		
	}
}
