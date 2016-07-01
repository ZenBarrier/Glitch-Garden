using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsManager : MonoBehaviour {

    public Slider volumeSlider;
    public Slider difficultySlider;
    public LevelManager levelManager;

    private MusicManager musicManager;

    // Use this for initialization
    void Start () {
        musicManager = GameObject.FindObjectOfType<MusicManager>();
        Debug.Log(musicManager);

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        difficultySlider.value = PlayerPrefsManager.GetDifficulty();
	}

    void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
    }
	
    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        difficultySlider.value = 2f;
    }

	public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(difficultySlider.value);

        levelManager.LoadLevel("01a Start");
    }
}
