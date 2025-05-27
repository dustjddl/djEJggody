using UnityEngine;
using UnityEngine.TestTools;

public class TargetController : MonoBehaviour
{
    private float MoveSpeed = 2.0f; // �̵� �ӵ�
    private float MoveRange = 10.0f; // �̵� ����

    private Vector3 StartPosition;  // Ÿ�� ���� ��ġ ������ ���� ����
    void Start()
    {
        StartPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Mathf.PingPong() : �ð��� ������� ���� ������ �ݺ��ϴ� �Լ�
        // PingPong�Լ��� ���� ������ ������ �Ÿ��� ����ϰ� offst ������ ������ ���� ��ġ�� �����Ѵ�
        float offset = Mathf.PingPong(Time.time * MoveSpeed, MoveRange) - (MoveRange / 2f); ;
        transform.position = StartPosition + new Vector3(offset, 0f, 0f);
    }

}