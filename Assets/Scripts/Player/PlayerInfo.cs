using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class PlayerInfo  {

	string StrKey = string.Empty;
	int Hp = 0;
	float MoveSpeed = 0.0f;


	public string KEY { get { return StrKey; } }
	public int HP { get { return Hp; } }
	public float MOVESPEED { get { return MoveSpeed; } }


	public PlayerInfo(string _strKey, JSONNode nodeData)
	{
		StrKey = _strKey;
		Hp = nodeData["HP"].AsInt;
		MoveSpeed = nodeData["MOVESPEED"].AsFloat;

	}

}
