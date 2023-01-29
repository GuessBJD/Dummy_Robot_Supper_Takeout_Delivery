using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSoundEffect;

    public void Play()
    {
        clickSoundEffect.Play();
        Loader.PlayGame();
    }

    // Update is called once per frame
    public void Quit()
    {
        clickSoundEffect.Play();
        Loader.QuitGame();
    }

    public void ToMainMenu()
    {
        clickSoundEffect.Play();
        Loader.ToMainMenu();
    }
}
