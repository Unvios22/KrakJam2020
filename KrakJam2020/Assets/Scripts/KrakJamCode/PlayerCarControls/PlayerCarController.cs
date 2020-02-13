using System;
using UnityEngine;
using UnityEngine.Events;

namespace PlayerCarControls{
	public class PlayerCarController : MonoBehaviour {
		public UnityEvent playerTurningEffectsStartedEvent;
		public UnityEvent playerTurningEffectsStoppedEvent;
	
		[SerializeField] float playerAccelerationSpeed;
		[SerializeField] float maxPlayerHorizontalVelocity;
		[SerializeField] float playerTurningRotationMaxValue;
		[SerializeField] float playerTurningEventInvokeAngleThreshold;

		bool _playerTurningEventInvoked;
	
		float _playerRotationAngle;
		Vector3 _playerInput;
		Rigidbody _rigidbody;

		void Start() {
			_rigidbody = gameObject.GetComponent<Rigidbody>();
		}

		void Update() {
			ReadPlayerInput();
		}

		void ReadPlayerInput() {
			_playerInput = new Vector3(-Input.GetAxisRaw("Vertical"), 0f ,Input.GetAxisRaw("Horizontal"));
		}

		void FixedUpdate() {
			ApplyPlayerInputToRb();
			CalculateCarRotationAngle();
			ManagePlayerTurningEvents();
			ApplyCarRotationAngle();
		}

		void ApplyPlayerInputToRb() {
			_rigidbody.AddForce(_playerInput * (playerAccelerationSpeed * Time.fixedDeltaTime), ForceMode.Impulse);
			ClampPlayerVelocity();
		}

		void ManagePlayerTurningEvents() {
			if (_playerTurningEventInvoked && Mathf.Abs(_playerRotationAngle) < playerTurningEventInvokeAngleThreshold) {
				playerTurningEffectsStoppedEvent.Invoke();
				_playerTurningEventInvoked = false;
			}
			else if(!_playerTurningEventInvoked && Mathf.Abs(_playerRotationAngle) > playerTurningEventInvokeAngleThreshold) {
				playerTurningEffectsStartedEvent.Invoke();
				_playerTurningEventInvoked = true;
			}
		}

		void ClampPlayerVelocity() {
			var playerHorizontalVelocity = _rigidbody.velocity.z;
			if (playerHorizontalVelocity > maxPlayerHorizontalVelocity) {
				_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f,maxPlayerHorizontalVelocity);
			}else if (playerHorizontalVelocity < -maxPlayerHorizontalVelocity) {
				_rigidbody.velocity = new Vector3(_rigidbody.velocity.x, 0f ,-maxPlayerHorizontalVelocity);
			}
		}
	  
		void CalculateCarRotationAngle() {
			var playerHorizontalVelocity = _rigidbody.velocity.z;
			if (playerHorizontalVelocity > 0) {
				_playerRotationAngle = playerHorizontalVelocity
					.RemapFloatValueToRange(0, maxPlayerHorizontalVelocity,
						0, playerTurningRotationMaxValue);
			} else if (playerHorizontalVelocity < 0) {
				_playerRotationAngle = playerHorizontalVelocity
					.RemapFloatValueToRange(0, -maxPlayerHorizontalVelocity,
						0, -playerTurningRotationMaxValue);
			}
		}

		void ApplyCarRotationAngle() {
			var currentRbRotation = _rigidbody.rotation.eulerAngles;
			_rigidbody.rotation = Quaternion.Euler(currentRbRotation.x,_playerRotationAngle , currentRbRotation.z);
		}
	}
}
