using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleHit : MonoBehaviour {

    public ParticleSystem particleLauncher;
    public Gradient particleColorGradient;
    public ParticleDecalPool splatDecalPool;

    List<ParticleCollisionEvent> collisionEvents;


    // Use this for initialization
    void Start () {
        collisionEvents = new List<ParticleCollisionEvent>();
        if(gameObject.CompareTag("APlayer"))
        splatDecalPool = GameObject.Find("RocketParticleA").GetComponentInChildren<ParticleDecalPool>();

        if(gameObject.CompareTag("BPlayer"))
        splatDecalPool = GameObject.Find("RocketParticleB").GetComponentInChildren<ParticleDecalPool>();

        //데칼사이즈 변경 
        splatDecalPool.decalSizeMax = 30f;
        splatDecalPool.decalSizeMin = 30f;


    }
	
	// Update is called once per frame
	void Update () {
        ParticleSystem.MainModule psMain = particleLauncher.main;
        //발사중에 있는 파티클 색상 
        psMain.startColor = particleColorGradient.Evaluate(0f);
        particleLauncher.Emit(1);

    }
    void OnParticleCollision(GameObject other)
    {
        ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);
        for (int i = 0; i < collisionEvents.Count; i++)
        {
            splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
        }


    }

    




}
