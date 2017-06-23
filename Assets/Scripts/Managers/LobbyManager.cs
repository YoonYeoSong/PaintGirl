using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyManager : MonoSingleton<LobbyManager> {

	public void LoadLobby()
	{
		//UI_Tools.Instance.ShowUI(eUIType.PF_UI_LOBBY);
	}

	public void OnDisableLobby()
	{
		UI_Tools.Instance.HideUI(eUIType.PF_UI_LOBBY);
	}
}
