using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterImageEffect : MonoBehaviour
{
    [SerializeField] public GameObject afterImagePrehab;
    [SerializeField] public float displayTime = 0.2f;
    [SerializeField] public float createRate = 0.05f;

    private WaitForSeconds wait;

    public bool isCreatingAfterImage = false;

    public IEnumerator Start()
    {
        this.wait = new WaitForSeconds(this.createRate);

        while (true)
        {
            CreateAfterImage();
            yield return this.wait;
        }
    }

    public void Update()
    {
    }

    public void CreateAfterImage()
    {
        if (this.isCreatingAfterImage)
        {
            StartCoroutine(CreateAfterImageRoutine());
        }
        else
        {
            StopCoroutine(CreateAfterImageRoutine());
        }
    }

    private IEnumerator CreateAfterImageRoutine()
    {
        AfterImage afterImage = this.afterImagePrehab.GetComponent<AfterImage>();
        afterImage.Instantiate(transform, this.displayTime);

        yield return this.wait;
    }
}






