using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace concreteMechanic{
	
	[RequireComponent(typeof(AudioSource))]
	public class ConcreteSplasher : MonoBehaviour{

		[SerializeField] SplashColliderCreator splashColliderCreator;
		[SerializeField] int splattingTime;
		[SerializeField] ParticleSystem particleSystem;
		
		void Update(){
			if(Input.GetKey(KeyCode.Space)){
				SplashConcrete();
			}
		}

		[Button]
		public void SplashConcrete(){
			InitiateSplash();
			StartCoroutine(DisableSplashAfterSeconds());
		}

		void InitiateSplash(){
			splashColliderCreator.gameObject.SetActive(true);
			particleSystem.Play();
			EventManager.OnConcreteStartedSplashingEvent();
		}

		IEnumerator DisableSplashAfterSeconds(){
			yield return new WaitForSeconds(splattingTime);
			splashColliderCreator.gameObject.SetActive(false);
			particleSystem.Stop();
			EventManager.OnConcreteStoppedSplashingEvent();
		}
	}
}