﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Main : BaseObject
{
	//float currTime = 0.0f;
	//Vector3 OriginPos = Vector3.zero;
	//GameObject NGUICamera = null;

	//UIButton MyRoomBtn = null;
	//UIButton MainBtn = null;
	//UIButton StoreBtn = null;

	//Vector3 M1 = Vector3.zero;
	//Vector3 M2 = Vector3.zero;
	//Vector3 M3 = Vector3.zero;
	//int CheckGoMenu = 0;
	//bool ArriveCheck = true;
	//float ChangeTime = 0.5f;

	//public void Awake()
	//{
		
		
	//	NGUICamera = gameObject.transform.parent.gameObject.transform.FindChild("Camera").gameObject;
	//	M1 = gameObject.transform.FindChild("BackGround").FindChild("M1").transform.position; 
	//	M2 = gameObject.transform.FindChild("BackGround").FindChild("M2").transform.position;
	//	M3 = gameObject.transform.FindChild("BackGround").FindChild("M3").transform.position;
	//	NGUICamera.transform.position = Vector3.zero;
	//	OriginPos = M2;

	//	Transform trans = gameObject.transform.parent.gameObject.transform.FindChild("Camera").FindChild("BottomBackGround").FindChild("Panel").FindChild("MyRoomBtn");
	//	if (trans == null)
	//	{
	//		Debug.LogError("MyRoomBtn is Not Founded");
	//		return;
	//	}
	//	MyRoomBtn = trans.GetComponent<UIButton>();
	//	EventDelegate.Add(MyRoomBtn.onClick, new EventDelegate(this, "ShowMyRoom"));


	//	trans = gameObject.transform.parent.gameObject.transform.FindChild("Camera").FindChild("BottomBackGround").FindChild("Panel").FindChild("MainBtn");

	//	if (trans == null)
	//	{
	//		Debug.LogError("MainBtn is not founded");
	//	}
	//	MainBtn = trans.GetComponent<UIButton>();

	//	EventDelegate.Add(MainBtn.onClick, () => { ShowMain(); });


	//	trans = gameObject.transform.parent.gameObject.transform.FindChild("Camera").FindChild("BottomBackGround").FindChild("Panel").FindChild("StoreBtn");

	//	if (trans == null)
	//	{
	//		Debug.LogError("StoreBtn is not founded");
	//	}
	//	StoreBtn = trans.GetComponent<UIButton>();
	//	EventDelegate.Add(StoreBtn.onClick, new EventDelegate(this, "ShowStore"));


	//	MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//	MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
	//	StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;


	//}

	//private void Update()
	//{

	//	if (CheckGoMenu == 1)
	//	{
	//		currTime += Time.deltaTime;
	//		NGUICamera.transform.position = Vector3.Lerp(OriginPos, M1,  currTime / ChangeTime);

	//		if (NGUICamera.transform.position == M1)
	//		{
	//			currTime = 0.0f;
	//			OriginPos = M1;
	//			ArriveCheck = true;
	//		}
	//	}
	//	else if (CheckGoMenu == 2)
	//	{
	//		currTime += Time.deltaTime;
	//		NGUICamera.transform.position = Vector3.Lerp(OriginPos, M2, currTime / ChangeTime);
	//		if (NGUICamera.transform.position == M2)
	//		{
	//			currTime = 0.0f;
	//			OriginPos = M2;
	//			ArriveCheck = true;
	//		}
	//	}
	//	else if (CheckGoMenu == 3)
	//	{
	//		currTime += Time.deltaTime;
	//		NGUICamera.transform.position = Vector3.Lerp(OriginPos, M3,currTime / ChangeTime);
	//		if (NGUICamera.transform.position == M3)
	//		{
	//			currTime = 0.0f;
	//			OriginPos = M3;
	//			ArriveCheck = true;
	//		}
	//	}
	//}


	//void ShowMyRoom()
	//{
	//	if (ArriveCheck == true)
	//	{
	//		CheckGoMenu = 1;
	//		ArriveCheck = false;
	//		MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
	//		MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//		StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//	}
		
	//}
	//void ShowMain()
	//{
	//	if (ArriveCheck == true)
	//	{
			
	//		CheckGoMenu = 2;
	//		ArriveCheck = false;
	//		MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//		MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
	//		StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//	}
	//	//NGUICamera.transform.position = Vector3.Lerp(OriginPos, M1, 1.0f);
	//}
	//void ShowStore()
	//{
	//	if (ArriveCheck == true)
	//	{
	//		CheckGoMenu = 3;
	//		ArriveCheck = false;
	//		MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//		MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
	//		StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
	//	}
	//	//NGUICamera.transform.position = Vector3.Lerp(OriginPos, M1, 1.0f);
	//	//GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_INVENTORY);
	//	//UI_Inventory inven = go.GetComponent<UI_Inventory>();
	//	//inven.Init();
	//	//inven.Reset();
	//}

}
