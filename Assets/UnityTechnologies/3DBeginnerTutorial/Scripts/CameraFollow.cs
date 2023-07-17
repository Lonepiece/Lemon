using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// JohnLemon 캐릭터를 따라다니는 카메라
public class CameraFollow : MonoBehaviour
{
    public Transform target; // 카메라가 따라다닐 대상
    public float smoothSpeed = 0.125f; // 카메라가 얼마나 빠른 속도로 대상을 따라갈 것인지
    public Vector3 offset; // 카메라의 위치를 오프셋만큼 이동시킬 수 있다.

    void FixedUpdate() // Update() 대신 FixedUpdate() 사용
    {
        Vector3 desiredPosition = target.position + offset; // 카메라가 이동할 위치
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // 부드러운 이동을 위해 Lerp() 사용
        transform.position = smoothedPosition; // 카메라 위치 변경
        transform.LookAt(target); // 카메라가 타겟을 바라보도록 변경
    }
}
