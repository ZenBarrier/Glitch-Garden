using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;
    private StarDisplay starDisplay;

    // Use this for initialization
    void Start()
    {
        starDisplay = FindObjectOfType<StarDisplay>();
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        GameObject defender = Button.selectedDefender;
        Vector3 gridPoint = GetGridPosition();
        Defender[] defenders = FindObjectsOfType<Defender>();
        foreach (Defender obj in defenders)
        {
            if (obj.transform.position == gridPoint)
            {
                return;
            }
        }
        if (StarDisplay.Status.SUCCESS == starDisplay.UseStars(defender.GetComponent<Defender>().starCost))
        {
            defender = Instantiate(Button.selectedDefender, gridPoint, Quaternion.identity) as GameObject;
            defender.transform.parent = defenderParent.transform;
        }
    }

    Vector2 GetGridPosition()
    {
        Vector2 floatPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int roundX = Mathf.Clamp(Mathf.RoundToInt(floatPoint.x), 1, 9);
        int roundY = Mathf.Clamp(Mathf.RoundToInt(floatPoint.y), 1, 5);
        return new Vector2(roundX, roundY);
    }
}
