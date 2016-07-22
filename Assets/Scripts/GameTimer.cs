using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {
    [Tooltip("Time to win in seconds.")]
    public float levelTime;

    private float elapsedTime = 0;
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
        elapsedTime += Time.deltaTime;
        timeSlider.value = elapsedTime;

        if(elapsedTime >= levelTime)
        {
            levelManager.LoadLevel("03a Win");
        }
	}
}
