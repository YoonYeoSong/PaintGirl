using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void YesEvent();
public delegate void NoEvent();


public class UI_Popup : BaseObject {

	UILabel TitleLabel;
	UILabel ContentsLabel;

	UIButton YesBtn;
	UIButton NoBtn;

	YesEvent Yes;
	NoEvent No;

	private void Awake()
	{
		TitleLabel = FindInChild("Title").GetComponent<UILabel>();
		ContentsLabel = FindInChild("ConTents").GetComponent<UILabel>();

		YesBtn = FindInChild("YesBtn").GetComponent<UIButton>();
		NoBtn = FindInChild("NoBtn").GetComponent<UIButton>();

		EventDelegate.Add(YesBtn.onClick, new EventDelegate(this, "OnClickedYesBtn"));
		EventDelegate.Add(NoBtn.onClick, new EventDelegate(this, "OnClickedNoBtn"));
	}

	public void Set(YesEvent _yes, NoEvent _no, string _title, string _contents)
	{
		Yes = _yes;
		No = _no;
		TitleLabel.text = _title;
		ContentsLabel.text = _contents;
	}

	public void OnClickedYesBtn()
	{
		if (Yes != null)
			Yes();
	}

	public void OnClickedNoBtn()
	{
		if (No != null)
			No();
	}



}
