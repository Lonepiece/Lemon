using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    public float displayImageDuration = 1f; // UI가 나타나있는 시간
    public float fadeDuration = 1f; // UI가 나타나는데 걸리는 시간
    public GameObject player; // 플레이어

    bool playerAtExit; // 플레이어가 출구에 도달했는지 여부
    bool playerCaught; // 플레이어가 적에게 잡혔는지 여부

    public CanvasGroup exitBackground; // 플레이어가 출구에 도달했을 때 나타날 UI의 배경
    public CanvasGroup caughtBackground; // 플레이어가 적에게 잡혔을 때 나타날 UI의 배경
    float timer; // 타이머

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
        exitBackground.alpha = timer / fadeDuration; // UI의 투명도를 서서히 올린다.

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
