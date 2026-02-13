using UnityEngine;

public class AtaquePersonaje : MonoBehaviour
{
    [SerializeField] private Camera Camara;
    [SerializeField] Bala m_Bala;
    [SerializeField] Transform m_SpawnBala;
    [SerializeField] AudioClip clip;
    private AudioSource audioSource;
    private float distanciaMax = 100f;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        //No hacer nada si no se presiona clic
        if (!Input.GetMouseButtonDown(0)) { return; }
        animator.SetTrigger("fireball");
        audioSource.clip = clip;
        audioSource.Play();
        //Creamos el rayo desde la camara hasta la posicion del mouse
        Ray ray = Camara.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(ray.origin, ray.direction * 100f, Color.red, 2f);

        if(Physics.Raycast(ray, out RaycastHit hit, distanciaMax))
        {
            Vector3 direccion = ray.direction;

            Bala bala = PoolManager.Release(m_Bala.gameObject, m_SpawnBala.position, Quaternion.identity).GetComponent<Bala>();
            bala.Inicializar(direccion);
            StartCoroutine(bala.ContarTiempo(bala));
        }
    }
}