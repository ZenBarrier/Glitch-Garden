using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {

    static MusicManager instance;

    public AudioClip[] levelMusicChangeArray;

    private AudioSource music;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

	// Use this for initialization
	void Start () {
        if (instance != null && instance != this)
        {
            GameObject.Destroy(gameObject);
        }
        else
        {
            instance = this;
            music = this.GetComponent<AudioSource>();
            SetMusicPlayer(0);
        }
    }

    void SetMusicPlayer(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        if (thisLevelMusic && thisLevelMusic != music.clip)
        {
            music.Stop();
            music.clip = thisLevelMusic;
            if(level > 0)
            {
                music.loop = true;
            }
            else
            {
                music.loop = false;
            }
            music.Play();
        }
    }

    void OnLevelWasLoaded(int level)
    {
        SetMusicPlayer(level);
    }

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
}
