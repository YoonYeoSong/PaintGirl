using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Option_Main : MonoBehaviour {

	UIButton CloseBtn = null;
	UIButton FacebookBtn = null;
	UIButton GoogleBtn = null;

	Transform trans = null;

	private void Awake()
	{
		CloseBtn = transform.FindChild("BackGround").FindChild("Close").FindChild("Btn").GetComponent<UIButton>();
		if (CloseBtn == null)
			Debug.Log("CloseBtn is null");
		EventDelegate.Add(CloseBtn.onClick, new EventDelegate(this, "ClosePanel")); //닫기버튼

		FacebookBtn = transform.FindChild("BackGround").FindChild("AccountLink").FindChild("Facebook").FindChild("BackGround").FindChild("Btn").GetComponentInChildren<UIButton>();
		if (FacebookBtn == null)
			Debug.Log("FacebookBtn is null");
		EventDelegate.Add(FacebookBtn.onClick, new EventDelegate(this, "ClosePanel")); // 페이스북 버튼

		GoogleBtn = transform.FindChild("BackGround").FindChild("AccountLink").FindChild("Google").FindChild("BackGround").FindChild("Btn").GetComponentInChildren<UIButton>();
		if (GoogleBtn == null)
			Debug.Log("GoogleBtn is null");
		EventDelegate.Add(GoogleBtn.onClick, new EventDelegate(this, "ClosePanel")); // 구글 버튼

	}

	void ClosePanel()
	{
		Destroy(this.gameObject);
		//gameObject.SetActive(false);
		Debug.Log("닫기 클릭");
	}


}
