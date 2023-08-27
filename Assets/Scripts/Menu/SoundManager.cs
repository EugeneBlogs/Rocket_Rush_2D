using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour {


    public static bool playSound
    {
        get
        {
            return PlayerPrefs.GetInt("sound") == 0;
        }
        private set
        {
            PlayerPrefs.SetInt("sound", value?0:1);
        }
    }

    public static bool playMusic
    {
        get
        {
            return PlayerPrefs.GetInt("music") == 0;
        }
        private set
        {
            PlayerPrefs.SetInt("music", value ? 0 : 1);
        }
    }

    [SerializeField] AudioSource _buttonSound;

    public static SoundManager Instance;

    public void SwitchSoundPlaying()
    {
        playSound = !playSound;
        ApplySounds();
    }

    public void SwitchMusicPlaying()
    {
        playMusic = !playMusic;
        ApplySounds();
    }

    private void Awake()
    {
        Instance = this;
        AddButtonsSound();
        ApplySounds();
    }

    private void Start()
    {
       
    }

    void ApplySounds()
    {
        var music = FindObjectsOfType<AudioSource>();
        foreach (var m in music)
        {
            if (m.tag == "Sound")
            {
                m.mute = !playSound;
            }
            else
            {
                m.mute = !playMusic;
            }
        }
    }

    void AddButtonsSound()
    {
        var buts = FindObjectsOfType<Button>();

        var butSound = Instantiate(_buttonSound) as AudioSource; 

        foreach(var b in buts)
        {
            if (b.tag != "Power")
            {
                b.onClick.AddListener(butSound.Play);
            }
        }
    }
}
