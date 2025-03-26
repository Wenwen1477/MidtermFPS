using UnityEngine;
using UnityEngine.SceneManagement; // ������¹�ҡ

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1"); // ����¹�繪��� Scene �ͧ��
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // ������������ Unity (������ռ����� Build)
    }
}
