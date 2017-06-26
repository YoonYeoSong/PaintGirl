using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Myroom : MonoBehaviour {

	UIButton Inven_Charactor_btn = null; //선택 탭 버튼
	UIButton Inven_Weapon_btn = null;
	public UISprite Inven_Charactor = null; // 보이기 위한 선언
	public UISprite Inven_Weapon = null;
	GameObject Inven_CharactorShow = null; // 아이콘 보이기 위한 선언
	GameObject Inven_WeaponShow = null;


	public GameObject Inven_Character_Model = null;
	public GameObject Inven_Gun_Model = null;

	GameObject PastCharacter = null; //이전 서있는 캐릭터
	GameObject NowCharacter = null; // 바꿀 서있는 캐릭터

	GameObject PastWeapon = null; //이전 서있는 무기
	GameObject NowWeapon = null; // 바꿀 서있는 무기


	private void Awake()
	{
		Inven_Charactor_btn = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").FindChild("Btn").GetComponent<UIButton>();
		Inven_Charactor = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").GetComponent<UISprite>();

		Inven_Weapon_btn = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").FindChild("Btn").GetComponent<UIButton>();
		Inven_Weapon = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").GetComponent<UISprite>();

		Inven_CharactorShow = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").FindChild("ScrollView").gameObject;
		Inven_WeaponShow = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").FindChild("ScrollView").gameObject;


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

		Inven_CharactorShow.SetActive(true);
		Inven_WeaponShow.SetActive(false);

		PastCharacter = GameObject.Find("SD_Basic").gameObject;
		PastWeapon = GameObject.Find("ShotGun").gameObject;
	}

	void ShowInven_Charactor()
	{
		Inven_Charactor.depth = 3;
		Inven_Weapon.depth = 2;
		Inven_CharactorShow.SetActive(true);
		Inven_WeaponShow.SetActive(false);
		Inven_Character_Model.SetActive(true);
		Inven_Gun_Model.SetActive(false);
	}

	void ShowInven_Weapon()
	{
		Inven_Charactor.depth = 2;
		Inven_Weapon.depth = 3;
		Inven_CharactorShow.SetActive(false);
		Inven_WeaponShow.SetActive(true);

		Inven_Character_Model.SetActive(false);
		Inven_Gun_Model.SetActive(true);
	}

	public void ChangeCharacter(int i)
	{
		if (NowCharacter != null)
			Destroy(NowCharacter);

		if(PastCharacter != null)
		Destroy(PastCharacter);

		UITexture trans = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Charactor").FindChild("ScrollView").FindChild("Grid").GetChild(i).GetComponent<UITexture>();

		Debug.Log(trans.mainTexture.name);
		GameObject temp = Resources.Load(ConstValue.Character_Prefab + "/" + trans.mainTexture.name) as GameObject;

		Debug.Log(temp);
		NowCharacter = Instantiate(temp, new Vector3(-8.61f, 0, 0), Quaternion.Euler(0,180,0));

		//NowCharacter = Instantiate()
	}

	public void ChangeWeapon(int i)
	{
		if (NowWeapon != null)
			Destroy(NowWeapon);

		if (PastWeapon != null)
			Destroy(PastWeapon);

		UITexture trans = gameObject.transform.FindChild("BackGround").FindChild("Inventory_Weapon").FindChild("ScrollView").FindChild("Grid").GetChild(i).GetComponent<UITexture>();

		Debug.Log(trans.mainTexture.name);
		GameObject temp = Resources.Load(ConstValue.Weapon_Prefab + "/" + trans.mainTexture.name) as GameObject;

		Debug.Log(temp);
		NowWeapon = Instantiate(temp, new Vector3(-11.12f, 0.42f, 0.19f), Quaternion.Euler(0, 180, 0));

	}
}
