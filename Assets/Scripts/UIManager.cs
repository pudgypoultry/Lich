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

    public void StartGameplay()
    {
        if (currentState is not MenuState.Main) // Can only start from main menu
        {
            Debug.Log("UIManager.ControlPausePanel: imagine trying to start the game from a non-main menu");
            return;
        }

        // TODO: Move camera to position

        currentState = MenuState.Gameplay;

        MainMenuPanel.SetActive(false);
        GameplayPanel.SetActive(true);

        // TODO: Start game logic
    }

    public void QuitGame()
    {
        // TODO: Game exit logic should probably go in a game manager

        Debug.Log("Game Quit."); // To show quit in editor
        Application.Quit();
    }

    public void ControlPausePanel(bool on)
    {
        if (on)
        {
            if (currentState is not MenuState.Gameplay) // Can only pause from gameplay
            {
                Debug.Log("UIManager.ControlPausePanel: WTF! Trying to pause from non-gameplay menu.");
                return;
            }

            GameplayPanel.SetActive(false); // TODO: Should we actually close it?
            PausePanel.SetActive(true);
            Time.timeScale = 0f;

            currentState = MenuState.Pause;
        }
        else
        {
            if (currentState is not MenuState.Pause)
            {
                Debug.Log("UIManager.ControlPausePanel: bruv trying to unpause when not even paused. smh ");
                return;
            }

            PausePanel.SetActive(false);
            GameplayPanel.SetActive(true); // TODO: related to above TODO
            Time.timeScale = 1f;

            currentState = MenuState.Gameplay;
        }
    }

    public void ControlSettingsPanel(bool on)
    {
        if (on)
        {
            // Remember where we came from and close it
            lastState = currentState;
            currentState = MenuState.Settings;

            prefabDictionary[lastState].SetActive(false);

            SettingsPanel.SetActive(true);
        }
        else
        {
            SettingsPanel.SetActive(false);

            prefabDictionary[lastState].SetActive(true); // Reopen last panel

            currentState = lastState;
            lastState = MenuState.Settings;
        }
    }

    //////////////////////////
    // END PUBLIC INTERFACE //
    //////////////////////////

    private enum MenuState
    {
        Main,
        Settings,
        Pause,
        Gameplay
    }
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
