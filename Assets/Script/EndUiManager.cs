using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EndUiManager : MonoBehaviour
{
    public TMP_Text TextTotalScore = null;  // 엔드씬에 출력할 점수 텍스트

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 최종 점수 출력
        TextTotalScore.text = "Total Score : " + UiManager.Instance.Score.ToString();
    }

    // 게임씬으로 되돌아가는 함수
    public void ResetGame()
    {
        SceneManager.LoadScene("MenuScene");
    }
}