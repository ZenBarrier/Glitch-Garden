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
            HandleWinCondition();
        }
    }

    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        Invoke("LoadNextLevel", 3);
    }

    //Destroy Objects with tag DestroyOnWin
    private void DestroyAllTaggedObjects()
    {
        GameObject[] taggedGameObjectsArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");
        foreach (GameObject gameObject in taggedGameObjectsArray)
        {
            Destroy(gameObject);
        }
    }

    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
