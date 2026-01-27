using UnityEngine;

public class Muerte : MonoBehaviour
{
    public static Muerte menu;

    public GameObject panelMuerte;

    private void Awake()
    {
        if (menu == null) {
            menu = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }
    void Start()
    {
        panelMuerte.SetActive(false);
    }

    public void MostrarPanel()
    {
        panelMuerte.SetActive(true);
        Time.timeScale = 0f;
        
    }

    public void OcultarPanel()
    {
        panelMuerte.SetActive(false);
        Time.timeScale = 1f;
        
    }

    public void Abandonar()
    {
        Application.Quit();
    }
}
