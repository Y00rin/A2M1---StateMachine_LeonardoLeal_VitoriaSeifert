using UnityEngine;

public class PlayerAtaque : MonoBehaviour
{
    [Header("Configurações")]
    public float dano = 20f;
    public float alcance = 2f;
    public LayerMask inimigos;

    [Header("Ataque à Distância")]
    public GameObject prefabProjetil;           // Prefab do projétil
    public Transform pontoDeLancamento;         // Ponto de onde o projétil sai
    public float velocidadeProjetil = 10f;      // Velocidade do projétil
    public float tempoRecargaDistancia = 0.8f;  // Tempo de recarga do ataque à distância

    [Header("Referências")]
    public PlayerVida playerVida;
    public Transform pontoDeAtaque;

    private bool podeAtacar = true;             // Cooldown do ataque corpo a corpo
    private bool podeAtacarDistancia = true;    // Cooldown do ataque à distância
    public float tempoRecarga = 1f;             // Cooldown do ataque corpo a corpo

    void Start()
    {
        if (pontoDeAtaque == null)
        {
            pontoDeAtaque = transform;
        }

        if (pontoDeLancamento == null)
        {
            pontoDeLancamento = transform; // Usa posição do jogador se não definido
        }

        if (playerVida == null)
        {
            playerVida = GetComponent<PlayerVida>();
        }
    }

    void Update()
    {
        // Ataque corpo a corpo - Tecla E
        if (Input.GetKeyDown(KeyCode.E) && podeAtacar)
        {
            Atacar();
        }

        // Ataque à distância - Clique esquerdo do mouse (ou Fire1)
        if (Input.GetMouseButtonDown(0) && podeAtacarDistancia)
        {
            AtacarADistancia();
        }
    }

    // Ataque corpo a corpo (área ao redor)
    void Atacar()
    {
        podeAtacar = false;

        Collider[] inimigosAtingidos = Physics.OverlapSphere(pontoDeAtaque.position, alcance, inimigos);

        foreach (Collider col in inimigosAtingidos)
        {
            ChefeIA chefe = col.GetComponent<ChefeIA>();
            if (chefe != null)
            {
                chefe.ReceberDano(dano);
                Debug.Log("Jogador ataca o chefe!");
            }
        }

        Invoke(nameof(ResetarAtaque), tempoRecarga);
    }

    void AtacarADistancia()
    {
        if (prefabProjetil == null)
        {
            Debug.LogError("Prefab do projétil não está definido!");
            return;
        }

        if (pontoDeLancamento == null)
        {
            Debug.LogError("Ponto de lançamento não está definido!");
            return;
        }

        // Instancia o projétil
        GameObject projetil = Instantiate(
            prefabProjetil,
            pontoDeLancamento.position,
            pontoDeLancamento.rotation
        );

        // Faz o projétil olhar na direção correta
        Camera mainCam = Camera.main;
        Vector3 direcao;
        if (mainCam != null)
        {
            direcao = mainCam.transform.forward;
        }
        else
        {
            direcao = Vector3.forward; // Backup
        }
        projetil.transform.LookAt(pontoDeLancamento.position + direcao);

        // Aplica velocidade
        Rigidbody rb = projetil.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = projetil.transform.forward * velocidadeProjetil;
        }
        else
        {
            Debug.LogError("O projétil não tem um Rigidbody!");
            Destroy(projetil); // Evita objetos sem física
            return;
        }

        // Cooldown
        podeAtacarDistancia = false;
        Invoke(nameof(ResetarAtaqueDistancia), tempoRecargaDistancia);
    }

    // Reseta o ataque corpo a corpo
    void ResetarAtaque()
    {
        podeAtacar = true;
    }

    // Reseta o ataque à distância
    void ResetarAtaqueDistancia()
    {
        podeAtacarDistancia = true;
    }

    // Gizmo para visualizar o alcance do ataque corpo a corpo
    private void OnDrawGizmosSelected()
    {
        if (pontoDeAtaque == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(pontoDeAtaque.position, alcance);

        if (pontoDeLancamento != null)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(pontoDeLancamento.position, 0.1f); // Mostra o ponto de tiro
        }
    }
}