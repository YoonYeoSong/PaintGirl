using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Item : MonoBehaviour {

	ItemInstance itemInstance;

	public ItemInstance ITEM_INSTANCE
	{
		get
		{
			return itemInstance;
		}
		set
		{
			itemInstance = value;
		}
	}

	UILabel Label = null;
	UITexture Texture = null;

	public void Init(ItemInstance instance)
	{
		itemInstance = instance;
		Label = GetComponentInChildren<UILabel>();
		Texture = GetComponentInChildren<UITexture>();

		Label.text = itemInstance.ITEM_INFO.NAME;
		Texture.mainTexture = Resources.Load<Texture>("Textures/" + itemInstance.ITEM_INFO.ITEM_IMAGE);
	}


	void OnClick()
	{
		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(
			() =>
			{
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

}
