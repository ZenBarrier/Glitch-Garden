using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

    public int starCost;

    private StarDisplay display;

    void Start()
    {
        display = FindObjectOfType<StarDisplay>();
    }

    public void AddStars(int amount)
    {
        display.AddStars(amount);
    }
}
