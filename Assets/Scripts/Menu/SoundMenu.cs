using UnityEngine;


public class SoundMenu : MonoBehaviour {

    [SerializeField]  GameObject _music;
    [SerializeField] GameObject _sound;

    private void Awake()
    {
        ApplyMusic();
        ApplySound();
    }

    public void SwitchMusic()
    {
        SoundManager.Instance.SwitchMusicPlaying();
        ApplyMusic();
    }

    public void SwitchSound()
    {
        SoundManager.Instance.SwitchSoundPlaying();
        ApplySound();
    }


    void ApplyMusic()
    {
        _music.SetActive(!SoundManager.playMusic);
    }

    void ApplySound()
    {
        _sound.SetActive(!SoundManager.playSound);
    }
}
