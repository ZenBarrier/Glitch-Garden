using UnityEngine;
using UnityEngine.SceneManagement;
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
            music.volume = PlayerPrefsManager.GetMasterVolume();
            SetMusicPlayer(0);
            SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }
    }

    private void SceneManager_sceneLoaded(Scene arg0, LoadSceneMode arg1)
    {
        SetMusicPlayer(arg0.buildIndex);
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

    public void SetVolume(float volume)
    {
        music.volume = volume;
    }
}
