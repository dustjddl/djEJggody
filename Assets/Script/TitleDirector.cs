using UnityEngine;
using UnityEngine.SceneManagement;  //LoadScene�� ����ϱ� ���� SceneMnagement�� ����Ʈ��
public class TitleDirector : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.anyKeyDown)
        {
            SceneManager.LoadScene("MenuScene");
            //SceneManager.LoadScene(0);
            //���콺�� Ŭ���� ���� �����ϸ�, SceneManager Ŭ������ LoadScene �޼��带 ����� �� ��ȯ
        }
    }
}
