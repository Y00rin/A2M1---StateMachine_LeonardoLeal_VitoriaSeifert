using UnityEngine;
using UnityEngine.SceneManagement;

public class Historia : MonoBehaviour
{
    [Header("Telas")]
    public GameObject tela1; // Ex: Menu Principal
    public GameObject tela2; // Ex: Opções ou Fase 1
    public GameObject tela3; // Ex: Opções ou Fase 1
    public GameObject botao1; // Ex: Opções ou Fase 1
    public GameObject botao2; // Ex: Opções ou Fase 1
    public GameObject botao3; // Ex: Opções ou Fase 1

    void Start()
    {
        if (tela1 != null) tela1.SetActive(true);
        if (tela2 != null) tela2.SetActive(false);
        if (tela3 != null) tela2.SetActive(false);
    }

    public void TrocarParaTela2()
    {
        if (tela1 != null) tela1.SetActive(false);
        if (tela2 != null) tela2.SetActive(true);
        botao1.SetActive(false);
        botao2.SetActive(true);
    }

    public void TrocarParaTela3()
    {
        if (tela2 != null) tela2.SetActive(false);
        if (tela3 != null) tela3.SetActive(true);
        botao2.SetActive(false);
        botao3.SetActive(true);
    }

    public void IniciarJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
}