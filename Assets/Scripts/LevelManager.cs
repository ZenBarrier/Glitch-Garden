using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public float loadTime;

    void Start()
    {
        if (loadTime > 0)
        {
            Invoke("LoadNextLevel", loadTime);
        }
    }

    public void LoadLevel(string name)
    {
        Debug.Log("Level loaded for: "+name);
        //Application.LoadLevel(name); //Depricated
        SceneManager.LoadScene(name);
    }

    public void QuitRequest()
    {
        Debug.Log("Quit requested!");
        Application.Quit(); //only works in PC build. Bad for mobiles
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
