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
        Vector3 gridPoint = GetGridPosition();
        Defender[] defenders = FindObjectsOfType<Defender>();
        foreach (Defender obj in defenders)
        {
            if (obj.transform.position == gridPoint)
            {
                return;
            }
        }
        defender = Instantiate(Button.selectedDefender, gridPoint, Quaternion.identity) as GameObject;
        defender.transform.parent = defenderParent.transform;
    }

    Vector2 GetGridPosition()
    {
        Vector2 floatPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        int roundX = Mathf.Clamp(Mathf.RoundToInt(floatPoint.x), 1, 9);
        int roundY = Mathf.Clamp(Mathf.RoundToInt(floatPoint.y), 1, 5);
        return new Vector2(roundX, roundY);
    }
}
