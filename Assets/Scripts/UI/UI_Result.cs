﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Result : MonoBehaviour {

	UIButton GoMainBtn = null;
	UIButton ReGameBtn = null;

	UILabel TitleText = null;
	UILabel GoldText = null;
	UILabel CashText = null;
	UILabel ExpText = null;

	int Victory = 0;
	int ReWordValue = 0;
	private void Awake()
	{
		GoMainBtn = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("LobbyBtn").GetComponent<UIButton>();
		if (GoMainBtn == null)
			Debug.Log("GoMainBtn is null");
		EventDelegate.Add(GoMainBtn.onClick, new EventDelegate(this, "GoLobby")); //로비버튼


		ReGameBtn = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("GameBtn").GetComponent<UIButton>();
		if (ReGameBtn == null)
			Debug.Log("ReGameBtn is null");
		EventDelegate.Add(ReGameBtn.onClick, new EventDelegate(this, "ReGame")); //재시작버튼

		TitleText = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("Title").GetComponent<UILabel>();

		GoldText = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("Reward").FindChild("BackGround").FindChild("Gold").FindChild("Text").GetComponent<UILabel>();

		CashText = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("Reward").FindChild("BackGround").FindChild("Cash").FindChild("Text").GetComponent<UILabel>();

		ExpText = transform.FindChild("BackPanel").FindChild("BackGround").FindChild("Reward").FindChild("BackGround").FindChild("EXP").FindChild("Text").GetComponent<UILabel>();

		Victory = 1;
		Reword();

	}

	void GoLobby()
	{
		Time.timeScale = 1.0f;
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);
	}

	void ReGame()
	{
		Debug.Log("게임 재시작!");
	}

	void Reword()
	{

		if (Victory == 1) // 승리시
		{
			TitleText.text = "승리 !";
			TitleText.color = Color.blue;

			ReWordValue = Random.RandomRange(100, 200);
			GoldText.text = ReWordValue.ToString();

			ReWordValue = Random.RandomRange(100, 200);
			CashText.text = ReWordValue.ToString();

			ReWordValue = Random.RandomRange(100, 200);
			ExpText.text = ReWordValue.ToString();

		}

		if (Victory == 2) // 패배시 
		{
			TitleText.text = "패배 !";
			TitleText.color = Color.red;
			ReWordValue = Random.RandomRange(10, 50);
			GoldText.text = ReWordValue.ToString();

			ReWordValue = Random.RandomRange(10, 50);
			CashText.text = ReWordValue.ToString();

			ReWordValue = Random.RandomRange(10, 50);
			ExpText.text = ReWordValue.ToString();
		}

	}
}