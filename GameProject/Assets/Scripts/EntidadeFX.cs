using System.Collections;
using UnityEngine;

public class EntidadeFX : MonoBehaviour
{
    private SpriteRenderer sr;

    [Header("Flash FX")]
    [SerializeField] private float flashDuration;
    [SerializeField] private Material hitMaterial;
    private Material originalMaterial;

    private void Start()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        originalMaterial = sr.material;
    }

    private IEnumerator FlashFX()
    {
        sr.material = hitMaterial;

        yield return new WaitForSeconds(flashDuration);

        sr.material = originalMaterial;
    }

    private void RedColorBlink()
    {
        if(sr.color != Color.blue)
            sr.color = Color.blue;
        else
            sr.color = Color.red;
    }

    private void CancelarRedBlink()
    {
        CancelInvoke();
        sr.color = Color.blue;
    }

}