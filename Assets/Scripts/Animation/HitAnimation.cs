using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitAnimation : StateMachineBehaviour {

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
	{
		if(animatorStateInfo.normalizedTime >= 1.0f)
		{
			animator.SetInteger("Hit", 0);
		}
	}


}
