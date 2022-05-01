using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamePlay : MonoBehaviour
{
    public static gamePlay instance;

    [SerializeField]
    private Button isPlayButton;

    [SerializeField]
    private GameObject gameOverPanel;

    [SerializeField]
    private Text scoreText;

    private void Awake() {
        Time.timeScale = 0;
        _makeInstance();
    }

    void _makeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    public void playButton() {
        Time.timeScale = 1;
        isPlayButton.gameObject.SetActive(false);
    }

    public void setScore(int score) {
        scoreText.text = "" + score;
    }

    public void playAgainButton() {
        Application.LoadLevel("SampleScene");
    }

    public void showGameOverPanel() {
        gameOverPanel.SetActive(true);
    }
}
