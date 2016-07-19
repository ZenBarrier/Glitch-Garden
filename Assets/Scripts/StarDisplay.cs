using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text display;
    private int stars = 0;

	// Use this for initialization
	void Start () {
        display = GetComponent<Text>();
        display.text = stars.ToString();
	}
	
	public void AddStars(int amount)
    {
        stars += amount;
        display.text = stars.ToString();
    }

    public void UseStars(int amount)
    {
        stars -= amount;
        display.text = stars.ToString();
    }
}
