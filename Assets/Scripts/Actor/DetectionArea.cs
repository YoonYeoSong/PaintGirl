using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionArea : BaseObject
{
    public List<Actor> list_Actor = new List<Actor>();
    Actor AttachActor = null;
    CapsuleCollider CapColl;

    public void Inin(Actor actor, float radius)
    {
        AttachActor = actor;
        CapColl = SelfComponent<CapsuleCollider>();
        if(CapColl == null)
        {
            CapColl = SelfObject.AddChild<CapsuleCollider>();
        }
        CapColl.isTrigger = true;
        CapColl.radius = radius;
    }

    public void OnTriggerEnter(Collider other)
    {
        Actor actor = other.GetComponent<Actor>();
        if (actor == null)
            return;

        if (list_Actor.Contains(actor))
            return;

        // if(AttachActor.tea)
        list_Actor.Add(actor);
    }

    public void OnTriggerExit(Collider other)
    {
        Actor actor = other.GetComponent<Actor>();
        if (actor == null)
            return;

        if (list_Actor.Contains(actor))
            list_Actor.Remove(actor);

    }
   public Actor GetFirst()
	{
		Actor returnActor = null;
		while(returnActor == null)
		{
			if (list_Actor.Count <= 0)
				break;
			// -- 예외 처리
			returnActor = list_Actor[0];

			if (returnActor == null)
				list_Actor.RemoveAt(0);

		}
		return returnActor;
	}
}
