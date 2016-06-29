using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    static MusicPlayer instance = null;

    public AudioClip startMusic;
    public AudioClip gameMusic;
    public AudioClip endMusic;

    private AudioSource music;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            instance = this;
            music = this.GetComponent<AudioSource>();
            GameObject.DontDestroyOnLoad(gameObject);
            SetMusicPlayer(0);
        }
    }

    void SetMusicPlayer(int level)
    {
        Debug.Log(this.GetInstanceID()+"=id musci level:" + level);
        music.Stop();
        switch (level)
        {
            case 0:
                music.clip = startMusic;
                break;
            case 1:
                music.clip = gameMusic;
                break;
            case 2:
                music.clip = endMusic;
                break;
            default:
                break;
        }
        music.loop = true;
        music.Play();
    }

    void OnLevelWasLoaded(int level)
    {
        if (instance == this)
        {
            SetMusicPlayer(level);
        }
    }
    
	
	// Update is called once per frame
	void Update () {
	
	}
}
