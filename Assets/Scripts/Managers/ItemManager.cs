using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public delegate void EquipEvent();


public class ItemManager : MonoSingleton<ItemManager> {

	bool IsInit = false;

	public EquipEvent EquipE;

	// 소지 아이템
	List<ItemInstance> listItem = new List<ItemInstance>();
	// 착용 아이템
	Dictionary<eSlotType, ItemInstance> DicEquipItem = new Dictionary<eSlotType, ItemInstance>();

	public List<ItemInstance> LIST_ITEM
	{
		get
		{
			return listItem;
		}
	}


	public Dictionary<eSlotType, ItemInstance> DIC_EQUIP
	{
		get { return DicEquipItem; }
	}

	Dictionary<int, ItemInfo> DicItemInfo = new Dictionary<int, ItemInfo>();
	public Dictionary<int, ItemInfo> DIC_ITEMINFO
	{
		get
		{
			return DicItemInfo;
		}
	}


	public void ItemInit()
	{
		if (IsInit == true)
			return;

		TextAsset itemInfo = Resources.Load<TextAsset>("JSON/ITEM_INFO");
		JSONNode rootNode = JSON.Parse(itemInfo.text);

		foreach(KeyValuePair<string, JSONNode> pair in rootNode["ITEM_INFO"] as JSONObject)
		{
			ItemInfo info = new ItemInfo(pair.Key, pair.Value);
			DicItemInfo.Add(int.Parse(info.KEY), info);
		}

		GetLocalData();
		IsInit = true;
	}

	public void GetLocalData()
	{
		// ITEM_ID _ SlotType _ ITEM_NO | ITEM_ID _ SlotType _ ITEM_NO
		string instanceStr = PlayerPrefs.GetString(ConstValue.LocalSave_ItemInstance, string.Empty);

		string[] array = instanceStr.Split('|');

		for (int i = 0; i < array.Length; i++)
		{
			if (array[i].Length <= 0)
				continue;

			string[] detail = array[i].Split('_');

			if (detail.Length < 3)
				continue;

			int itemId = int.Parse(detail[0]);
			eSlotType slotType = (eSlotType)int.Parse(detail[1]);

			ItemInfo info = null;
			DicItemInfo.TryGetValue(int.Parse(detail[2]), out info);
			if (info == null)
			{
				Debug.LogError("ID : " + itemId + "ItemNO : " + detail[2] + "is not valid");
				continue;
			}

			// ItemInstace
			ItemInstance instance = new ItemInstance(itemId, slotType, info);
			listItem.Add(instance);


			// Equip

			if (slotType != eSlotType.SLOT_NONE)
				EquipItem(instance, false);
		}
	}

	public void EquipItem(ItemInstance instance, bool isSave = true)
	{
		ItemInfo info = instance.ITEM_INFO;

		if(DicEquipItem.ContainsKey(info.TYPE))
		{
			// 현재 장착중인 슬롯
			DicEquipItem[info.TYPE].SLOT_TYPE = eSlotType.SLOT_NONE;

			instance.SLOT_TYPE = info.TYPE;
			DicEquipItem[info.TYPE] = instance;
		}
		else
		{
			instance.SLOT_TYPE = info.TYPE;
			DicEquipItem.Add(info.TYPE, instance);
		}

		if (EquipE != null)
			EquipE();

		if (isSave)
			SetLocalData();

	}

	public void SetLocalData()
	{
		// ITEM_ID _ SlotType _ ITEM_NO | ITEM_ID _ SlotType _ ITEM_NO
		// "1_-1_3" | 2_1_5

		string resultStr = string.Empty;

		for(int i = 0; i < listItem.Count; i++)
		{
			string itemStr = string.Empty;
			itemStr += (i + 1) + "_";
			itemStr += (int)listItem[i].SLOT_TYPE + "_";
			itemStr += listItem[i].ITEM_NO;

			if (i != listItem.Count - 1)
				itemStr += "|";

			resultStr += itemStr;

		}

		PlayerPrefs.SetString(ConstValue.LocalSave_ItemInstance, resultStr);
		Debug.Log(resultStr);

	}

	public void Gacha()
	{
		int no = Random.Range(1, DicItemInfo.Count + 1);
		ItemInfo info = null;

		DicItemInfo.TryGetValue(no, out info);
		if(info == null)
		{
			Debug.LogError(no + "is not valid key");
			return;
		}

		ItemInstance instance = new ItemInstance(listItem.Count + 1, eSlotType.SLOT_NONE, info);
		listItem.Add(instance);
		SetLocalData();

		// Gacha UI
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_GACHA);
		UI_Gacha popup = go.GetComponent<UI_Gacha>();
		popup.Init(instance);
	}

}
