using UnityEngine;

public class CameraSeguirPlayer : MonoBehaviour
{
    [Header("Configurações")]
    public Transform jogador;
    public Vector3 offset = new Vector3(0, 5, -2);
    public float suavidade = 0.1f;

    private Vector3 posicaoDesejada;
    private Vector3 velocidade = Vector3.zero;

    [SerializeField] private Quaternion rotacaoFixa;

    void Start()
    {
        rotacaoFixa = Quaternion.Euler(90, 0, 0);
    }

    void Update()
    {
        if (jogador != null)
        {
            posicaoDesejada = jogador.position + jogador.TransformDirection(offset);

            transform.position = Vector3.SmoothDamp(
                transform.position,
                posicaoDesejada,
                ref velocidade,
                suavidade
            );

            transform.rotation = rotacaoFixa;
        }
    }
}