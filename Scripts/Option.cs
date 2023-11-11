using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : Shooter
{
    public float positionXOnFocusMode;
    public float positionYOnFocusMode;
    public float rotationZOnFocusMode;
    protected Vector2 positionOnFocusMode;
    protected Vector2 defaultPosition;
    protected Quaternion defaultRotation;
    protected Player player;

    new public void Start()
    {
        base.Start();
        this.positionOnFocusMode = new Vector2(positionXOnFocusMode, positionYOnFocusMode);
        this.defaultPosition = this.transform.localPosition;
        this.defaultRotation = this.transform.localRotation;
        this.player = GetComponentInParent<Player>();
    }

    public void Update()
    {
        if (!this.player.isInCharacterSelectScene)
        {
            if (this.player.isSlow)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, this.positionOnFocusMode, 10f * Time.deltaTime);
                transform.localRotation = Quaternion.Euler(0, 0, rotationZOnFocusMode);
            }
            else if (!this.player.isSlow)
            {
                transform.localPosition = Vector2.MoveTowards(transform.localPosition, this.defaultPosition, 10f * Time.deltaTime);

                transform.localRotation = this.defaultRotation;
            }
        }
    }
}
