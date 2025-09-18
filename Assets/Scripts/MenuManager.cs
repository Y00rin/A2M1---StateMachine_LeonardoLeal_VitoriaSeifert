using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Painéis")]
    public GameObject menuInicial;
    public GameObject menuOpcoes;
    public GameObject menuPause;

    [Header("Controles de Áudio")]
    public Slider sliderVolumeMusica;
    public AudioSource audioMusica;

    [Header("Configurações")]
    public string cenaMenuInicial = "MenuInicial";

    private void Start()
    {
        if (menuInicial != null) menuInicial.SetActive(true);
        if (menuOpcoes != null) menuOpcoes.SetActive(false);
        if (menuPause != null) menuPause.SetActive(false);

        if (sliderVolumeMusica != null)
        {
            float volumeSalvo = PlayerPrefs.GetFloat("VolumeMusica", 1f);
            sliderVolumeMusica.value = volumeSalvo;
            if (audioMusica != null)
                audioMusica.volume = volumeSalvo;
        }
    }

    public void Jogar()
    {
        Debug.Log("🎮 Iniciando o jogo...");
        SceneManager.LoadScene("Historia");
    }

 
    public void AbrirOpcoes()
    {
        DesativarTodosMenus();
        if (menuOpcoes != null) menuOpcoes.SetActive(true);
        Time.timeScale = 0f;
        Debug.Log("⚙️ Abrindo menu de opções");
    }

    public void SairJogo()
    {
        Debug.Log("🚪 Fechando o jogo...");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void Pause()
    {
        if (menuPause != null)
        {
            menuPause.SetActive(true);
            Time.timeScale = 0f;
            AudioListener.pause = true;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Debug.Log("⏸️ Jogo pausado");
    }

    public void Continuar()
    {
        if (menuPause != null) menuPause.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Debug.Log("▶️ Jogo continuado");
    }

    public void AjustarVolumeMusica()
    {
        if (sliderVolumeMusica != null && audioMusica != null)
        {
            audioMusica.volume = sliderVolumeMusica.value;
            PlayerPrefs.SetFloat("VolumeMusica", sliderVolumeMusica.value);
            Debug.Log($"🔊 Volume da música ajustado para: {sliderVolumeMusica.value:F2}");
        }
    }

    public void VoltarParaPause()
    {
        if (menuOpcoes != null) menuOpcoes.SetActive(false);
        if (menuPause != null) menuPause.SetActive(true);
        Debug.Log("⬅️ Voltando para o menu de pause");
    }

    public void VoltarParaMenuInicial()
    {
        if (menuOpcoes != null) menuOpcoes.SetActive(false);
        if (menuInicial != null) menuInicial.SetActive(true);
        Time.timeScale = 1f;
        AudioListener.pause = false;
        Debug.Log("🏠 Voltando para o menu inicial");
    }

    public void IrParaMenuInicial()
    {
        SceneManager.LoadScene(cenaMenuInicial);
        Time.timeScale = 1f;
        Debug.Log("🏠 Indo para o menu inicial");
    }

    private void DesativarTodosMenus()
    {
        if (menuInicial != null) menuInicial.SetActive(false);
        if (menuOpcoes != null) menuOpcoes.SetActive(false);
        if (menuPause != null) menuPause.SetActive(false);
    }
}