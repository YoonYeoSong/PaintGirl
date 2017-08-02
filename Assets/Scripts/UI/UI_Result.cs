using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Result : MonoBehaviour {

	UIButton GoMainBtn = null;
	UIButton ReGameBtn = null;

	UILabel TitleText = null;
	UILabel GoldText = null;
	UILabel CashText = null;
	UILabel ExpText = null;

    TestBoard testboard = null;

    float CurTime = 0.0f;
	int Victory = 0;
	int ReWordValue = 0;
    bool Timedelay = false;

    public void Start()
    {
     //   testboard = GameObject.Find("PF_UI_RESULT").GetComponentInChildren<TestBoard>();


        //testboard = transform.GetComponent<TestBoard>();
        if (testboard == null)
            Debug.Log("테스트 보드 널");


    }

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

    private void Update()
    {
        CurTime += Time.deltaTime;

        if(CurTime >= 0.3f && Timedelay == true)
        timedeley();
    }
    void GoLobby()
	{
        Timedelay = false;

        Time.timeScale = 1.0f;
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);

	}

	void ReGame()
	{
		Debug.Log("게임 재시작!");
	}

    void timedeley()
    {


        Time.timeScale = 0.01f;
    }

	void Reword()
	{
        
		if (Victory == 1) // 승리시
		{
			TitleText.text = "승리 !";
			TitleText.color = Color.blue;

			int value;

			ReWordValue = Random.RandomRange(100, 200);
			GoldText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("GoldKey");
			PlayerPrefs.SetInt("GoldKey", ReWordValue + value);

			ReWordValue = Random.RandomRange(100, 200);
			CashText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("CashKey");
			PlayerPrefs.SetInt("CashKey", ReWordValue + value);

			ReWordValue = Random.RandomRange(100, 200);
			ExpText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("ExpKey");
			PlayerPrefs.SetInt("ExpKey", ReWordValue + value);

		}

		if (Victory == 2) // 패배시 
		{
			int value;

			TitleText.text = "패배 !";
			TitleText.color = Color.red;
			ReWordValue = Random.RandomRange(10, 50);
			GoldText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("GoldKey");
			PlayerPrefs.SetInt("GoldKey", ReWordValue + value);

			ReWordValue = Random.RandomRange(10, 50);
			CashText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("CashKey");
			PlayerPrefs.SetInt("CashKey", ReWordValue + value);

			ReWordValue = Random.RandomRange(10, 50);
			ExpText.text = ReWordValue.ToString();
			value = PlayerPrefs.GetInt("ExpKey");
			PlayerPrefs.SetInt("ExpKey", ReWordValue + value);

		}

        CurTime = 0.0f;
        Timedelay = true;

    }
}
