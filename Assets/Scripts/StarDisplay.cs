using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent (typeof(Text))]
public class StarDisplay : MonoBehaviour {

    private Text display;
    private int stars = 100;

    public enum Status{SUCCESS, FAILURE};

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

    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            display.text = stars.ToString();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }
}
