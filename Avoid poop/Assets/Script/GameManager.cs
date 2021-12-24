using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text ScoreText;
    [SerializeField] Text EndScoreText;
    [SerializeField] Dropdown dropdown;
    [SerializeField] GameObject _ScoreText;
    [SerializeField] GameObject EndTitle;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject SettingButton;
    [SerializeField] GameObject StartButton;
    [SerializeField] GameObject Player;
    public static GameManager instance;
    public bool isGameStop = false;
    public bool isGameStart = false;
    public bool isGameEnd = false;
    public bool isGameRestart = false;
    public bool isGameSet = false;
    public float Level;
    public float coolTime;
    public float score;
    private int intScore;
    private void Awake()
    {
        coolTime = 0.2f;
        EndTitle.SetActive(false);
        RestartButton.SetActive(false);
        SettingButton.SetActive(false);
        dropdown.gameObject.SetActive(false);
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (isGameEnd)
        {
            isGameStart = false;
            Time.timeScale = 0;
            _ScoreText.SetActive(false);
            EndTitle.SetActive(true);
            RestartButton.SetActive(true);
            SettingButton.SetActive(true);
            EndScoreText.text = intScore.ToString();
            Player.transform.position = new Vector2(0, Player.transform.position.y);
        }

        if (isGameStart)
        {
            score += Time.deltaTime * 15;
            intScore = Mathf.RoundToInt(score);
            ScoreText.text = intScore.ToString("D5");
            StartButton.SetActive(false);
        }

        if (isGameRestart)
        {   
            isGameRestart = false;
            isGameEnd = false;
            isGameStart = true;
            score = 0;
            Time.timeScale = 1;
            _ScoreText.SetActive(true);
            EndTitle.SetActive(false);
            RestartButton.SetActive(false);
            SettingButton.SetActive(false);
            dropdown.gameObject.SetActive(false);
            Level = dropdown.value;
            switch (Level)
            {
                case 0:
                    coolTime = 0.2f;
                    break;
                case 1:
                    coolTime = 0.15f;
                    break;
                case 2:
                    coolTime = 0.1f;
                    break;
                default:
                    break;
            }
        }

        if (isGameSet)
        {
            SettingButton.SetActive(true);
            dropdown.gameObject.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isGameSet = false;
                SettingButton.SetActive(false);
                dropdown.gameObject.SetActive(false);
            }
        }

        if (isGameStop)
        {
            Time.timeScale = 0; 
        }
    }   
}
