using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;


public class ItemInfo {


	string StrKey = string.Empty;
	string ItemName = string.Empty;
	eSlotType SlotType = eSlotType.SLOT_NONE;
	StatusData Status = new StatusData();
	string ItemImage = string.Empty;

	public string KEY { get { return StrKey; } }
	public string NAME { get { return ItemName; } }
	public eSlotType TYPE { get { return SlotType; } }
	public StatusData STATUS { get { return Status; } }
	public string ITEM_IMAGE { get { return ItemImage; } }

	public ItemInfo(string _strKey, JSONNode nodeData)
	{
		StrKey = _strKey;
		ItemName = nodeData["NAME"];
		SlotType = (eSlotType)nodeData["SLOT_TYPE"].AsInt;

		for(int i = 0; i < (int)eStatusData.MAX; i++)
		{
			eStatusData status = (eStatusData)i;
			double valueData = nodeData[status.ToString()].AsDouble;
			if (valueData > 0)
				Status.IncreaseData(status, valueData);
		}
		ItemImage = nodeData["IMAGE"];
	}


	public string GetSlotString()
	{
		string returnStr = string.Empty;
		returnStr = SlotType.ToString().Split('_')[1];
		return returnStr;

		// or Switch(SlotType)
	}



}
