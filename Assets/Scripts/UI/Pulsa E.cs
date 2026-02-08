using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PulsaE : MonoBehaviour
{
    public float distancia = 3f;
    public GameObject textoE;
    public TextMeshProUGUI textoPista;
    public InputActionReference interactuar;
    private Interactuable actual;

    void OnEnable()
    {
        interactuar.action.Enable();
    }

    private void OnDisable()
    {
        interactuar.action.Disable();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        textoE.SetActive(false);
        textoPista.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        actual = null;

        if (Physics.Raycast(ray, out hit, distancia))
        {
            actual = hit.collider.GetComponent<Interactuable>();
            if (actual != null)            {
                textoE.SetActive(true);
                if (interactuar.action.WasPressedThisFrame())
                {
                    textoPista.text = actual.textoInteraccion();
                    textoPista.gameObject.SetActive(true);
                    actual.Interactuar();
                }
                return;
            }
        }
        textoE.SetActive(false);
        textoPista.gameObject.SetActive(false);        
    }
}