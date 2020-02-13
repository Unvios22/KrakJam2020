using System.Collections;
using TMPro;
using UnityEngine;

public class FloatingScoreSpawner : MonoBehaviour {
	[SerializeField] GameObject floatingScoreTextPrefab;
	[SerializeField] float floatingTextMoveUpSpeed;
	[SerializeField] float floatingTextYSpawnOffset;
	[SerializeField] float floatingTextLingerTime;

	[SerializeField] Color positiveScoreColor;
	[SerializeField] Color negativeScoreColor;

	[SerializeField] Transform cameraTransform;

	public void SpawnFloatingPointsAmount(int pointAmount, Vector3 spawnPosition) {
		var spawnPosInternal =
			new Vector3(spawnPosition.x, spawnPosition.y + floatingTextYSpawnOffset, spawnPosition.z);
		var spawnedFloatingScoreObject = Instantiate(floatingScoreTextPrefab, spawnPosInternal,
			floatingScoreTextPrefab.transform.rotation);
		
		SetupFloatingScoreTextSettings(spawnedFloatingScoreObject, pointAmount);
		StartCoroutine(FloatingTextCoroutine(spawnedFloatingScoreObject, floatingTextMoveUpSpeed,
			floatingTextLingerTime));
	}

	private void SetupFloatingScoreTextSettings(GameObject floatingScoreObject, int pointAmount) {
		var floatingScoreText = floatingScoreObject.GetComponentInChildren<TextMeshProUGUI>();
		floatingScoreText.text = pointAmount.ToString();
		floatingScoreText.color = pointAmount > 0 ? positiveScoreColor : negativeScoreColor;
	}

	private IEnumerator FloatingTextCoroutine(GameObject floatingText, float moveUpSpeed, float destroyTime) {
		var floatingTextTransform = floatingText.transform;
		var timer = 0f;
		while (timer < destroyTime) {
			floatingTextTransform.Translate(Vector3.up * (Time.deltaTime * moveUpSpeed));
			var toCameraVector = (floatingTextTransform.position - cameraTransform.position).normalized;
			floatingTextTransform.forward = toCameraVector;
			timer += Time.deltaTime;
			yield return null;
		}
		Destroy(floatingText);
	}
}