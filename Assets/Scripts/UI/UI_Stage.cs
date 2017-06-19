using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Stage : MonoBehaviour {

	bool IsInit = false;
	GameObject IconPrefab;
	UIGrid Grid;

	UIButton CloseBtn;

	public void Init()
	{
		if (IsInit == true)
			return;

		IconPrefab = Resources.Load("Prefabs/UI/PF_UI_STAGEICON") as GameObject;
		Grid = GetComponentInChildren<UIGrid>();

		CloseBtn = GetComponentInChildren<UIButton>();
		EventDelegate.Add(CloseBtn.onClick, () => { UI_Tools.Instance.HideUI(eUIType.PF_UI_STAGE); });

		AddIcon();
		IsInit = true;
	}

	void AddIcon()
	{
		foreach(KeyValuePair<int, StageInfo> pair in StageManager.Instance.DIC_STAGEINFO)
		{
			GameObject go = NGUITools.AddChild(Grid.gameObject, IconPrefab);

			go.GetComponent<UI_StageIcon>().Init(pair.Value);
		}

		Grid.repositionNow = true;
	}

}
