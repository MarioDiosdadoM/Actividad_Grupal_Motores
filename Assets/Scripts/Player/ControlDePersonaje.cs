//Debido a que las nuevas versiones de Unity dificultan el uso del viejo sistema de inputs he decidido usar el Input System

using UnityEngine;

public class ControlDePersonaje : MonoBehaviour
{
    [SerializeField] private AudioClip pasos; //sonido de pasos
    private AudioSource audioSource;
    public float velocidadMovimiento = 10f;   //Variable para modificar la velocidad de movimiento desde el inspector
    public float velocidadRotacion = 100f;   //Variable para modificar la velocidad de rotación desde el inspector
    private CharacterController controlador;     
    private PlayerControls controles;
    
    void Awake()
    {
        controlador = GetComponent < CharacterController >();
        controles = new PlayerControls();
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = pasos;
    }

    private void OnEnable() => controles.Enable();
    private void OnDisable() => controles.Disable();

    // Update is called once per frame
    void Update()
    {
        float moverInput = controles.Personaje.Mover.ReadValue<float>();
        float rotarInput = controles.Personaje.Rotar.ReadValue<float>();
        //Debug.Log("MoverInput: " + moverInput + " | RotarInput: " + rotarInput);
        transform.Rotate(0f, rotarInput * velocidadRotacion * Time.deltaTime, 0f);
        Vector3 move = transform.forward * moverInput * velocidadMovimiento;
        controlador.Move(move * Time.deltaTime);
        if (!audioSource.isPlaying && moverInput != 0 && Time.timeScale != 0) //sonido pasos
        {
            audioSource.Play();
        }
    }
}