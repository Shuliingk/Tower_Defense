using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject optionsMenu;
    public Slider sliderMusic;
    public Slider sliderSfx;

    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void Options()
    {
        sliderMusic.value = PlayerPrefs.GetFloat("VolumeMusique", 0.25f);
        sliderSfx.value = PlayerPrefs.GetFloat("VolumeSFX", 0.5f);

        optionsMenu.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenWebsite()
    {
        Application.OpenURL("https://formation-facile.fr");
    }

    public void CloseOptions()
    {
        float musicVolume = sliderMusic.value;
        float sfxVolume = sliderSfx.value;

        PlayerPrefs.SetFloat("VolumeMusique", musicVolume);
        PlayerPrefs.SetFloat("VolumeSFX", sfxVolume);

        optionsMenu.SetActive(false);
    }

}
