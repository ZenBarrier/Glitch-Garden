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
        int defenderCost = defender.GetComponent<Defender>().starCost;
        Vector3 gridPoint = GetGridPosition();

        if (isGridSpotFree(gridPoint))
        {
            if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
            {
                SpawnDefender(gridPoint, defender);
            }
        }
    }

    bool isGridSpotFree(Vector3 gridPoint)
    {
        Defender[] defenders = FindObjectsOfType<Defender>();
        foreach (Defender obj in defenders)
        {
            if (obj.transform.position == gridPoint)
            {
                return false;
            }
        }
        return true;
    }

    void SpawnDefender(Vector2 position, GameObject defender)
    {
        defender = Instantiate(Button.selectedDefender, position, Quaternion.identity) as GameObject;
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
