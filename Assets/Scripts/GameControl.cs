using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

    public static GameControl Instance { get; set; }
    public void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

    }

    private float Timer = 2;
    public bool EasyMode = true;

    public GameObject PauseMenu;
    public GameObject SettingUI;
    public bool PauseMenuIsOpen;
    //Buttons in InGame Menu
    public Button Setting;
   
    public Button Exit;

    public Button Back;
    public void GameOver()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void Win()
    {
        int DaySurvived = DayNightSystem.instance.DaySurvived;
        int NumOfCollection = InventorySystem.Instance.CountNumOfItem("Collection");
        if (DaySurvived >=3 && NumOfCollection >= 3)
        {
            //Win
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Update()
    {
        if (PlayerStatus.Instance.CurrentHealth <= 0)
        {
            GameOver();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && !PauseMenuIsOpen)
        {
            PauseGame();
            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && PauseMenuIsOpen)
        {
            ContinueGame();
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    void Start()
    {
        PauseMenu.SetActive(false);
        PauseMenuIsOpen = false;

        Setting.onClick.AddListener(delegate { OpenSetting(); });
        Back.onClick.AddListener(delegate { BackToMenu(); });
        Exit.onClick.AddListener(delegate { ExitGame(); });
    }
    void ExitGame()
    {
        GameOver();
    }
    void PauseGame()
    {
        PauseMenu.SetActive(true);
        PauseMenuIsOpen = true;
        Time.timeScale = 0;
    }

    void ContinueGame()
    {
        PauseMenu.SetActive(false);
        PauseMenuIsOpen = false;
        Time.timeScale = 1;
    }

    void OpenSetting()
    {
        PauseMenu.SetActive(false);
        SettingUI.SetActive(true);
    }
    void BackToMenu()
    {
        SettingUI.SetActive(false);
        PauseMenu.SetActive(true);
    }

}
