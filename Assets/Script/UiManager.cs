using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;
using System;

public class UiManager : MonoBehaviour
{
    public TMP_Text TextScore = null;
    public TMP_Text TextCount = null;
    public TMP_Text TextTimer = null;

    public int Score = 0;                // ���� ����
    public int Count = 10;      // ���� ����� �� (���� Ƚ��)
    public float GameTime = 30.0f;  // �� ���� �ð�
    private float CurrentTime;      // ���� ���� ���� �ð�

    private static UiManager _instance = null;
    public static UiManager Instance
    {
        get
        {
            if (_instance == null) Debug.Log("UiManager is null.");
            return _instance;
        }
    }
    
    void Start()
    {
        CurrentTime = GameTime;
    }

    // Update is called once per frame
    void Update()
    {
        TextScore.text = "Score : " + Score.ToString();
        TextCount.text = "Count : " + Count.ToString();

        // Ÿ��Ʋ ���� ��� Ÿ�̸Ӱ� �۵�
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            UpdateTime();
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else if (_instance != this)
        {
            Debug.Log("UiManager has another instance.");
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

        if(Count <= 0)
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

    // �ð��� ������ ���� Ÿ�̸Ӱ� �پ��� Ÿ�̸Ӱ� 0�� �Ǹ� ���ӿ��� �Լ�ȣ��
    public void UpdateTime()
    {
        CurrentTime -= Time.deltaTime;
        TextTimer.text = "Time: " + Mathf.CeilToInt(CurrentTime).ToString(); // Mathf.CeilToInt()�� ����Ͽ� CurrentTime�� ���� ������ ��ȯ

        if (CurrentTime <= 0)
        {
            GameOver();
        }
    }
}
