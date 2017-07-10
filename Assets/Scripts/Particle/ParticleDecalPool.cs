using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDecalPool : MonoBehaviour {

	public int maxDecals = 100;
	public float decalSizeMin = 1f;
	public float decalSizeMax = 2f;

	public int count = 0;
	public string s3;
	//   public Gradient particleColorGradient;
	private ParticleSystem decalParticleSystem;
	private ParticleSystem decalParticleSystemB;
	private int particleDecalDataIndex;
	private int particleDecalDataIndexB;

	private ParticleDecalData[] particleData;
	private ParticleDecalDataB[] particleData2;
	private ParticleDecalDataC[] particleData3;

	public bool anw = false;

	public ParticleSystem.Particle[] particlesA;
	public ParticleSystem.Particle[] particlesB;
	public ParticleSystem.Particle[] particlesC;
	public ParticleSystem.Particle[] particlesD;
	HiddenItemRespawn s1 = null;

	//플레이어충돌태그 가지고있음 
	SplatOnCollision sp = null;

	void Start()
	{
		s1 = GameObject.Find("box").GetComponent<HiddenItemRespawn>();
		sp = GameObject.Find("SplatterParticles").GetComponent<SplatOnCollision>();
		s3 = gameObject.tag;
		decalParticleSystem = GetComponent<ParticleSystem>();
		decalParticleSystemB = GetComponent<ParticleSystem>();


		particlesA = new ParticleSystem.Particle[maxDecals];
		particlesB = new ParticleSystem.Particle[maxDecals];
		particlesC = new ParticleSystem.Particle[maxDecals];
		particlesD = new ParticleSystem.Particle[maxDecals];

		particleData = new ParticleDecalData[maxDecals];
		particleData2 = new ParticleDecalDataB[maxDecals];
		particleData3 = new ParticleDecalDataC[maxDecals];



		for (int i = 0; i < maxDecals; i++)
		{
			particleData[i] = new ParticleDecalData();
			particleData2[i] = new ParticleDecalDataB();
			particleData3[i] = new ParticleDecalDataC();
		}




	}


	void Update()
	{
		//if(s1.checkusetag == true)
		//  {
		//      for (int i = 0; i < particleData.Length; i++)
		//      {

		//          particlesA[i].startColor = Color.green;
		//      }

		//      for (int i = 0; i < particleData2.Length; i++)
		//      {
		//          particlesB[i].startColor = Color.yellow;
		//      }
		//      decalParticleSystem.SetParticles(particlesA, particlesA.Length);

		//      decalParticleSystemB.SetParticles(particlesB, particlesB.Length);
		//  }

	


	}

	public void ParticleHit(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{
		SetParticleData(particleCollisionEvent, colorGradient);
        SetParticleDataB(particleCollisionEvent, colorGradient);

        DisplayParticlesA();
	}




	//public void ParticleHitB(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	//{
	//    SetParticleDataB(particleCollisionEvent);
	//    DisplayParticlesB();
	//}




	//바닥에 칠해지는 파티클 설정 
	void SetParticleData(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
	{
		if (particleDecalDataIndex >= maxDecals)
		{
			particleDecalDataIndex = 0;
		}


		if (gameObject.tag == "APlayer")
		{
			particleData[particleDecalDataIndex].position = particleCollisionEvent.intersection;
			Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
			particleRotationEuler.z = Random.Range(0, 360);
			particleData[particleDecalDataIndex].rotation = particleRotationEuler;
			particleData[particleDecalDataIndex].size = Random.Range(decalSizeMin, decalSizeMax);
			particleData[particleDecalDataIndex].color = Color.yellow;


			//바닥에 칠해지는 페인트 색상 변경  
			// particleData[particleDecalDataIndex].color = Color.yellow;
			particleDecalDataIndex++;
		}

		//else if(gameObject.tag == "BPlayer")
		//{
		//	if (particleDecalDataIndexB >= maxDecals)
		//	{
		//		particleDecalDataIndexB = 0;
		//	}

		//	particleData2[particleDecalDataIndexB].position = particleCollisionEvent.intersection;
		//	Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
		//	particleRotationEuler.z = Random.Range(0, 360);
		//	particleData2[particleDecalDataIndexB].rotation = particleRotationEuler;
		//	particleData2[particleDecalDataIndexB].size = Random.Range(decalSizeMin, decalSizeMax);
		//	particleData2[particleDecalDataIndexB].color = Color.green;




		//	//바닥에 칠해지는 페인트 색상 변경  
		//	// particleData[particleDecalDataIndex].color = Color.yellow;
		//	particleDecalDataIndexB++;

		//}


		//바닥에 칠해지는 페인트 색상 변경  
		// particleData[particleDecalDataIndex].color = Color.yellow;
		//    particleDecalDataIndex++;
	}


    void SetParticleDataB(ParticleCollisionEvent particleCollisionEvent, Gradient colorGradient)
    {
        if (gameObject.tag == "BPlayer")
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




            //바닥에 칠해지는 페인트 색상 변경  
            // particleData[particleDecalDataIndex].color = Color.yellow;
            particleDecalDataIndexB++;

        }


        //바닥에 칠해지는 페인트 색상 변경  
        // particleData[particleDecalDataIndex].color = Color.yellow;
        //    particleDecalDataIndex++;
    }






    //void SetParticleDataB(ParticleCollisionEvent particleCollisionEvent)
    //{
    //    if (particleDecalDataIndexB >= maxDecals)
    //    {
    //        particleDecalDataIndexB = 0;
    //    }

    //    particleData2[particleDecalDataIndexB].position = particleCollisionEvent.intersection;
    //    Vector3 particleRotationEuler = Quaternion.LookRotation(particleCollisionEvent.normal).eulerAngles;
    //    particleRotationEuler.z = Random.Range(0, 360);
    //    particleData2[particleDecalDataIndexB].rotation = particleRotationEuler;
    //    particleData2[particleDecalDataIndexB].size = Random.Range(decalSizeMin, decalSizeMax);
    //    //바닥에 칠해지는 페인트 색상 변경  
    //    // particleData[particleDecalDataIndex].color = Color.yellow;
    //    particleDecalDataIndexB++;
    //}

    //바닥에 칠해지는 파티클 보여줌 
    void DisplayParticlesA()
	{   if (gameObject.tag == "APlayer")
		{

			for (int i = 0; i < particleData.Length; i++)
			{
				particlesA[i].position = particleData[i].position;
				particlesA[i].rotation3D = particleData[i].rotation;
				particlesA[i].startSize = particleData[i].size;
				particlesA[i].startColor = particleData[i].color;

			}
			decalParticleSystem.SetParticles(particlesA, particlesA.Length);
		}

		if (gameObject.tag == "BPlayer")
		{
			for (int i = 0; i < particleData2.Length; i++)
			{
				particlesB[i].position = particleData2[i].position;
				particlesB[i].rotation3D = particleData2[i].rotation;
				particlesB[i].startSize = particleData2[i].size;
				particlesB[i].startColor = particleData2[i].color;

			}
			decalParticleSystem.SetParticles(particlesB, particlesB.Length);
		}
	}






	//public void swapcolor()
	// {
	//     for(int i =0; i <particleData2.Length; i++)
	//     {   
	//         particlesC[i].startColor = Color.green;
	//         particlesA[i].startColor = particlesC[i].startColor;

	//     }
	//     for (int i = 0; i < particleData.Length; i++)
	//     {
	//         particlesC[i].startColor = Color.yellow;
	//         particlesB[i].startColor = particlesC[i].startColor;

	//     }
	//     Debug.Log("check");




	// }






	public	void swapcolorA() {

		for (int i = 0; i < particleData.Length; i++)
		{

			particleData[i].color = Color.green;

		}



	}


	public void swapcolorB() {

		for (int i = 0; i < particleData2.Length; i++)
		{
      

            particleData2[i].color = Color.yellow;

		}
        Debug.Log("ddd");


    }

}
