using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Panel Prefabs")]
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject GameplayPanel;
    [SerializeField] private GameObject PausePanel;

    [Header("Settings")]
    [SerializeField] private MenuState initialMenuType = MenuState.Main;

    ////////////////////////////
    // START PUBLIC INTERFACE //
    ////////////////////////////

    public enum MenuState
    {
        Main,
        Settings,
        Pause,
        Gameplay
    }


    public void ControlMainPanel(bool enabled)
    {
        if (enabled)
        {
            MainMenuPanel.SetActive(true);
            currentState = MenuState.Main;
        }
        else
        {
            MainMenuPanel.SetActive(false);
            lastState = MenuState.Main;
        }
    }

    public void ControlGameplayPanel(bool enabled)
    {
        if (enabled)
        {
            // TODO: Move camera to position

            GameplayPanel.SetActive(true);
            currentState = MenuState.Gameplay;

            // TODO: Start game logic
        }
        else
        {
            GameplayPanel.SetActive(false);
            lastState = MenuState.Gameplay;
        }
    }

    public void ControlPausePanel(bool enabled)
    {
        if (enabled)
        {
            PausePanel.SetActive(true);
            currentState = MenuState.Pause;
        }
        else
        {
            PausePanel.SetActive(false);
            lastState = MenuState.Pause;
        }
    }

    public void ControlSettingsPanel(bool enabled)
    {
        if (enabled)
        {
            SettingsPanel.SetActive(true);
            currentState = MenuState.Settings;
        }
        else
        {
            SettingsPanel.SetActive(false);
            prefabDictionary[lastState].SetActive(true); // Reopen last panel
            lastState = MenuState.Settings;
        }
    }

    public void QuitGame()
    {
        // TODO: Game exit logic should probably go in a game manager

        Debug.Log("Game Quit."); // To show quit in editor
        Application.Quit();
    }

    //////////////////////////
    // END PUBLIC INTERFACE //
    //////////////////////////

    private Dictionary<MenuState, GameObject> prefabDictionary = new Dictionary<MenuState, GameObject>();
    private MenuState currentState;
    private MenuState lastState;

    private void Start()
    {
        // Cache UI panels
        prefabDictionary[MenuState.Main] = MainMenuPanel;
        prefabDictionary[MenuState.Settings] = SettingsPanel;
        prefabDictionary[MenuState.Gameplay] = GameplayPanel;
        prefabDictionary[MenuState.Pause] = PausePanel;

        // Make sure only initial panel is active
        foreach (var panel in prefabDictionary)
        {
            if (panel.Key == initialMenuType) panel.Value.SetActive(true);
            else panel.Value.SetActive(false);
        }

        currentState = initialMenuType; // Set current state
    }
}
