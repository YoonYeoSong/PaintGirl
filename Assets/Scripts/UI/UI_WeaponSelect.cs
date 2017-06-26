using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_WeaponSelect : MonoBehaviour {

	UI_Myroom Myroom = null;
	int Weapon_name = 0;
	bool check = true; // 이름을 처음만 빼기위해 선언
	private void Awake()
	{
		Myroom = gameObject.transform.parent.parent.parent.parent.parent.GetComponent<UI_Myroom>();

	}
	// Use this for initialization



	// Update is called once per frame
	void Update()
	{

	}

	void OnClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();


		popup.Set(
			() =>
			{
				if (check == true)
				{
					gameObject.name = this.gameObject.name.Substring(14, 1);
					check = false;
				}
				Debug.Log(gameObject.name);
				int.TryParse(this.gameObject.name, out Weapon_name);
				//ItemManager.Instance.EquipItem(itemInstance);
				Myroom.ChangeWeapon(Weapon_name - 1);
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			}
			,
			"무기 선택"
			,
			"이 무기를 선택 하시겠습니까?"
			);
	}
}
