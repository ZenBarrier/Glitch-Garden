using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Button : MonoBehaviour {

    public static GameObject selectedDefender;

    public GameObject defenderPrefab;
    
    private Button[] buttonArray;
    private Text cost;

	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        cost = this.transform.GetComponentInChildren<Text>();
        cost.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}

    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        this.GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
    }
}
