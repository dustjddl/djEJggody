using UnityEngine;

public class MoveAnimal : MonoBehaviour
{
    public float moveRange = 10.0f;        // �¿� �̵� �Ÿ�
    public float moveSpeed = 2.0f;        // �̵� �ӵ�
    private Vector3 startPos;

    void Start()
    {
        // ��ֹ��� ���� ���� ��ġ�� ������ ����
        startPos = transform.position;
    }

    void Update()
    {
        //��ֹ��� �ӵ��� �����ϰ� �ִ� �̵� ������ �����Ͽ� �ε巯�� �������� �����ϰ� ����
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveRange;
        // y, z �� ��ġ�� ���� �� (x�ุ ��ȭ�ǵ���,+ offset �߰�) �¿�θ� �Դ� ���� ��
        transform.position = new Vector3(startPos.x + offset, startPos.y, startPos.z);
    }
}
