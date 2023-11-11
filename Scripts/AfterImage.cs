using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Attached to After Image Prehab
public class AfterImage : MonoBehaviour
{
    private float displayTime;
    private float displayTimer;
    private SpriteRenderer spriteRenderer;

    public AfterImage Instantiate(Transform transform, float displayTime)
    {
        AfterImage afterImage = Instantiate(
            this,
            transform.position,
            transform.rotation
        );
        afterImage.displayTime = displayTime;
        afterImage.displayTimer = displayTime;

        afterImage.spriteRenderer = afterImage.GetComponent<SpriteRenderer>();

        return afterImage;
    }

    private void FadeOut()
    {
        this.displayTimer -= Time.deltaTime;

        Color color = this.spriteRenderer.color;
        color.a = this.displayTimer / this.displayTime;
        this.spriteRenderer.color = color;

        if (this.displayTimer <= 0f)
        {
            Destroy(this.gameObject);
        }
    }

    public void Update()
    {
        this.FadeOut();
    }
}
