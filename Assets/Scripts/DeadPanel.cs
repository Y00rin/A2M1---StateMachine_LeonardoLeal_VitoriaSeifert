using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeadPanel : MonoBehaviour
{
    public GameObject ContainerDead;

    public void ShowDeadPanel()
    {
        ContainerDead.SetActive(true);
        Time.timeScale = 0;
    }

    public void RestartButton()
    {
        Debug.Log("🎮 Iniciando o jogo...");
        SceneManager.LoadScene("Historia");
    }

    public void MenuButton()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
