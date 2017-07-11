using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBoard : MonoBehaviour {

	BaseObject TargetActor = null;

	Camera UICamera = null;
	Camera WorldCamera = null;

	Transform BoardTransform = null;

	[SerializeField]
	bool AttachBoard = true;
	Vector3 Position = Vector3.zero;

	[SerializeField]
	float DestroyTime = 0.0f;
	protected float CurTime = 0.0f;

	public virtual eBoardType BOARD_TYPE
	{
		get
		{
			return eBoardType.BOARD_NONE;
		}
	}

	public BaseObject TargetComponent
	{
		set
		{
			TargetActor = value;
			BoardTransform = TargetActor.FindInChild("Board");

		}
	}

	public Camera UI_CAMERA
	{
		get
		{
			if(UICamera == null)
			{
				UICamera = NGUITools.FindCameraForLayer(LayerMask.NameToLayer("UI"));
			}

			return UICamera;
		}
	}

	public Camera WORLD_CAMERA
	{
		get
		{
			if(WorldCamera == null)
			{
				WorldCamera = Camera.main;
			}
			return WorldCamera;
		}
	}

	public virtual void SetData(string strKey, params object[] datas)
	{

	}


	public virtual void UpdateBoard()
	{
		// deltaTime -> Update(Logic)
		// Time.fixedDeltaTime  -> fixedupdate(logic)
		CurTime += Time.deltaTime;

		if( UI_CAMERA == null || WORLD_CAMERA == null )
		{
			// if( 대문자 접근 ) -> X Get 체크
			Debug.LogError("Camera를 찾지 못했습니다");
			return;
		}

		// TargetComponent Set 부분에서 처리
		if(BoardTransform == null)
		{
			// Actor 하위에 "Board" 라는 오브젝트가 없다.
			Debug.LogError("Actor 에서 BoardTransform을 찾을 수 없습니다.");
			return;
		}

		if(AttachBoard == true)
		{
			Position = BoardTransform.position;
		}
		else
		{
			if (Position == Vector3.zero)
				Position = BoardTransform.position;
		}

		Vector3 viewPort = WORLD_CAMERA.WorldToViewportPoint(Position);
		Vector3 boardPosition = UI_CAMERA.ViewportToWorldPoint(viewPort);

		boardPosition.z = 0f;
		//this.transform.position = boardPosition;

	}

	public bool CheckDestroyTime()
	{
		if (DestroyTime == 0.0f)
			return false;
		if (DestroyTime < CurTime)
			return true;

		return false;

	}

}
