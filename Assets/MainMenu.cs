using UnityEngine;
using UnityEngine.SceneManagement; // ใช้เปลี่ยนฉาก

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Scene1"); // เปลี่ยนเป็นชื่อ Scene ของเกม
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Game Quit!"); // ใช้เช็คเวลาเล่นใน Unity (จะไม่มีผลเวลา Build)
    }
}
