using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupsScript : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;
		GameManager.RegisterFood(gameObject.tag);
		Destroy(this.gameObject);
	}
}
