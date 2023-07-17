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

    public AudioSource exitAudio; // �÷��̾ �ⱸ�� �������� �� ����� �����
    public AudioSource caughtAudio; // �÷��̾ ������ ������ �� ����� �����
    bool m_HasAudioPlayed; // ������� ����Ǿ����� ����

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
            EndLevel(exitBackground, false, exitAudio);
        }
        else if (playerCaught)
        {
            EndLevel(caughtBackground, true, caughtAudio);
        }
    }

    private void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if (!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = timer / fadeDuration; // UI�� ������ ������ �ø���.

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
