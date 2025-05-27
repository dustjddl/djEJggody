using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndUiManager : MonoBehaviour
{
    public TMP_Text TextTotalScore = null;  // ������� ����� ���� �ؽ�Ʈ

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ���� ���� ���
        TextTotalScore.text = "Total Score : " + UiManager.Instance.Score.ToString();
    }

    // ���Ӿ����� �ǵ��ư��� �Լ�
    public void ResetGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}