using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSetting : MonoBehaviour
{
	UI_MoveUI MoveUIScr = null;

	int Gold;
	int Cash;
	int Exp;

	public void Awake()
	{
		//PlayerPrefs.DeleteAll(); //데이터 초기화

		MoveUIScr = transform.parent.FindChild("UI Root").FindChild("Camera").FindChild("BaseGround").GetComponent<UI_MoveUI>();

		if (MoveUIScr == null)
			Debug.Log("MoveUIScr가 NULL입니다.");

		Gold = 100;
		Cash = 1000;
		Exp = 10;

		//MoveUIScr.GoldLabel.text = 100.ToString();

		if (PlayerPrefs.HasKey("GoldKey") == false)
		{
			PlayerPrefs.SetInt("GoldKey", Gold);
		}

		//Gold = PlayerPrefs.GetInt("GoldKey");



		

		if (PlayerPrefs.HasKey("CashKey") == false)
		{
			PlayerPrefs.SetInt("CashKey", Cash);
		}

		//	Cash = PlayerPrefs.GetInt("CashKey");



		if (PlayerPrefs.HasKey("ExpKey") == false)
		{
			PlayerPrefs.SetInt("ExpKey", Exp);
		}


	}

		public void Update()
		{
			Gold = PlayerPrefs.GetInt("GoldKey");
			Cash = PlayerPrefs.GetInt("CashKey");
			Exp = PlayerPrefs.GetInt("ExpKey");


			MoveUIScr.GoldLabel.text = Gold.ToString();
			MoveUIScr.CashLabel.text = Cash.ToString();
			MoveUIScr.EXPLabel.text = Exp.ToString();
		}
	
}
