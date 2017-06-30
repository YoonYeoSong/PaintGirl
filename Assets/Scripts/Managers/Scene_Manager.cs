using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoSingleton<Scene_Manager> {


	bool IsAsyc = true;
	AsyncOperation Operation = null;

	eSceneType CurrentState = eSceneType.SCENE_LOGO;
	eSceneType NextState = eSceneType.SCENE_NONE;

	float StackTime = 0.0f;
	public eSceneType CURRENT_SCENE
	{
		get
		{
			return CurrentState;
		}
	}


	public void LoadScene(eSceneType _type, bool _async = true)
	{
		if (CurrentState == _type)
			return;

		NextState = _type;
		IsAsyc = _async;
	}

	private void Update()
	{

		if(Operation != null)
		{
			StackTime += Time.deltaTime;
			// Loading UI Set
			UI_Tools.Instance.ShowLoadingUI(Operation.progress);
			//UI_Tools.Instance.ShowLoadingUI(StackTime / 2.0f);

			if (Operation.isDone == true)
			//if(Operation.isDone == true && StackTime >= 2.0f)
			{		
				CurrentState = NextState;
				ComplateLoad(CurrentState);

				Operation = null;
				NextState = eSceneType.SCENE_NONE;

				// Loding UI 삭제
				UI_Tools.Instance.HideUI(eUIType.PF_UI_LOADING, true);
			}
			else
				return;
		}

		if (CurrentState == eSceneType.SCENE_NONE)
			return;


		if(NextState != eSceneType.SCENE_NONE && CurrentState != NextState)
		{
			OnDisableScene(CurrentState);
			if(IsAsyc)
			{
				// 비동기 로그
				Operation = SceneManager.LoadSceneAsync(NextState.ToString("F"));
				StackTime = 0.0f;
				// Loding UI Set
				UI_Tools.Instance.ShowLoadingUI(0.0f);
			}
			else
			{
				// 동기 로그
				SceneManager.LoadScene(NextState.ToString("F"));
				CurrentState = NextState;
				NextState = eSceneType.SCENE_NONE;
				ComplateLoad(CurrentState);

			}
		}



	}

	void ComplateLoad(eSceneType _type)
	{
		switch(_type)
		{
			case eSceneType.SCENE_NONE:
				break;
			case eSceneType.SCENE_LOGO:
				break;
			case eSceneType.SCENE_GAME:
				{
					GameManager.Instance.LoadGame();
				}
				break;
			case eSceneType.SCENE_LOBBY:
				{
					LobbyManager.Instance.LoadLobby();
					GameManager.Instance.GameInit();
				}
				break;

			default:
				break;
		}
			
	}

	void OnDisableScene(eSceneType _type)
	{
		// 씬 유아이 삭제
		UI_Tools.Instance.Clear();

		switch (_type)
		{
			case eSceneType.SCENE_NONE:
				break;
			case eSceneType.SCENE_LOGO:
				break;
			case eSceneType.SCENE_GAME:
				SkillManager.Instance.ClearSkill();
				break;
			case eSceneType.SCENE_LOBBY:
				LobbyManager.Instance.OnDisableLobby();
				break;

			default:
				break;
		}
	}


}
