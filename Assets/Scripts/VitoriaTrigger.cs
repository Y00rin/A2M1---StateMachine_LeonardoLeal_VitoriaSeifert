using UnityEngine;

public class VitoriaTrigger : MonoBehaviour
{
    [Tooltip("O painel 'Você Ganhou' no Canvas")]
    public GameObject telaVitoria;

    [Tooltip("Tag do jogador. Ex: 'Player'")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            if (telaVitoria != null)
            {
                telaVitoria.SetActive(true);
                Time.timeScale = 0f;
                Debug.Log("Você venceu!");
            }
            else
            {
                Debug.LogWarning("Tela de vitória não está definida no Inspector!");
            }
        }
    }
}