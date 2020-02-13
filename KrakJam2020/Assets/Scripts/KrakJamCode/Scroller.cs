using UnityEngine;

public class Scroller : MonoBehaviour {
	[SerializeField] float scrollSpeed;

	void Update() {
		transform.Translate(Vector3.left * (scrollSpeed * Time.deltaTime),Space.World);
	}
}
