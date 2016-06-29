using UnityEngine;
using System.Collections;

public class Utilities : MonoBehaviour
{

    public void openWebPage(string page)
    {
        System.Diagnostics.Process.Start(page);
    }
}
