using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Logo : BaseObject {

	UIButton StartBtn;


	// Use this for initialization
	void Start () {
		Transform temp = FindInChild("StartBtn");
		if( temp == null)
		{
			Debug.LogError(gameObject.name + "에 StartBtn이 없습니다.");
		}
		StartBtn = temp.gameObject.GetComponent<UIButton>();
		EventDelegate.Add(StartBtn.onClick, new EventDelegate(this, "GoLobby"));

		// TestCode 람다
		//EventDelegate.Add(StartBtn.onClick, () =>
		// {
		//	 Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);
		// });
	}

	void GoLobby()
	{
		Scene_Manager.Instance.LoadScene(eSceneType.SCENE_LOBBY);
	}


	// Update is called once per frame
	void Update () {
		
	}
}
