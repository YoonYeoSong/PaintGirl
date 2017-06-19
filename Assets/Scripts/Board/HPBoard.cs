using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBoard : BaseBoard {

	// Force Unity to serialize a private field
	// privae 변수 유니티 강제 동기화 ( 인스펙터 동기화 )

	[SerializeField]
	UIProgressBar ProgressBar = null;

	[SerializeField]
	UILabel HPLabel = null;

	public override eBoardType BOARD_TYPE
	{
		get
		{
			return eBoardType.BOARD_HP;
		}
	}

	public override void SetData(string strKey, params object[] datas)
	{

		if(strKey.Equals(ConstValue.SetData_HP))
		{
			// [0] Max , [1] Cur
			double MaxHP = (double)datas[0];
			double CurHP = (double)datas[1];

			ProgressBar.value =(float)(CurHP / MaxHP); // 0f ~ 1f
			HPLabel.text = CurHP.ToString() + " / " + MaxHP.ToString();
		}
	}

}
