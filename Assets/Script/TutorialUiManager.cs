using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using System;

public class TutorialUiManager : MonoBehaviour
{
    public TMP_Text TextScore = null;
    public TMP_Text TextCount = null;
    public TMP_Text TextTimer = null;

    public int Score = 0;                // 현재 점수
    public int Count = 10;      // 남은 밤송이 수 (게임 횟수)

    private static TutorialUiManager _instance = null;
    public static TutorialUiManager Instance
    {
        get
        {
            if (_instance == null) Debug.Log("UiManager is null.");
            return _instance;
        }
    }

    void Start()
    {      
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = "Score : " + Score.ToString();
        TextCount.text = "Count : " + Count.ToString();     
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.Log("TutorialUiManager has another instance.");
            Destroy(gameObject);
        }
    }

    public void UpdateScore()
    {
        Score += 10;
    }

    public void UpdateGameCount()
    {
        Count--;

        if (Count <= 0)
        {
            // 엔드씬 불러오기
            SceneManager.LoadScene("EndScene");// 엔드씬 불러오기
        }
    }
    public void GameOver()
    {
        // 간단하게 씬 다시 시작 (재도전)
        // 또는 UI 띄워서 "게임 종료" 알리기 등 가능
        Debug.Log("게임 종료!");
        SceneManager.LoadScene("EndScene");
    }
    //public void UpdateTime()
    //{
    //    CurrentTime -= Time.deltaTime;
    //    TextTimer.text = "Time: " + Mathf.CeilToInt(CurrentTime).ToString();

    //    if (CurrentTime <= 0)
    //    {
    //        GameOver();
    //    }
    //}
}
