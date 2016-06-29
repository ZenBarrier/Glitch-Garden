using UnityEngine;
using System.Collections;

public class SplashController : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("EndSplash", 5);
	}

    void EndSplash()
    {
        LevelManager.LoadNextLevel();
    }
}
