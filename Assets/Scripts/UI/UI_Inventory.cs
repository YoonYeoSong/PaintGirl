using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Inventory : BaseObject {

	bool IsInit = false;

	GameObject ItemPrefab = null;

	UIGrid Grid;
	UIButton CloseBtn = null;

	UILabel WeaponLabel = null;
	UILabel HelmetLabel = null;
	UILabel GuntletLabel = null;
	UILabel Armorlabel = null;

	public void Init()
	{
		if (IsInit == true)
			return;

		ItemPrefab = Resources.Load("Prefabs/UI/PF_UI_ITEM") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();

		CloseBtn = FindInChild("CloseBtn").GetComponent<UIButton>();
		EventDelegate.Add(CloseBtn.onClick, new EventDelegate(this, "HideInventory"));

		WeaponLabel = FindInChild("Weapon").FindChild("ItemName").GetComponent<UILabel>();
		HelmetLabel = FindInChild("Helmet").FindChild("ItemName").GetComponent<UILabel>();
		GuntletLabel = FindInChild("Guntlet").FindChild("ItemName").GetComponent<UILabel>();
		Armorlabel = FindInChild("Armor").FindChild("ItemName").GetComponent<UILabel>();

		EquipItemReset();

		ItemManager.Instance.EquipE = EquipItemReset;
		IsInit = true;

	}

	public void Reset()
	{

		for (int i = 0; i< Grid.transform.childCount; i++)
		{
			Destroy(Grid.transform.GetChild(i).gameObject);
		}
		AddItem();
	}

	void AddItem()
	{
		List<ItemInstance> list = ItemManager.Instance.LIST_ITEM;
		for(int i = 0; i < list.Count; i++)
		{
			GameObject go = Instantiate(ItemPrefab, Grid.transform) as GameObject;
			go.transform.localScale = Vector3.one;
			go.GetComponent<UI_Item>().Init(list[i]);
		}
		Grid.repositionNow = true;
	}

	public void EquipItemReset()
	{
		Dictionary<eSlotType, ItemInstance> dic = ItemManager.Instance.DIC_EQUIP;

		foreach(KeyValuePair<eSlotType, ItemInstance> pair in dic)
		{
			switch (pair.Key)
			{
				case eSlotType.SLOT_WEAPON:
					WeaponLabel.text = pair.Value.ITEM_INFO.NAME;
					break;
				case eSlotType.SLOT_ARMOR:
					Armorlabel.text = pair.Value.ITEM_INFO.NAME;
					break;
				case eSlotType.SLOT_HELMET:
					HelmetLabel.text = pair.Value.ITEM_INFO.NAME;
					break;
				case eSlotType.SLOT_GUNTLET:
					GuntletLabel.text = pair.Value.ITEM_INFO.NAME;
					break;
			}
		}
	}


	void HideInventory()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_INVENTORY);
	}


}
