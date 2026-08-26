using UnityEngine;

public class MovimentoSimples : MonoBehaviour
{
    public float velocidade = 5f;
    public float forçaPulo = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 1. Pega os botões WASD / Setas
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 2. Move o personagem
        Vector3 movimento = new Vector3(x, 0, z) * velocidade;
        rb.linearVelocity = new Vector3(movimento.x, rb.linearVelocity.y, movimento.z);

        // 3. Pula com a Barra de Espaço
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forçaPulo, ForceMode.Impulse);
        }
    }
}