using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeObstruction : MonoBehaviour
{
    public bool isActive = true;
    public bool isTimed = true;
    SpriteRenderer spriteRenderer;
    Collider2D objectCollider;
    public float delaySeconds = 3f;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        objectCollider = gameObject.GetComponent<BoxCollider2D>();
        if (isTimed)
        {
            StartCoroutine(ShowAndHide());
        }

    }

    private void OnTriggerEnter2D (Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }
    }
    

    IEnumerator ShowAndHide ()
    {
        yield return new WaitForSeconds(delaySeconds);
        ActivateSpike();
    }
    private void ActivateSpike()
    {
        switch (isActive)
        {
            case true:
                isActive = false;
                spriteRenderer.enabled = false;
                objectCollider.enabled = false;
                StartCoroutine(ShowAndHide());
                break;

            case false:
                isActive = true;
                spriteRenderer.enabled = true;
                objectCollider.enabled = true;
                StartCoroutine(ShowAndHide());
                break;
        }
    }
}
