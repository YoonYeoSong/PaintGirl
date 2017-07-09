using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Store : MonoBehaviour
{

	UIButton GoldLittleBtn = null;
	UIButton GoldMiddleBtn = null;
	UIButton GoldManyBtn = null;
	Vector3 GoalPosition = new Vector3(85, 304, 0);

	float ArrTime = 1.0f;
	float CurTime = 0.0f;
	bool check = false;
	private void Awake()
	{
		GoldLittleBtn = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Little").GetComponent<UIButton>();
		GoldMiddleBtn = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Middle").GetComponent<UIButton>();
		GoldManyBtn = transform.FindChild("BackGround").FindChild("ScrollView").FindChild("Grid").FindChild("Store_Gold").FindChild("ScrollView").FindChild("Grid").FindChild("Gold_Many").GetComponent<UIButton>();


		EventDelegate.Add(GoldLittleBtn.onClick, new EventDelegate(this, "ClickGold"));
		EventDelegate.Add(GoldMiddleBtn.onClick, new EventDelegate(this, "ClickGold"));
		EventDelegate.Add(GoldManyBtn.onClick, new EventDelegate(this, "ClickGold"));

	}
	void ClickGold()
	{



		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();
		int count = 20;

		popup.Set(
			() =>
			{
				Debug.Log("gold");
				int i = 0;
				for ( i = 0; i < 5; i++)
				{
					StartCoroutine("GoldAnimation");
					Debug.Log("반복문실행");
				}
				if (i == 5)
					check = true;
				//ItemManager.Instance.EquipItem(itemInstance);
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"캐릭터 선택"
			,
			"이 캐릭터를 선택 하시겠습니까?"
			);
	}

	IEnumerator GoldAnimation()
	{
		Debug.Log("실행");
		
		GameObject temp = Resources.Load("Prefabs/UI/Gold") as GameObject;
		GameObject Gold = null;
		Debug.Log(temp);
		Gold = Instantiate(temp, new Vector3(0, 0, 0), Quaternion.identity, gameObject.transform);
		Gold.transform.localScale = Vector3.one;
		yield return new WaitForSeconds(1.0f);
	}

	public void Update()
	{
		if (check == true)
		{
			CurTime += Time.deltaTime;
			Vector3.Lerp(GoldLittleBtn.transform.position, GoalPosition, CurTime/ ArrTime);

		}

		if (GoldLittleBtn.transform.position == GoalPosition)
			check = false;
	}
}
