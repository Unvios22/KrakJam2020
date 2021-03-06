﻿using UnityEngine;
using UnityEngine.EventSystems;

public class EnlargingButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler{
	
	[SerializeField] private Vector3 _enlargedScale = new Vector3(1.5f, 1.5f, 1.5f);

	private Vector3 _cachedScale;

	void Start(){
		_cachedScale = transform.localScale;
	}

	public void OnPointerEnter(PointerEventData eventData){
		transform.localScale = _enlargedScale;
		EventManager.OnUiButtonHoverEvent();
	}

	public void OnPointerExit(PointerEventData eventData){
		transform.localScale = _cachedScale;
	}

	public void OnPointerClick(PointerEventData eventData) {
		EventManager.OnUiButtonClickEvent();
	}
}