using UnityEngine;

public class VitoriaTrigger : MonoBehaviour
{
    [Tooltip("O painel 'Voc� Ganhou' no Canvas")]
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
                Debug.Log("Voc� venceu!");
            }
            else
            {
                Debug.LogWarning("Tela de vit�ria n�o est� definida no Inspector!");
            }
        }
    }
}