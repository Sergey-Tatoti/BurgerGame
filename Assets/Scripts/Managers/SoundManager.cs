using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Меню")]
    [SerializeField] private AudioSource _audioSoundEatingFood;
    [SerializeField] private AudioSource _audioSoundClickedButton;
    [SerializeField] private AudioSource _audioMusicMenu;
    [Header("Игра")]
    [SerializeField] private AudioSource _audioMusicGame;
    [SerializeField] private AudioSource _audioSoundTakingFood;
    [SerializeField] private AudioSource _audioSoundEndGame;

    public void UseSoundEatingFood() => _audioSoundEatingFood.Play();

    public void UseSoundClickedButton() => _audioSoundClickedButton.Play();

    public void UseSoundTakingFood() => _audioSoundTakingFood.Play();

    public void UseSoundEndGame()
    {
        _audioMusicGame.Stop();
        _audioSoundEndGame.Play();
    }

    public void UseMusicMenu(bool isPlay)
    {
        if (isPlay)
            _audioMusicMenu.Play();
        else
            _audioMusicMenu.Pause();
    }

    public void UseMusicGame(bool isPlay)
    {
        if(isPlay)
            _audioMusicGame.Play();
        else
            _audioMusicGame.Pause();
    }
}