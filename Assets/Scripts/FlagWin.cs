using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlagWin : MonoBehaviour
{
	public float FlagPos = 0;
	
	private bool won = false;

	private void OnDrawGizmosSelected() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireCube(Vector3.right * FlagPos, Vector3.up * 100);
	}

	void Update() {
		if (!won && transform.position.x > FlagPos) {
			won = true; //only one win per flagpole per scene
			GameState.Current?.Win();
		}
	}
}
