using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; set; }

    private void Awake()
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
    public bool EasyMode = true;
    public GameObject mainMenuUI;
    public GameObject DifficultyUI;
    public GameObject TutorialUI1;
    public GameObject TutorialUI2;
    public GameObject TutorialUI3;
    public GameObject TutorialUI4;
    public GameObject TutorialUI5;
    public GameObject TutorialUI6;
    public GameObject TutorialUI7;
    public GameObject TutorialUI8;

    public Button StartingGame;

    //DIfficulity Button
    public Button EasyButton;
    public Button HardButton;

    //Skip Tutorial Button
    public Button YesTutorialButton;
    public Button NoTutorialButton;

    //Buttons inside Tutorial
    public Button T2Next;
    public Button T3Back;
    public Button T3Next;
    public Button T4Back;
    public Button T4Next;
    public Button T5Back;
    public Button T5Next;
    public Button T6Back;
    public Button T6Next;
    public Button T7Back;
    public Button T7Next;
    public Button T8Back;
    public Button T8Next;






    void Start()
    {
        mainMenuUI.SetActive(true);
        DifficultyUI.SetActive(false);
        TutorialUI1.SetActive(false);
        TutorialUI2.SetActive(false);
        TutorialUI3.SetActive(false);
        TutorialUI4.SetActive(false);
        TutorialUI5.SetActive(false);
        TutorialUI6.SetActive(false);
        TutorialUI7.SetActive(false);
        TutorialUI8.SetActive(false);
        
        //OnClick methods for Buttons
        StartingGame.onClick.AddListener(delegate { ChooseDifficulty(); });
        EasyButton.onClick.AddListener(delegate { ChoseEasy(); });
        HardButton.onClick.AddListener(delegate { ChoseHard(); });
        YesTutorialButton.onClick.AddListener(delegate { StartGame(); });
        NoTutorialButton.onClick.AddListener(delegate { OpenTutorial(); });

        T2Next.onClick.AddListener(delegate { OpenTutorial3(); });
        T3Next.onClick.AddListener(delegate { OpenTutorial4(); });
        T3Back.onClick.AddListener(delegate { CloseTutorial3(); });
        T4Next.onClick.AddListener(delegate { OpenTutorial5(); });
        T4Back.onClick.AddListener(delegate { CloseTutorial4(); });
        T5Next.onClick.AddListener(delegate { OpenTutorial6(); });
        T5Back.onClick.AddListener(delegate { CloseTutorial5(); });
        T6Next.onClick.AddListener(delegate { OpenTutorial7(); });
        T6Back.onClick.AddListener(delegate { CloseTutorial6(); });
        T7Next.onClick.AddListener(delegate { OpenTutorial8(); });
        T7Back.onClick.AddListener(delegate { CloseTutorial7(); });
        T8Next.onClick.AddListener(delegate { StartGame(); });
        T8Back.onClick.AddListener(delegate { CloseTutorial8(); });

    }

    void ChooseDifficulty()
    {
        mainMenuUI.SetActive(false);
        DifficultyUI.SetActive(true);
    }

    void ChoseEasy()
    {
        // Easy
        DifficultyUI.SetActive(false);
        TutorialUI1.SetActive(true);
        
    }

    void ChoseHard()
    {
        // Hard
        DifficultyUI.SetActive(false);
        TutorialUI1.SetActive(true);
        EasyMode = false;
    }

    void OpenTutorial()
    {
        TutorialUI1.SetActive(false);
        TutorialUI2.SetActive(true);
    }

    void OpenTutorial3()
    {
        TutorialUI2.SetActive(false);
        TutorialUI3.SetActive(true);
    }

    void CloseTutorial3()
    {
        TutorialUI3.SetActive(false);
        TutorialUI2.SetActive(true);
    }

    void OpenTutorial4()
    {
        TutorialUI3.SetActive(false);
        TutorialUI4.SetActive(true);
    }

    void CloseTutorial4()
    {
        TutorialUI4.SetActive(false);
        TutorialUI3.SetActive(true);
    }

    void OpenTutorial5()
    {
        TutorialUI4.SetActive(false);
        TutorialUI5.SetActive(true);
    }

    void CloseTutorial5()
    {
        TutorialUI5.SetActive(false);
        TutorialUI4.SetActive(true);
    }

    void OpenTutorial6()
    {
        TutorialUI5.SetActive(false);
        TutorialUI6.SetActive(true);
    }

    void CloseTutorial6()
    {
        TutorialUI6.SetActive(false);
        TutorialUI5.SetActive(true);
    }

    void OpenTutorial7()
    {
        TutorialUI6.SetActive(false);
        TutorialUI7.SetActive(true);
    }

    void CloseTutorial7()
    {
        TutorialUI7.SetActive(false);
        TutorialUI6.SetActive(true);
    }

    void OpenTutorial8()
    {
        TutorialUI7.SetActive(false);
        TutorialUI8.SetActive(true);
    }

    void CloseTutorial8()
    {
        TutorialUI8.SetActive(false);
        TutorialUI7.SetActive(true);
    }



    public void StartGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
