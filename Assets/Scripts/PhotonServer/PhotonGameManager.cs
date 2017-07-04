using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

using ExitGames.Client.Photon;
public class PhotonGameManager : Photon.MonoBehaviour
{

	#region Public Variables

	static public PhotonGameManager Instance;

	[Tooltip("The prefab to use for representing the player")]
	public GameObject playerPrefab;

	#endregion

	#region Private Variables

	private GameObject instance;

	#endregion

	#region MonoBehaviour CallBacks

	/// <summary>
	/// MonoBehaviour method called on GameObject by Unity during initialization phase.
	/// </summary>
	void Start()
	{
		Instance = this;

		//playerPrefab = Resources.Load("Prefabs/" + "Charactor/" + "SD_Basic_Change_Main") as GameObject;
		//GameObject go = Instantiate(playerPrefab, Vector3.zero, Quaternion.identity) as GameObject;
		// in case we started this demo with the wrong scene being active, simply load the menu scene
		if (!PhotonNetwork.connected)
		{
			SceneManager.LoadScene("SCENE_GAME");

			return;
		}

		if (playerPrefab == null)
		{ // #Tip Never assume public properties of Components are filled up properly, always check and inform the developer of it.

			Debug.LogError("<Color=Red><b>Missing</b></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this);
		}
		else
		{


			if (PlayerManager.LocalPlayerInstance == null)
			{
				Debug.Log("We are Instantiating LocalPlayer from " + SceneManagerHelper.ActiveSceneName);

				// we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
				PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(0f, 5f, 0f), Quaternion.identity, 0);
			}
			else
			{

				Debug.Log("Ignoring scene load for " + SceneManagerHelper.ActiveSceneName);
			}


		}

	}

	/// <summary>
	/// MonoBehaviour method called on GameObject by Unity on every frame.
	/// </summary>
	void Update()
	{
		// "back" button of phone equals "Escape". quit app if that's pressed
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			QuitApplication();
		}
	}

	#endregion

	#region Photon Messages

	/// <summary>
	/// Called when a Photon Player got connected. We need to then load a bigger scene.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnPhotonPlayerConnected(PhotonPlayer other)
	{
		Debug.Log("OnPhotonPlayerConnected() " + other.NickName); // not seen if you're the player connecting

		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

			LoadArena();
		}
	}

	/// <summary>
	/// Called when a Photon Player got disconnected. We need to load a smaller scene.
	/// </summary>
	/// <param name="other">Other.</param>
	public void OnPhotonPlayerDisconnected(PhotonPlayer other)
	{
		Debug.Log("OnPhotonPlayerDisconnected() " + other.NickName); // seen when other disconnects

		if (PhotonNetwork.isMasterClient)
		{
			Debug.Log("OnPhotonPlayerConnected isMasterClient " + PhotonNetwork.isMasterClient); // called before OnPhotonPlayerDisconnected

			LoadArena();
		}
	}

	/// <summary>
	/// Called when the local player left the room. We need to load the launcher scene.
	/// </summary>
	public virtual void OnLeftRoom()
	{
		SceneManager.LoadScene("PunBasics-Launcher");
	}

	#endregion

	#region Public Methods

	public void LeaveRoom()
	{
		PhotonNetwork.LeaveRoom();
	}

	public void QuitApplication()
	{
		Application.Quit();
	}

	#endregion

	#region Private Methods

	public void LoadArena()
	{
		if (!PhotonNetwork.isMasterClient)
		{
			Debug.LogError("PhotonNetwork : Trying to Load a level but we are not the master Client");
		}

		Debug.Log("PhotonNetwork : Loading Level : " + PhotonNetwork.room.PlayerCount);

		// 씬전환
		//PhotonNetwork.LoadLevel("PunBasics-Room for "+ PhotonNetwork.room.PlayerCount);
		PhotonNetwork.LoadLevel("SCENE_GAME");
	}

	#endregion
}


