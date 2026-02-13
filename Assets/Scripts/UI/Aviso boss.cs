using UnityEngine;
using System.Collections;

public class Avisoboss : MonoBehaviour
{
    public CanvasGroup panelAviso;
    public float duracion = 3f;
    public float fade = 1f;

    public void IniciarAviso()
    {
        StartCoroutine(Temporizador());
    }

    IEnumerator Temporizador()
    {
        yield return StartCoroutine(Fade(0f, 1f));
        yield return new WaitForSeconds(duracion);
        yield return StartCoroutine(Fade(1f, 0f));
    }

    IEnumerator Fade(float from, float to)
    {
        float t = 0f;

        while (t < fade)
        {
            t += Time.deltaTime;
            panelAviso.alpha = Mathf.Lerp(from, to, t / fade);
            yield return null;
        }

        panelAviso.alpha = to;
    }
}
