using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Image = UnityEngine.UI.Image;

public class UIManager : MonoBehaviour
{
    [Header("Panel Prefabs")]
    [SerializeField] private GameObject MainMenuPanel;
    [SerializeField] private GameObject SettingsPanel;
    [SerializeField] private GameObject GameplayPanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject CreditsPanel;
    [SerializeField] private GameObject VictoryPanel;
    [SerializeField] private GameObject GameOverPanel;
    
    [Header("Gameplay Panel Prefabs")]
    [SerializeField] private GameObject ToolTipPanel;
    [SerializeField] private GameObject DialoguePanel;

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
        Gameplay,
        Credits,
        Victory,
        GameOver,
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
            if (currentState == MenuState.Pause)
            {
                PausePanel.SetActive(false);
                lastState = MenuState.Pause;
            }
            SettingsPanel.SetActive(true);
            currentState = MenuState.Settings;
        }
        else
        {
            Debug.Log(lastState.ToString());
            if (lastState == MenuState.Pause)
            {
                PausePanel.SetActive(true);
                currentState = MenuState.Pause;
            }
            SettingsPanel.SetActive(false);
            prefabDictionary[lastState].SetActive(true); // Reopen last panel
            lastState = MenuState.Settings;
        }
    }

    public void ControlCreditsPanel(bool enabled)
    {
        if (enabled)
        {
            CreditsPanel.SetActive(true);
            currentState = MenuState.Credits;
        }
        else
        {
            CreditsPanel.SetActive(false);
            lastState = MenuState.Credits;
        }
    }

    public void ControlVictoryPanel(bool enabled)
    {
        if (enabled)
        {
            VictoryPanel.SetActive(true);
            currentState = MenuState.Victory;
        }
        else
        {
            VictoryPanel.SetActive(false);
            lastState = MenuState.Victory;
        }
    }

    public void ControlGameOverPanel(bool enabled)
    {
        if (enabled)
        {
            GameOverPanel.SetActive(true);
            currentState = MenuState.GameOver;
        }
        else
        {
            GameOverPanel.SetActive(false);
            lastState = MenuState.GameOver;
        }
    }

    public void DisplayDialogueBox(string message)
    {
        StartCoroutine(DisplayDelayedMessage(message));
    }

    IEnumerator DisplayDelayedMessage(string message)
    {
        // Set message
        DialoguePanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
        // Fade in the message
        DialoguePanel.GetComponentInChildren<TextMeshProUGUI>().CrossFadeAlpha(1.0f, 5.0f, false);
        DialoguePanel.GetComponentInChildren<Image>().CrossFadeAlpha(1.0f, 5.0f, false);
        // Wait for 5 seconds
        yield return new WaitForSeconds(5);
        // Fade out the message
        DialoguePanel.GetComponentInChildren<Image>().CrossFadeAlpha(0.0f, 5.0f, false);
        DialoguePanel.GetComponentInChildren<TextMeshProUGUI>().CrossFadeAlpha(0.0f, 5.0f, false);
        
        // TODO: Set up a boolean value to prevent multiple dialogues from appearing at once.
    }

    public void DisplayTooltip(string message)
    {
        ToolTipPanel.GetComponentInChildren<TextMeshProUGUI>().text = message;
        // TODO: Remove these? Instead look into responding to user clicking a card or something
        DialoguePanel.GetComponentInChildren<Image>().CrossFadeAlpha(1.0f, 5f, false);
        DialoguePanel.GetComponentInChildren<Image>().CrossFadeAlpha(0.0f, 5f, false);
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
        prefabDictionary[MenuState.Victory] = VictoryPanel;
        prefabDictionary[MenuState.GameOver] = GameOverPanel;
        prefabDictionary[MenuState.Credits] = CreditsPanel;

        // Make sure only initial panel is active
        foreach (var panel in prefabDictionary)
        {
            if (panel.Key == initialMenuType) panel.Value.SetActive(true);
            else panel.Value.SetActive(false);
        }

        currentState = initialMenuType; // Set current state
    }
}
