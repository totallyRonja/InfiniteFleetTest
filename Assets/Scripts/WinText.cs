using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinText : MonoBehaviour {
	private void Awake() {
		GameState.Won.OnChange += SetActive;
		SetActive(GameState.Won.Value);
	}

	private void OnDestroy() {
		GameState.Won.OnChange -= SetActive;
	}
	
	private void SetActive(bool active) => gameObject.SetActive(active);
}
