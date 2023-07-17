using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// JohnLemon ĳ���͸� ����ٴϴ� ī�޶�
public class CameraFollow : MonoBehaviour
{
    public Transform target; // ī�޶� ����ٴ� ���
    public float smoothSpeed = 0.125f; // ī�޶� �󸶳� ���� �ӵ��� ����� ���� ������
    public Vector3 offset; // ī�޶��� ��ġ�� �����¸�ŭ �̵���ų �� �ִ�.

    void FixedUpdate() // Update() ��� FixedUpdate() ���
    {
        Vector3 desiredPosition = target.position + offset; // ī�޶� �̵��� ��ġ
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // �ε巯�� �̵��� ���� Lerp() ���
        transform.position = smoothedPosition; // ī�޶� ��ġ ����
        transform.LookAt(target); // ī�޶� Ÿ���� �ٶ󺸵��� ����
    }
}
