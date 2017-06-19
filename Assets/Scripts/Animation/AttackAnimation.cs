using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimation : StateMachineBehaviour
{
	Actor TargetActor = null;
	bool bIsAttack = false;

	public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
	{
		TargetActor = animator.GetComponentInParent<Actor>();
		if(TargetActor.AI.CURRENT_AI_STATE == eStateType.STATE_ATTACK)
		{
			TargetActor.AI.IS_ATTACK = true;
			bIsAttack = false;
		}
	}

	public override void OnStateUpdate(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        //if (animatorStateInfo.IsName("Attack"))
        //{
        if (animatorStateInfo.normalizedTime > 1.0f && TargetActor.AI.IS_ATTACK)
        {
			//BaseObject bo = animator.GetComponentInParent<BaseObject>();
			//bo.ThrowEvent("AttackEnd", eStateType.STATE_IDLE);

			if (TargetActor.AI.CURRENT_AI_STATE == eStateType.STATE_ATTACK)
				TargetActor.AI.IS_ATTACK = false;


        }

		if(bIsAttack == false && animatorStateInfo.normalizedTime >= 0.5f)
		{
			bIsAttack = true;
			TargetActor.RunSkill();
		}
      // }
      
    }
}
