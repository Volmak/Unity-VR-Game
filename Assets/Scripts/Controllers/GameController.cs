using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour 
{
	public static GameController Game = null;

	public int winPoints;
	public float restartTimeout;

	void Awake()
	{
		if (Game == null) {
			Game = this;
		} else if (Game != this) {
			Destroy (gameObject);
		}
	}

	public bool checkWin (int points)
	{
		if (points < winPoints) {
			return false;
		}

		onVictory ();

		return true;
	}

	void onVictory ()
	{
		Invoke("restartGame", restartTimeout);
	}

	void restartGame ()
	{
		Application.LoadLevel (Application.loadedLevel);
//		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
