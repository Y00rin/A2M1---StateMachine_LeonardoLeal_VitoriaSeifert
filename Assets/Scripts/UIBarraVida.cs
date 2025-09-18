using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Script para atualizar uma barra de vida no UI.
/// </summary>
public class UIBarraVida : MonoBehaviour
{
    [Header("Configurações")]
    public Image barra;
    public GameObject objeto;

    private float vidaAtual = 100f;
    private float vidaMaxima = 100f;

    void Start()
    {
        if (barra == null || objeto == null)
        {
            Debug.LogError("❌ UIBarraVida: Barra ou objeto não definido!");
            return;
        }

        PlayerVida playerVida = objeto.GetComponent<PlayerVida>();
        ChefeIA chefeIA = objeto.GetComponent<ChefeIA>();

        if (playerVida != null)
        {
            vidaAtual = playerVida.GetVidaAtual();
            vidaMaxima = playerVida.GetVidaMaxima();
        }
        else if (chefeIA != null)
        {
            vidaAtual = chefeIA.vidaAtual;
            vidaMaxima = chefeIA.vidaMaxima;
        }
        else
        {
            Debug.LogError("❌ UIBarraVida: Objeto não tem PlayerVida nem ChefeIA!");
            return;
        }

        AtualizarBarra();
    }

    void Update()
    {
        if (objeto == null) return;

        PlayerVida playerVida = objeto.GetComponent<PlayerVida>();
        ChefeIA chefeIA = objeto.GetComponent<ChefeIA>();

        if (playerVida != null)
        {
            vidaAtual = playerVida.GetVidaAtual();
            vidaMaxima = playerVida.GetVidaMaxima();
        }
        else if (chefeIA != null)
        {
            vidaAtual = chefeIA.vidaAtual;
            vidaMaxima = chefeIA.vidaMaxima;
        }

        AtualizarBarra();
    }

    void AtualizarBarra()
    {
        if (barra != null && vidaMaxima > 0)
        {
            barra.fillAmount = vidaAtual / vidaMaxima;
        }
    }
}