using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {

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
