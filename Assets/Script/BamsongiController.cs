// ���콺 Ŭ���ϸ� ����̰� �������� ���ư��� ���� ����

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    // �浹�� �� ���� �߻��ϵ��� �����ϴ� ����
    private bool hasCollided = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ����̽� ���ɿ� ���� ������ ���� ���ֱ�
        Application.targetFrameRate = 60;

        /*
         *  ����̰� ȭ�� �������� ���ư����� z�� ������ ���͸� �Ű������� �����ϰ�
           f_TargetShoot �޼��带 ȣ��. 
         * y�� �������� ���� 200 ���ϴ� ������ ����̰� ���ῡ ��� ���� �߷��� ������ �޾� �������� �����ϴ� ���� ���� ����
         * Start �޼��带 ȣ���ϴ� ���۰� ���ÿ� ����̰� �������� ���ư�
         */
        //f_TargetShoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // �Ű����� �������� ����̿��� ���� ���ϴ� �޼���
    public void f_TargetShoot(Vector3 argDir)
    {
        // �Ű������� ���޵� Vector ������ ���� ���Ѵ�.
        GetComponent<Rigidbody>().AddForce(argDir);
    }

    // physics�� ����ϹǷ� ����� ����̰� �浹�ϸ� onCollisionEnter �޼��尡 ȣ��Ǿ� �����
    private void OnCollisionEnter(Collision collision)
    {

        // �̹� �浹�� ��� �ٽ� �������� �ʵ��� ����
        if (hasCollided) return;
        // �浹 ���¸� true�� ����Ͽ� �ߺ� ���� ����
        hasCollided = true;

        // ����̰� ���ῡ ��� ���� ����� �������� ���߹Ƿ�, Rigidbody ������Ʈ�� iskinematic �޼��带 true�� ����
        // isKinematic �޼��带 true�� ���� �ϸ�, ������Ʈ�� �ۿ��ϴ� ���� �����ϰ� ����̸� ������Ŵ
        // iskinematic �޼��� : �ܺο��� �������� ������ ���� �������� �ʴ� ������Ʈ��� �ǹ�. �߷°� �浹�� �������� �ʵ��� ��
        GetComponent<Rigidbody>().isKinematic = true;
        if(collision.gameObject.CompareTag("Target"))
        {
            // ���� ������ CameraController ��ũ��Ʈ�� ���� ��ü ã��
            CameraController zoomController = FindFirstObjectByType<CameraController>();
            if (zoomController != null)
            {
                // ����̸� ��ֹ��� ���̱�
                transform.SetParent(collision.transform);
                // ī�޶� �� ȿ�� ����
                zoomController.StartZoomEffect();
            }
            UiManager.Instance.UpdateScore();
        }
        else if (collision.gameObject.GetComponent<MoveAnimal>() != null) // ��ֹ��� �浹���� ���
        {
            // ����̸� ��ֹ��� ���̱�
            transform.SetParent(collision.transform);

            UiManager.Instance.UpdateGameCount();  // ������ �ø��� ����
        }
        GetComponent<ParticleSystem>().Play();             
    }

}
