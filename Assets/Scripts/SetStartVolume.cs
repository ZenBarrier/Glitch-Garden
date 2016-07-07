using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MusicManager music = GameObject.FindObjectOfType<MusicManager>();
        music.SetVolume(PlayerPrefsManager.GetMasterVolume());
    }
}
