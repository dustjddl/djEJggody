// 마우스 클릭하면 밤송이가 과녁으로 날아가는 동작 제어

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BamsongiController : MonoBehaviour
{

    // 충돌이 한 번만 발생하도록 제어하는 변수
    private bool hasCollided = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 디바이스 성능에 따른 실행결과 차이 없애기
        Application.targetFrameRate = 60;

        /*
         *  밤송이가 화면 안쪽으로 날아가도록 z축 방향의 벡터를 매개변수로 전달하고
           f_TargetShoot 메서드를 호출. 
         * y축 방향으로 힘을 200 가하는 이유는 밤송이가 과녁에 닿기 전에 중력의 영향을 받아 지면으로 낙하하는 것을 막기 위함
         * Start 메서드를 호출하는 시작과 동시에 밤송이가 과녁으로 날아감
         */
        //f_TargetShoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 매개변수 방향으로 밤송이에게 힘을 가하는 메서드
    public void f_TargetShoot(Vector3 argDir)
    {
        // 매개변수로 전달된 Vector 값으로 힘을 가한다.
        GetComponent<Rigidbody>().AddForce(argDir);
    }

    // physics를 사용하므로 과녁과 밤송이가 충돌하면 onCollisionEnter 메서드가 호출되어 실행됨
    private void OnCollisionEnter(Collision collision)
    {

        // 이미 충돌한 경우 다시 실행하지 않도록 방지
        if (hasCollided) return;
        // 충돌 상태를 true로 기록하여 중복 실행 방지
        hasCollided = true;

        // 밤송이가 과녁에 닿는 순간 밤송이 움직임이 멈추므로, Rigidbody 컴포넌트의 iskinematic 메서드를 true로 설정
        // isKinematic 메서드를 true로 설정 하면, 오브젝트에 작용하는 힘을 무시하고 밤송이를 정지시킴
        // iskinematic 메서드 : 외부에서 가해지는 물리적 힘에 반응하지 않는 오브젝트라는 의미. 중력과 충돌에 반응하지 않도록 함
        GetComponent<Rigidbody>().isKinematic = true;
        if(collision.gameObject.CompareTag("Target"))
        {
            // 현재 씬에서 CameraController 스크립트를 가진 객체 찾기
            CameraController zoomController = FindFirstObjectByType<CameraController>();
            if (zoomController != null)
            {
                // 밤송이를 장애물에 붙이기
                transform.SetParent(collision.transform);
                // 카메라 줌 효과 시작
                zoomController.StartZoomEffect();
            }
            UiManager.Instance.UpdateScore();
        }
        else if (collision.gameObject.GetComponent<MoveAnimal>() != null) // 장애물과 충돌했을 경우
        {
            // 밤송이를 장애물에 붙이기
            transform.SetParent(collision.transform);

            UiManager.Instance.UpdateGameCount();  // 점수는 올리지 않음
        }
        GetComponent<ParticleSystem>().Play();             
    }

}
