using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Myroom : MonoBehaviour {

	UIButton Inven_Charactor_btn = null;
	UIButton Inven_Weapon_btn = null;
	public UISprite Inven_Charactor = null;
	public UISprite Inven_Weapon = null;

 	public GameObject Inven_Character_Model = null;
	public GameObject Inven_Gun_Model = null;

	private void Awake()
	{
		Inven_Charactor_btn = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").FindChild("Btn").GetComponent<UIButton>();
		Inven_Charactor = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").GetComponent<UISprite>();

		Inven_Weapon_btn = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").FindChild("Btn").GetComponent<UIButton>();
		Inven_Weapon = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").GetComponent<UISprite>();


		if (Inven_Charactor_btn == null)
			Debug.LogError("Inven_Charactor_btn is null");
		if (Inven_Charactor == null)
			Debug.LogError("Inven_Charactor is null");

		if (Inven_Weapon_btn == null)
			Debug.LogError("Inven_Weapon_btn is null");
		if (Inven_Weapon == null)
			Debug.LogError("Inven_Weapon is null");

		EventDelegate.Add(Inven_Charactor_btn.onClick, new EventDelegate(this, "ShowInven_Charactor"));
		EventDelegate.Add(Inven_Weapon_btn.onClick, new EventDelegate(this, "ShowInven_Weapon"));

	}

	void ShowInven_Charactor()
	{
		Inven_Charactor.depth = 3;
		Inven_Weapon.depth = 2;
		Inven_Character_Model.SetActive(true);
		Inven_Gun_Model.SetActive(false);
	}

	void ShowInven_Weapon()
	{
		Inven_Charactor.depth = 2;
		Inven_Weapon.depth = 3;
		Inven_Character_Model.SetActive(false);
		Inven_Gun_Model.SetActive(true);
	}

}
