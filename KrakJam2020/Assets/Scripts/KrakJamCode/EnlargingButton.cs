using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler{
	
	[SerializeField] private Vector3 _enlargedScale = new Vector3(1.5f, 1.5f, 1.5f);

	private Vector3 _cachedScale;

	void Start(){
		_cachedScale = transform.localScale;
	}

	public void OnPointerEnter(PointerEventData eventData){
		transform.localScale = _enlargedScale;
	}

	public void OnPointerExit(PointerEventData eventData){
		transform.localScale = _cachedScale;
	}
}