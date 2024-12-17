using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ui;

    [SerializeField]
    private float timeLeft;

    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private GameObject player;

    private void Start()
    {
        ui.SetActive(false);
    }

    public static void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void GameOver(string gameOverString)
    {
        player.SetActive(false);
        ui.SetActive(true);

        timerText.gameObject.SetActive(false);

        TMP_Text gameOverText = ui.transform.GetChild(0).GetComponent<TMP_Text>();

        gameOverText.text = gameOverString;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8)
            GameOver("You Win!");
    }

    private void Update()
    {
        if (timeLeft > 0f)
        {
            timerText.text = timeLeft.ToString("0.0000");
            timeLeft -= Time.deltaTime;
        }
        else
            GameOver("You Lose!");
    }
}
