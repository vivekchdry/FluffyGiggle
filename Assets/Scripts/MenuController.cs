using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [SerializeField] private Button playGame;
    [SerializeField] private Button settings;
    [SerializeField] private Button quitGame;
    [SerializeField] private Toggle musicOnOff;
    [SerializeField] private Toggle sfxOnOff;
    [SerializeField] private Button backToMainMenu;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject mainMenuPanel;

    private void Awake()
    {
        playGame.onClick.AddListener(StartGame);
        settings.onClick.AddListener(ToggleSettingsPanel);
        quitGame.onClick.AddListener(QuitGame);
        backToMainMenu.onClick.AddListener(ToggleMainMenuPanel);

        musicOnOff.onValueChanged.AddListener(ToggleMusic);
        sfxOnOff.onValueChanged.AddListener(ToggleSfx);
    }

    public void ToggleSettingsPanel()
    {
        if (settingsPanel == null)
        {
            return;
        }

        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void ToggleMainMenuPanel()
    {
        if (mainMenuPanel == null)
        {
            return;
        }

        mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    private void ToggleMusic(bool isOn)
    {
        Debug.Log("Music toggled: " + isOn);
    }

    private void ToggleSfx(bool isOn)
    {
        Debug.Log("SFX toggled: " + isOn);
    }

    // private void GoBackToMainMenu()
    // {
    //     SceneLoader.Instance.LoadSceneAsync("MenuScene");
    // }

    private void StartGame()
    {
        SceneLoader.Instance.LoadSceneAsync("GameScene");
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}