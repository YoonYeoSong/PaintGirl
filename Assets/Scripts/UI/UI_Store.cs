using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Store : MonoBehaviour
{
	Transform GoldLittle = null;
	UIButton GoldLittleBtn = null;

	Transform GoldMiddle = null;
	UIButton GoldMiddleBtn = null;

	Transform GoldMany = null;
	UIButton GoldManyBtn = null;

<<<<<<< HEAD
	float ArrTime = 1.0f;
	float CurTime = 0.0f;
	bool check = false;
=======
	Transform CashLittle = null;
	UIButton CashLittleBtn = null;

	Transform CashMiddle = null;
	UIButton CashMiddleBtn = null;

	Transform CashMany = null;
	UIButton CashManyBtn = null;

	Vector3 GoldGoalPosition;
	GameObject GoldPrepab = null;
	GameObject Gold = null;
	GameObject CashPrepab = null;
	GameObject Cash = null;


	float CurTime = 0.0f;
	float ArrTime = 2.0f;
	
	int CurrentGold = 0;
	int GoldLittleCount = 5;
	int GoldMiddleCount = 10;
	int GoldManyCount = 20;
	int CurrentCash = 0;
	int CashLittleCount = 5;
	int CashMiddleCount = 10;
	int CashManyCount = 20;

>>>>>>> 553b654560aa054027dc58a505c7638bce7d2da4
	private void Awake()
	{
		GoldLittle = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Little");
		GoldMiddle = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Middle");
		GoldMany = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Many");


		GoldLittleBtn = GoldLittle.GetComponent<UIButton>();
		GoldMiddleBtn = GoldMiddle.GetComponent<UIButton>();
		GoldManyBtn = GoldMany.GetComponent<UIButton>();

		CashLittle = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Cash").FindChild("ScrollView").FindChild("Grid").FindChild("Cash_Little");
		CashMiddle = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Cash").FindChild("ScrollView").FindChild("Grid").FindChild("Cash_Middle");
		CashMany = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Cash").FindChild("ScrollView").FindChild("Grid").FindChild("Cash_Many");

		CashLittleBtn = CashLittle.GetComponent<UIButton>();
		CashMiddleBtn = CashMiddle.GetComponent<UIButton>();
		CashManyBtn = CashMany.GetComponent<UIButton>();

		EventDelegate.Add(GoldLittleBtn.onClick, new EventDelegate(this, "LittleGoldClick"));
		EventDelegate.Add(GoldMiddleBtn.onClick, new EventDelegate(this, "MiddleGoldClick"));
		EventDelegate.Add(GoldManyBtn.onClick, new EventDelegate(this, "ManyGoldClick"));

		EventDelegate.Add(CashLittleBtn.onClick, new EventDelegate(this, "LittleCashClick"));
		EventDelegate.Add(CashMiddleBtn.onClick, new EventDelegate(this, "MiddleCashClick"));
		EventDelegate.Add(CashManyBtn.onClick, new EventDelegate(this, "ManyCashClick"));

		GoldPrepab = Resources.Load("Prefabs/Store/Gold") as GameObject;
		CashPrepab = Resources.Load("Prefabs/Store/Cash") as GameObject;

		if (GoldPrepab == null)
			Debug.Log("동전을 못불러옵니다");

		if (CashPrepab == null)
			Debug.Log("CashPrepab을 못불러옵니다");
	}
	void LittleGoldClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
	

		popup.Set(
			() =>
			{
				Debug.Log("gold");
						
				InvokeRepeating("GoldLittleAnimation", 0.0f, 0.1f);
				
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 소량 구매"
			,
			"크리스탈 10개로 100골드를 구매 하시겠습니까?"
			);
	}

	void MiddleGoldClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
	

		popup.Set(
			() =>
			{
				Debug.Log("gold");

				InvokeRepeating("GoldMiddleAnimation", 0.0f, 0.1f);

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 중량 구매"
			,
			"크리스탈 40개로 500골드를 구매 하시겠습니까?"
			);
	}

	void ManyGoldClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
	

		popup.Set(
			() =>
			{
				InvokeRepeating("GoldManyAnimation", 0.0f, 0.1f);

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 대량 구매"
			,
			"크리스탈 100개로 1500골드를 구매 하시겠습니까?"
			);
	}

	void GoldLittleAnimation()
	{
		
			CurrentGold++;
			Debug.Log("현재 골드 : " + CurrentGold);
			Gold = Instantiate(GoldPrepab, Vector3.zero, Quaternion.identity, GoldLittle);
			Debug.Log(Gold);
			Gold.transform.localScale = Vector3.one;
			Gold.transform.localPosition = Vector3.zero;
			Gold.transform.parent = transform.parent.FindChild("Camera");
		if (GoldLittleCount <= CurrentGold)
		{
			CancelInvoke("GoldLittleAnimation");
			CurrentGold = 0;
		}
	}

	void GoldMiddleAnimation()
	{

		CurrentGold++;
		Debug.Log("현재 골드 : " + CurrentGold);
		Gold = Instantiate(GoldPrepab, Vector3.zero, Quaternion.identity, GoldMiddle);
		Debug.Log(Gold);
		Gold.transform.localScale = Vector3.one;
		Gold.transform.localPosition = Vector3.zero;
		Gold.transform.parent = transform.parent.FindChild("Camera");
		if (GoldMiddleCount <= CurrentGold)
		{
			CancelInvoke("GoldMiddleAnimation");
			CurrentGold = 0;
		}
	}

	void GoldManyAnimation()
	{

		CurrentGold++;
		Debug.Log("현재 골드 : " + CurrentGold);
		Gold = Instantiate(GoldPrepab, Vector3.zero, Quaternion.identity, GoldMany);
		Debug.Log(Gold);
		Gold.transform.localScale = Vector3.one;
		Gold.transform.localPosition = Vector3.zero;
		Gold.transform.parent = transform.parent.FindChild("Camera");
		if (GoldManyCount <= CurrentGold)
		{
			CancelInvoke("GoldManyAnimation");
			CurrentGold = 0;
		}
	}

	void LittleCashClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
		

		popup.Set(
			() =>
			{
				Debug.Log("gold");

				InvokeRepeating("CashLittleAnimation", 0.0f, 0.1f);

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 소량 구매"
			,
			"크리스탈 10개로 100골드를 구매 하시겠습니까?"
			);
	}

	void MiddleCashClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
		

		popup.Set(
			() =>
			{
				Debug.Log("gold");

				InvokeRepeating("CashMiddleAnimation", 0.0f, 0.1f);

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 중량 구매"
			,
			"크리스탈 40개로 500골드를 구매 하시겠습니까?"
			);
	}

	void ManyCashClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
		

		popup.Set(
			() =>
			{
				InvokeRepeating("CashManyAnimation", 0.0f, 0.1f);

				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"골드 대량 구매"
			,
			"크리스탈 100개로 1500골드를 구매 하시겠습니까?"
			);
	}

	void CashLittleAnimation()
	{

		CurrentCash++;
		Debug.Log("현재 보석 : " + CurrentCash);
		Cash = Instantiate(CashPrepab, Vector3.zero, Quaternion.identity, CashLittle);
		Debug.Log(Cash);
		Cash.transform.localScale = Vector3.one;
		Cash.transform.localPosition = Vector3.zero;
		Cash.transform.parent = transform.parent.FindChild("Camera");
		if (CashLittleCount <= CurrentCash)
		{
<<<<<<< HEAD
			CurTime += Time.deltaTime;
			Vector3.Lerp(GoldLittleBtn.transform.position, GoalPosition, CurTime/ ArrTime);
=======
			CancelInvoke("CashLittleAnimation");
			CurrentCash = 0;
		}
	}

	void CashMiddleAnimation()
	{
>>>>>>> 553b654560aa054027dc58a505c7638bce7d2da4

		CurrentCash++;
		Debug.Log("현재 보석 : " + CurrentCash);
		Cash = Instantiate(CashPrepab, Vector3.zero, Quaternion.identity, CashMiddle);
		Debug.Log(Cash);
		Cash.transform.localScale = Vector3.one;
		Cash.transform.localPosition = Vector3.zero;
		Cash.transform.parent = transform.parent.FindChild("Camera");
		if (CashMiddleCount <= CurrentCash)
		{
			CancelInvoke("CashMiddleAnimation");
			CurrentCash = 0;
		}
	}

	void CashManyAnimation()
	{

		CurrentCash++;
		Debug.Log("현재 보석 : " + CurrentCash);
		Cash = Instantiate(CashPrepab, Vector3.zero, Quaternion.identity, CashMany);
		Debug.Log(Cash);
		Cash.transform.localScale = Vector3.one;
		Cash.transform.localPosition = Vector3.zero;
		Cash.transform.parent = transform.parent.FindChild("Camera");
		if (CashManyCount <= CurrentCash)
		{
			CancelInvoke("CashManyAnimation");
			CurrentCash = 0;
		}
	}


}
