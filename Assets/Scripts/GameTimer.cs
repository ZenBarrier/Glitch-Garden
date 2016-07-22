using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
    [Tooltip("Time to win in seconds.")]
    public float levelTime;
    
    private Slider timeSlider;
    private LevelManager levelManager;

    void Start()
    {
        timeSlider = GetComponent<Slider>();
        timeSlider.maxValue = levelTime;
        levelManager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        timeSlider.value = Time.timeSinceLevelLoad;

        if(Time.timeSinceLevelLoad >= levelTime)
        {
            levelManager.LoadLevel("03a Win");
        }
	}
}
