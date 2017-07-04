using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StageIcon : BaseObject {

	
	StageInfo Info = null;

	public StageInfo INFO
	{
		get
		{
			return Info;
		}
	}

	UILabel StageName = null;

	public void Init(StageInfo _info)
	{
		Info = _info;
		StageName = this.GetComponentInChildren<UILabel>();
		StageName.text = Info.NAME;

	}

	public void OnClick()
	{
		//Launcher launcher = null;
		GameObject.Find("Launcher").GetComponent<Launcher>().Connect();
		

		GameObject go = UI_Tools.Instance.ShowUI(eUIType.PF_UI_POPUP);
		UI_Popup popup = go.GetComponent<UI_Popup>();

		popup.Set(
			() =>
			{
				Debug.Log(Info.NAME + "입장");
				GameManager.Instance.SelectStage = int.Parse(INFO.KEY);
				Scene_Manager.Instance.LoadScene(eSceneType.SCENE_GAME);
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
				GameObject.Find("Launcher").GetComponent<Launcher>().Connect();
			}
			,
			() =>
			{
				UI_Tools.Instance.HideUI(eUIType.PF_UI_POPUP);
			},
			"스테이지 선택",
			"스테이지" + INFO.NAME + "을 입장하시겠습니까?"
			);
	}

}
