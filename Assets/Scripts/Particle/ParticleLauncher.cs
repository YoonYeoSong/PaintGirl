using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLauncher : Photon.MonoBehaviour {

	public ParticleSystem particleLauncher;
	public ParticleSystem splatterParticles;
	public Gradient particleColorGradient;
	public ParticleDecalPool splatDecalPool;

	List<ParticleCollisionEvent> collisionEvents;

	void Start()
	{
		collisionEvents = new List<ParticleCollisionEvent>();
	}

	void OnParticleCollision(GameObject other)
	{
		transform.GetComponentInParent<PlayerManager>().OnParticleCollision(other);
	}

	public void ParticleColColor(GameObject other)
	{
		ParticlePhysicsExtensions.GetCollisionEvents(particleLauncher, other, collisionEvents);

		for (int i = 0; i < collisionEvents.Count; i++)
		{
			splatDecalPool.ParticleHit(collisionEvents[i], particleColorGradient);
			EmitAtLocation(collisionEvents[i]);
		}
	}

	

	void EmitAtLocation(ParticleCollisionEvent particleCollisionEvent)
	{
		splatterParticles.transform.position = particleCollisionEvent.intersection;
		splatterParticles.transform.rotation = Quaternion.LookRotation(particleCollisionEvent.normal);
		ParticleSystem.MainModule psMain = splatterParticles.main;
		psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));

		splatterParticles.Emit(1);
	}

	void Update()
	{
		//if (Input.GetButton("Fire1"))
		//{
		//	ParticleSystem.MainModule psMain = particleLauncher.main;
		//	psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
		//	particleLauncher.Emit(1);
		//}
	}

	public void Shoot()
	{
		ParticleSystem.MainModule psMain = particleLauncher.main;
		psMain.startColor = particleColorGradient.Evaluate(Random.Range(0f, 1f));
		particleLauncher.Emit(1);
	}
}
