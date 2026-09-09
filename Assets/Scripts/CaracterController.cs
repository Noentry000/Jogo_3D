using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class    CaracterController : MonoBehaviour
{
    public float velocidade = 6.0f;
    public float forcaDoPulo = 8.0f;
    public float gravidade = 20.0f;

    private CharacterController controle;
    private Vector3 direcaoMovimento = Vector3.zero;

    private void Start()
    {
        controle = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Se o personagem estiver encostado no chão
        if (controle.isGrounded)
        {
            // 1. Pega os comandos do teclado (WASD / Setinhas)
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            // 2. Define a direção para onde andar
            direcaoMovimento = new Vector3(horizontal, 0, vertical);
            direcaoMovimento *= velocidade;

            // 3. Pulo
            if (Input.GetButton("Jump"))
            {
                direcaoMovimento.y = forcaDoPulo;
            }
        }

        // 4. Aplica a gravidade continuamente
        direcaoMovimento.y -= gravidade * Time.deltaTime;

        // 5. Move o personagem de fato
        controle.Move(direcaoMovimento * Time.deltaTime);
    }
}