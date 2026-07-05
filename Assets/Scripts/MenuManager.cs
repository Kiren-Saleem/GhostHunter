using UnityEngine;
//using static System.Net.Mime.MediaTypeNames;

public class MenuManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject instructionsPanel;

    public GameObject inventoryCanvas;
    public GameObject clueCanvas;
    public GameObject heartCanvas;
    public GameObject AudioSource;

    public void Start()
    {
        // Show only the main menu
        mainMenuPanel.SetActive(true);
        instructionsPanel.SetActive(false);

        // Hide all gameplay UI
        inventoryCanvas.SetActive(false);
        clueCanvas.SetActive(false);
        heartCanvas.SetActive(false);
        AudioSource.SetActive(false);
        Time.timeScale = 0f;
    }

    public void ShowInstructions()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void BackToMainMenu()
    {
        instructionsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void StartGame()
    {
        mainMenuPanel.SetActive(false);
        instructionsPanel.SetActive(false);
        AudioSource.SetActive(true);
        inventoryCanvas.SetActive(true);
        clueCanvas.SetActive(true);
        heartCanvas.SetActive(true);
        inventoryCanvas.SetActive(true);

        Time.timeScale = 1f;
    }

  

    public void QuitGame()
    {
        //Application.Quit();
    }
}