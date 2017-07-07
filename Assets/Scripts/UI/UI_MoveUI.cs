using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UI_MoveUI : MonoBehaviour
{

	float currTime = 0.0f;
	Vector3 OriginPos = Vector3.zero;
	GameObject NGUICamera = null;

	public GameObject SD_Action;
	//GameObject Render_Character;
	//GameObject Render_Gun;


	GameObject myroom = null;

	UIButton MyRoomBtn = null;
	UIButton MainBtn = null;
	UIButton StoreBtn = null;
	UIButton StartBtn = null;

	Vector3 M1 = new Vector3(-1480, 0, 0);
	Vector3 M2 = new Vector3(0, 0, 0);
	Vector3 M3 = new Vector3(1480, 0, 0);
	int CheckGoMenu = 0;
	bool ArriveCheck = true;
	float ChangeTime = 0.5f;



	public void Awake()
	{
		myroom = GameObject.Find("PF_UI_MYROOM");
		SD_Action = GameObject.Find("SD_Action");

		//Render_Character = GameObject.Find("Character_Render");
		//Render_Gun = GameObject.Find("Gun_Render");

		NGUICamera = gameObject.transform.parent.gameObject;
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

		trans = gameObject.transform.FindChild("BottomPanel").FindChild("StartBtn");

		if (trans == null)
		{
			Debug.LogError("StartBtn is not founded");
		}
		StartBtn = trans.GetComponent<UIButton>();
		//EventDelegate.Add(StartBtn.onClick, new EventDelegate(this, "GoGame"));
		EventDelegate.Add(StartBtn.onClick, new EventDelegate(this, "ShowStage"));



		

		MyRoomBtn.defaultColor = Color.green;
		MainBtn.defaultColor = Color.blue;
		StoreBtn.defaultColor = Color.green;
		StartBtn.defaultColor = Color.yellow;


	}

	private void Update()
	{

		if (CheckGoMenu == 1)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.localPosition = Vector3.Lerp(OriginPos, M1, currTime / ChangeTime);

			if (NGUICamera.transform.localPosition == M1)
			{
				currTime = 0.0f;
				OriginPos = M1;
				ArriveCheck = true;
			}
		}
		else if (CheckGoMenu == 2)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.localPosition = Vector3.Lerp(OriginPos, M2, currTime / ChangeTime);
			if (NGUICamera.transform.localPosition == M2)
			{
				currTime = 0.0f;
				OriginPos = M2;
				ArriveCheck = true;
			}
		}
		else if (CheckGoMenu == 3)
		{
			currTime += Time.deltaTime;
			NGUICamera.transform.localPosition = Vector3.Lerp(OriginPos, M3, currTime / ChangeTime);
			if (NGUICamera.transform.localPosition == M3)
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
			//Render_Character.SetActive(true);
			//Render_Gun.SetActive(true);

			myroom.GetComponent<UI_Myroom>().Inven_Charactor.GetComponent<UISprite>().depth = 3;
			myroom.GetComponent<UI_Myroom>().Inven_Weapon.GetComponent<UISprite>().depth = 2;

			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(true);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = true;

			//GameObject go = GameObject.FindGameObjectWithTag("Player");
			//go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 1;
			ArriveCheck = false;
			MyRoomBtn.defaultColor = Color.blue;
			MainBtn.gameObject.SetActive(true);
			StartBtn.gameObject.SetActive(false);
			MainBtn.defaultColor = Color.green;
			StoreBtn.defaultColor = Color.green;
		}

	}

	void ShowMain()
	{
		if (ArriveCheck == true)
		{
			//Render_Character.SetActive(true);
			//Render_Gun.SetActive(true);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = true;

			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(false);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			//GameObject go = GameObject.FindGameObjectWithTag("Player");
			//go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 2;
			ArriveCheck = false;
			MyRoomBtn.defaultColor = Color.green;
			MainBtn.defaultColor = Color.yellow;
			StoreBtn.defaultColor = Color.green;

			MainBtn.gameObject.SetActive(false);
			StartBtn.gameObject.SetActive(true);
		}

	}
	void ShowStore()
	{
		if (ArriveCheck == true)
		{
			//Render_Character.SetActive(true);
			//Render_Gun.SetActive(false);

			myroom.GetComponent<UI_Myroom>().Inven_Character_Model.SetActive(false);
			myroom.GetComponent<UI_Myroom>().Inven_Gun_Model.SetActive(false);

			SD_Action.GetComponent<CameraAction>().click = false;
			SD_Action.GetComponent<CameraAction>().enabled = false;

			GameObject go = GameObject.FindGameObjectWithTag("Player");
			go.transform.rotation = Quaternion.Euler(0, 180, 0);

			CheckGoMenu = 3;
			ArriveCheck = false;
			MyRoomBtn.defaultColor = Color.green;
			MainBtn.defaultColor = Color.green;
			StoreBtn.defaultColor = Color.blue;

			MainBtn.gameObject.SetActive(true);
			StartBtn.gameObject.SetActive(false);

		}

	}


	StageInfo Info = null;

	public StageInfo INFO
	{
		get
		{
			return Info;
		}
	}

	UILabel StageName = null;

	public void Init(StageInfo _info)
	{
		Info = _info;
		StageName = this.GetComponentInChildren<UILabel>();
		StageName.text = Info.NAME;

	}

	void GoGame()
	{

		//ameManager.Instance.SelectStage = int.Parse(INFO.KEY);
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_GAME);
		Debug.Log("게임 시작 !");
	}

	void ShowStage()
	{
	
		SceneManager.LoadScene ("PunBasics-Launcher");
		//GameObject.Find("Launcher").GetComponent<Launcher>().Connect();
		//GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_STAGE);
		//UI_Stage stage = go.GetComponent<UI_Stage>();
		//stage.Init();
	}


}
