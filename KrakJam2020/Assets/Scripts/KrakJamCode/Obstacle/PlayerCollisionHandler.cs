using System;
using UnityEngine;

namespace Obstacle{
	public class PlayerCollisionHandler : MonoBehaviour {
		[SerializeField] float forceOnCollisionWithObstacle;

		ObjectShakerScript _objectShakerScript;
		Rigidbody _rigidbody;

		void Start(){
			_rigidbody = GetComponent<Rigidbody>();
			_objectShakerScript = GameObject.FindGameObjectWithTag(Tags.CAMERA_TO_SHAKE)
				.GetComponent<ObjectShakerScript>();
		}

		public void CrashedIntoObstacle(){
			_rigidbody.AddForce(Vector3.right * forceOnCollisionWithObstacle,ForceMode.Impulse);
			_objectShakerScript.Shake();
		}
	}
}


