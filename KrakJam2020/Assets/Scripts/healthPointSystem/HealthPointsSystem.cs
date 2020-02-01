﻿using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace healthPointSystem{
	public class HealthPointsSystem : MonoBehaviour{
		[SerializeField] private int maxHp;
		[SerializeField] private UnityEvent playerDiedEvent;

		private void Awake(){
			maxHp = 5;
		}

		[Button]
		public void DecreaseHealth(){
			DecreaseHealthByAmount(1);
		}

		public void DecreaseHealthByAmount(int amount){
			maxHp -= amount;
			if(maxHp <= 0){
				playerDiedEvent?.Invoke();
			}
		}

		public int MaxHp => maxHp;
	}
}