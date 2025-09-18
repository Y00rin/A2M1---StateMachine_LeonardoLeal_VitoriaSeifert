using UnityEngine;

public class PlayerVida : MonoBehaviour
{
    [Header("Status")]
    public float vidaMaxima = 100f;
    private float vidaAtual;

    [Header("Referências")]
    public GameObject painelMorte;

    void Start()
    {
        vidaAtual = vidaMaxima;
        AtualizarBarraDeVida(); // ← Agora funciona!
    }

    public void ReceberDano(float dano)
    {
        vidaAtual -= dano;
        vidaAtual = Mathf.Clamp(vidaAtual, 0, vidaMaxima);
        Debug.Log("Jogador recebeu " + dano + " de dano. Vida: " + vidaAtual + "/" + vidaMaxima);

        AtualizarBarraDeVida();

        if (vidaAtual <= 0)
        {
            Morrer();
        }
    }

    void Morrer()
    {
        Debug.Log("💀 Jogador morreu!");
        GetComponent<Collider>().enabled = false;
        GetComponent<PlayerMover>().enabled = false;

        if (painelMorte != null)
        {
            painelMorte.SetActive(true);
        }

        enabled = false;
    }

    void AtualizarBarraDeVida()
    {
        Debug.Log("🔄 Atualizando barra de vida do jogador...");
    }

    public float GetVidaAtual() => vidaAtual;
    public float GetVidaMaxima() => vidaMaxima;
}