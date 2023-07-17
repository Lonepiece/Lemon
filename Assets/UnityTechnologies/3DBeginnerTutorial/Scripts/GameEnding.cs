using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float displayImageDuration = 1f; // UI�� ��Ÿ���ִ� �ð�
    public float fadeDuration = 1f; // UI�� ��Ÿ���µ� �ɸ��� �ð�
    public GameObject player; // �÷��̾�

    bool playerAtExit; // �÷��̾ �ⱸ�� �����ߴ��� ����
    bool playerCaught; // �÷��̾ ������ �������� ����

    public CanvasGroup exitBackground; // �÷��̾ �ⱸ�� �������� �� ��Ÿ�� UI�� ���
    public CanvasGroup caughtBackground; // �÷��̾ ������ ������ �� ��Ÿ�� UI�� ���
    float timer; // Ÿ�̸�

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerAtExit = true;
        }
    }

    public void CaughtPlayer()
    {
        playerCaught = true;
    }

    private void Update()
    {
        if (playerAtExit)
        {
            EndLevel(exitBackground, false);
        }
        else if (playerCaught)
        {
            EndLevel(caughtBackground, true);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart)
    {
        timer += Time.deltaTime;
        exitBackground.alpha = timer / fadeDuration; // UI�� ������ ������ �ø���.

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}
