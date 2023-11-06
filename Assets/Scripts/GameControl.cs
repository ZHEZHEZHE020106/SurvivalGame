using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Start is called before the first frame update
    private float Timer = 2;

    public void GameOver()
    {
        Timer -= 1 * Time.deltaTime;
        if (Timer <= 0)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    

    void Update()
    {
        if (PlayerStatus.Instance.CurrentHealth <= 0)
        {
            GameOver();
        }
    }
}
