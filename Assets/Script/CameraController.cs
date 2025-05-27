using System.Collections;   // �ڷ�ƾ ����� ����ϱ� ���� ���ӽ����̽�
using UnityEngine;
using Unity.Cinemachine;    // Cinemachine ����� ����ϱ� ���� ���ӽ����̽�

public class CameraController : MonoBehaviour
{
    public CinemachineCamera CinemachineCam;    //Cinemachine ī�޶� ���������� �� ȿ���� �� ����� ������
    public float zoomInFOV = 10.0f;   // ������ ���� FOV������
    public float zoomOutFOV = 60.0f;    // �⺻ �þ߰�(�ܾƿ�)���� �ǵ��� ���� FOV ������
    public float zoomDuration = 4.0f;   // ����, �ܾƿ� �� �ҿ�ð�
    public float holdDuration = 3.0f;   // ���� ���� �����ð�

    private bool isZooming = false;
    // ���� �� �ִϸ��̼��� ���� ������ üũ�ϴ� �÷���
    // ����, �ܾƿ� �� �߰��� �߻���� �ʰ��ϱ� ���� ���
    public bool IsZooming => isZooming;
    // �ܺο��� isZooming ���¸� ���� �� �ְ� �ϴ� �б� ���� ������Ƽ
    // �ܺο����� isZooming�� ���� Ȯ���� �� �ְ� isZooming�� false�Ǵ� ���� ���� ���ϰ� �ϱ� ���� ���
    public void StartZoomEffect()
    {
        if (!isZooming) //�� ������ �� �ݺ� ������� �ʵ��� ����
            StartCoroutine(ZoomRoutine());  // �ڷ�ƾ���� �� ȿ�� ����
    }

    private IEnumerator ZoomRoutine()
    {
        isZooming = true;   // �� ���� ����

        // ����
        yield return StartCoroutine(ChangeFOV(zoomOutFOV, zoomInFOV, zoomDuration));
        // ���� ���� ����
        yield return new WaitForSeconds(holdDuration);

        // �ܾƿ�
        yield return StartCoroutine(ChangeFOV(zoomInFOV, zoomOutFOV, zoomDuration));
        // �� ���� ����
        isZooming = false;
    }

    private IEnumerator ChangeFOV(float from, float to, float duration)  // FOV�� �ε巴�� ��ȭ��Ű�� �ڷ�ƾ
    {
        // ��� �ð� �ʱ�ȭ
        float time = 0f;
        // ��ü ���� �ð� ���� �ݺ�
        while (time < duration)
        {
            float t = time / duration;
            // Lerp�� FOV ���� ���� �����Ͽ� �ε巴��(�ڿ�������) ��ȭ
            // ��: from=60.0f, to=30.0f, t=1.0f��� FOV�� 1�� ���� 60 �� 30���� �ڿ������� �پ��
            CinemachineCam.Lens.FieldOfView = Mathf.Lerp(from, to, t);
            // ��� �ð� ����
            time += Time.deltaTime;
            yield return null;
        }
        // ���������� FOV ���� ��Ȯ�� ����
        CinemachineCam.Lens.FieldOfView = to;
    }
}
