using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBoard : BaseBoard {

	[SerializeField]
	UILabel DamageLabel = null;

	public override eBoardType BOARD_TYPE
	{
		get
		{
			return eBoardType.BOARD_DAMAGE;
		}
	}

	public override void SetData(string strKey, params object[] datas)
	{
		if(strKey.Equals(ConstValue.SetData_Damage))
		{
			double damage = (double)datas[0];
			DamageLabel.text = damage.ToString();

			base.UpdateBoard(); // 한번만 실행 -> 초기위치 설정
		}
	}

	public override void UpdateBoard()
	{
		// CheckDestroyTime() 용
		CurTime += Time.deltaTime;
		transform.position += Vector3.up * Time.deltaTime * 0.5f;
	}

}
