using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadScript : MonoBehaviour {
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (!other.gameObject.CompareTag("Player")) return;
		GameManager.Instance.ResetGame();
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
