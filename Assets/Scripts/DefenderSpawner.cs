using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;

    // Use this for initialization
    void Start()
    {
        defenderParent = GameObject.Find("Defenders");
        if (!defenderParent)
        {
            defenderParent = new GameObject("Defenders");
        }
    }

    void OnMouseDown()
    {
        GameObject defender;
        defender = Instantiate(Button.selectedDefender, GetGridPosition(), Quaternion.identity) as GameObject;
        defender.transform.parent = defenderParent.transform;
    }

    Vector2 GetGridPosition()
    {
        Vector2 floatPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int roundX = Mathf.RoundToInt(floatPoint.x);
        int roundY = Mathf.RoundToInt(floatPoint.y);
        return new Vector2(roundX, roundY);
    }
}
