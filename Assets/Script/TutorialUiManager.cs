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

    public int Score = 0;                // ���� ����
    public int Count = 10;      // ���� ����� �� (���� Ƚ��)

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
            // ����� �ҷ�����
            SceneManager.LoadScene("EndScene");// ����� �ҷ�����
        }
    }
    public void GameOver()
    {
        // �����ϰ� �� �ٽ� ���� (�絵��)
        // �Ǵ� UI ����� "���� ����" �˸��� �� ����
        Debug.Log("���� ����!");
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
