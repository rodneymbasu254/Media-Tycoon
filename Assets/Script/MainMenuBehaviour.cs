using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehaviour : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject missionsPanel;
    public GameObject settingsPanel;
    public GameObject shopPanel;
    public GameObject facebookPanel;
    public GameObject mainPanel;

    public Button continueButton;

    private PlayerProgress progress = new PlayerProgress();

    void Start()
    {
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(false);
        mainPanel.SetActive(true);

        if (progress.SaveExists())
        {
            continueButton.interactable = true;
        }
        else 
        {
            continueButton.interactable = false;
        }
    }

    public void NewGame()
    {
        PlayerPrefs.DeleteAll();
        progress = new PlayerProgress();
        progress.SaveProgress();
        SceneManager.LoadScene("Game");
    }

    public void ContinueGame()
    {
        if (progress.SaveExists())
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void Exit()
    {
        mainPanel.SetActive(true);
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(false);
    }

    public void ShowInfo()
    {
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(true);
        mainPanel.SetActive(false);
    }

    public void ShowSettings()
    {
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(true);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    public void ShowFacebook()
    {
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(true);
        infoPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    public void ShowShop()
    {
        missionsPanel.SetActive(false);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(true);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    public void ShowMissions()
    {
        missionsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        shopPanel.SetActive(false);
        facebookPanel.SetActive(false);
        infoPanel.SetActive(false);
        mainPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

}
