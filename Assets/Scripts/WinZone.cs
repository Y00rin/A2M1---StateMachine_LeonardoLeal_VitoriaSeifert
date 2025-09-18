using UnityEngine;

public class WinZone : MonoBehaviour
{
    public GameObject painelVitoria;

    private bool isPlayerInside = false;
    private bool isPrincessInside = false;

    private void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            CheckWinCondition();
        }

        if (other.CompareTag("Princess"))
        {
            isPrincessInside = true;
            CheckWinCondition();
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            CheckWinCondition();
        }

        if (other.CompareTag("Princess"))
        {
            isPrincessInside = false;
            CheckWinCondition();
        }
    }

    private void CheckWinCondition()
    {
        if (isPlayerInside && isPrincessInside)
        {
            Debug.Log("Você ganhou!!!");
            if (painelVitoria != null)
            {
                painelVitoria.SetActive(true);
            }
        }
    }
}
