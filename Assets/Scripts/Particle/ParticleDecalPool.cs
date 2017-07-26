using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour {

	public int maxDecals = 100;
	public float decalSizeMin = 1f;
	public float decalSizeMax = 2f;

	public string mytagObject;
	//   public Gradient particleColorGradient;
	private ParticleSystem decalParticleSystemA;
	private ParticleSystem decalParticleSystemB;
	private int particleDecalDataIndex;
	private int particleDecalDataIndexB;

	public ParticleDecalData[] particleData;
	public ParticleDecalDataB[] particleData2;


	public ParticleSystem.Particle[] particlesA;
	public ParticleSystem.Particle[] particlesB;

	HiddenItemRespawn HiddenItembox = null;

    GameCountTime HiddenTimeCheck = null;
    //플레이어충돌태그 가지고있음 
    //SplatOnCollision SplatOnCollision = null;

    void Start()
    {
        HiddenItembox = GameObject.Find("HiddenBox").GetComponent<HiddenItemRespawn>();

        //SplatOnCollision = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
        mytagObject = gameObject.tag;
		decalParticleSystemA = GetComponent<ParticleSystem>();
		decalParticleSystemB = GetComponent<ParticleSystem>();


		particlesA = new ParticleSystem.Particle[maxDecals];
		particlesB = new ParticleSystem.Particle[maxDecals];


		particleData = new ParticleDecalData[maxDecals];
		particleData2 = new ParticleDecalDataB[maxDecals];



		for (int i = 0; i < maxDecals; i++)
		{
			particleData[i] = new ParticleDecalData();
			particleData2[i] = new ParticleDecalDataB();
		}



    }


	void Update()
<<<<<<< HEAD
	{   //상자와 충돌하였을때 true값 
		//if (HiddenItemRespawn.CheckColliderUse == true)
		////{
		////    swapColorA();
		////    swapColorB();
		////     Debug.Log("swap success");
		//HiddenItemRespawn.CheckColliderUse = false;
		//}
	}
=======
    {   //상자와 충돌하였을때 true값 
        if (HiddenItembox.CheckColliderUse == true)
        {
            swapColorA();
            swapColorB();
            Debug.Log("swap success");
        }
    }
>>>>>>> c7df9cf5ab3813dd4ba35984b2fc51209513a558

    public void ParticleHit(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{   if(gameObject.CompareTag("APlayer"))
        {
            SetParticleDataA(particleCollisionEvent, colorGradient);
            DisplayParticlesA();
          //  Debug.Log("APlayer");
        }

        if (gameObject.CompareTag("BPlayer"))
        {
            SetParticleDataB(particleCollisionEvent, colorGradient);
            DisplayParticlesB();
         //   Debug.Log("BPlayer");
        }

   

	}

	//바닥에 칠해지는 파티클 설정 
	void SetParticleDataA(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{
		if (particleDecalDataIndex >= maxDecals)
		{
			particleDecalDataIndex = 0;
		}
			particleData[particleDecalDataIndex].position = particleCollisionEvent.intersection;
			Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
			particleRotationEuler.z = Random.Range(0, 360);
			particleData[particleDecalDataIndex].rotation = particleRotationEuler;
			particleData[particleDecalDataIndex].size = Random.Range(decalSizeMin, decalSizeMax);
			particleData[particleDecalDataIndex].color = Color.yellow;

		 
			particleDecalDataIndex++;
	}


    void SetParticleDataB(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
    {
            if (particleDecalDataIndexB >= maxDecals)
            {
                particleDecalDataIndexB = 0;
            }

            particleData2[particleDecalDataIndexB].position = particleCollisionEvent.intersection;
            Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
            particleRotationEuler.z = Random.Range(0, 360);
            particleData2[particleDecalDataIndexB].rotation = particleRotationEuler;
            particleData2[particleDecalDataIndexB].size = Random.Range(decalSizeMin, decalSizeMax);
            particleData2[particleDecalDataIndexB].color = Color.green;

            particleDecalDataIndexB++;
    }





    //바닥에 칠해지는 파티클 보여줌 
    void DisplayParticlesA()
	{

			for (int i = 0; i < particleData.Length; i++)
			{
				particlesA[i].position = particleData[i].position;
				particlesA[i].rotation3D = particleData[i].rotation;
				particlesA[i].startSize = particleData[i].size;
				particlesA[i].startColor = particleData[i].color;

            }
			decalParticleSystemA.SetParticles(particlesA, particlesA.Length);

	}


    void DisplayParticlesB()
    {
            for (int i = 0; i < particleData2.Length; i++)
            {
                particlesB[i].position = particleData2[i].position;
                particlesB[i].rotation3D = particleData2[i].rotation;
                particlesB[i].startSize = particleData2[i].size;
                particlesB[i].startColor = particleData2[i].color;
        }
            decalParticleSystemB.SetParticles(particlesB, particlesB.Length);

       
    }

    public void swapColorA()
    {

        for (int i = 0; i < particleData.Length; i++)
        {

            particleData[i].color = Color.green;
        }
        Debug.Log("swapColorA");
    }


    public void swapColorB()
    {

        for (int i = 0; i < particleData2.Length; i++)
        {
            particleData2[i].color = Color.yellow;
        }
        Debug.Log("swapColorB");
    }

}
