using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [Header("Background Speed")]
    [SerializeField] public float speed = 0.1f;

    public void Update()
    {
        float y = Mathf.Repeat(Time.deltaTime * this.speed, 1);

        Vector2 offset = new Vector2(0, y);

        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", offset);
    }
}
