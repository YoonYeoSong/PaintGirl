using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_MoveUI : MonoBehaviour {

	float currTime = 0.0f;
	Vector3 OriginPos = Vector3.zero;
	GameObject NGUICamera = null;

	public GameObject SD_Action;
	GameObject Render_Character;
	GameObject Render_Gun;


	GameObject myroom = null;

	UIButton MyRoomBtn = null;
	UIButton MainBtn = null;
	UIButton StoreBtn = null;

	Vector3 M1 = Vector3.zero;
	Vector3 M2 = Vector3.zero;
	Vector3 M3 = Vector3.zero;
	int CheckGoMenu = 0;
	bool ArriveCheck = true;
	float ChangeTime = 0.5f;

	public void Awake()
	{
		myroom = GameObject.Find("PF_UI_MYROOM");
		SD_Action = GameObject.Find("SD_Action");

		Render_Character = GameObject.Find("Character_Render");
		Render_Gun = GameObject.Find("Gun_Render");

		NGUICamera = gameObject.transform.parent.gameObject;
		M1 = gameObject.transform.parent.parent.FindChild("PF_UI_MAIN").FindChild("BackGround").FindChild("M1").transform.position;
		M2 = gameObject.transform.parent.parent.FindChild("PF_UI_MAIN").FindChild("BackGround").FindChild("M2").transform.position;
		M3 = gameObject.transform.parent.parent.FindChild("PF_UI_MAIN").FindChild("BackGround").FindChild("M3").transform.position;
		NGUICamera.transform.position = Vector3.zero;
		OriginPos = M2;

		Transform trans = gameObject.transform.FindChild("BottomPanel").FindChild("MyRoomBtn");
		if (trans == null)
		{
			Debug.LogError("MyRoomBtn is Not Founded");
			return;
		}
		MyRoomBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(MyRoomBtn.onClick, new EventDelegate(this, "ShowMyRoom"));


		trans = gameObject.transform.FindChild("BottomPanel").FindChild("MainBtn");

		if (trans == null)
		{
			Debug.LogError("MainBtn is not founded");
		}
		MainBtn = trans.GetComponent<UIButton>();

		EventDelegate.Add(MainBtn.onClick, () => { ShowMain(); });


		trans = gameObject.transform.FindChild("BottomPanel").FindChild("StoreBtn");

		if (trans == null)
		{
			Debug.LogError("StoreBtn is not founded");
		}
		StoreBtn = trans.GetComponent<UIButton>();
		EventDelegate.Add(StoreBtn.onClick, new EventDelegate(this, "ShowStore"));


		MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
		MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
		StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;


	}

	private void Update()
	{

		if (CheckGoMenu == 1)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.position = Vector3.Lerp(OriginPos, M1, currTime / ChangeTime);

			if (NGUICamera.transform.position == M1)
			{
				currTime = 0.0f;
				OriginPos = M1;
				ArriveCheck = true;
			}
		}
		else if (CheckGoMenu == 2)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.position = Vector3.Lerp(OriginPos, M2, currTime / ChangeTime);
			if (NGUICamera.transform.position == M2)
			{
				currTime = 0.0f;
				OriginPos = M2;
				ArriveCheck = true;
			}
		}
		else if (CheckGoMenu == 3)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.position = Vector3.Lerp(OriginPos, M3, currTime / ChangeTime);
			if (NGUICamera.transform.position == M3)
			{
				currTime = 0.0f;
				OriginPos = M3;
				ArriveCheck = true;
			}
		}
	}


	void ShowMyRoom()
	{
		if (ArriveCheck == true)
		{
			Render_Character.SetActive(false);
			Render_Gun.SetActive(false);

			myroom.GetComponent<UI_Myroom>().Inven_Charactor.GetComponent<UISprite>().depth = 3;
			myroom.GetComponent<UI_Myroom>().Inven_Weapon.GetComponent<UISprite>().depth = 2;

			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(true);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = true;

			GameObject go = GameObject.FindGameObjectWithTag("SD_Character");
			go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 1;
			ArriveCheck = false;
			MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
			MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
			StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
		}

	}

	void ShowMain()
	{
		if (ArriveCheck == true)
		{
			Render_Character.SetActive(true);
			Render_Gun.SetActive(true);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = true;
			
			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(false);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			GameObject go = GameObject.FindGameObjectWithTag("SD_Character");
			go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 2;
			ArriveCheck = false;
			MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
			MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
			StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
		}

	}
	void ShowStore()
	{
		if (ArriveCheck == true)
		{
			Render_Character.SetActive(false);
			Render_Gun.SetActive(false);

			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(false);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = false;

			GameObject go = GameObject.FindGameObjectWithTag("SD_Character");
			go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 3;
			ArriveCheck = false;
			MyRoomBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
			MainBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.white;
			StoreBtn.gameObject.transform.FindChild("Image").GetComponent<UISprite>().color = Color.blue;
		}

	}
}
