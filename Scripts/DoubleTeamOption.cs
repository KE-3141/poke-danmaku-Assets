using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTeamOption : Option
{
    private float rotationTotal = 0;
    private int[] rotationSnapPoints = { -180, -90, 0, 90, 180 };
    private float errorAmount = 0;
    new public void Start()
    {
        this.player = GetComponentInParent<Player>();
        base.Start();
    }

    new public void Update()
    {
        if (!this.player.isInCharacterSelectScene)
        {
            if (!this.player.isSlow)
            {
                this.rotateOnMove();
            }

            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void rotateOnMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0)
        {
            return;
        }

        // direction of the player's movement
        Vector3 direction = new Vector3(x, 0, 0) + new Vector3(0, y, 0);

        // convert to angle by frequency method
        double angleInRadians = Mathf.Atan2(direction.y, direction.x);
        double angleInDegrees = angleInRadians * 180 / Mathf.PI;

        Vector3 rotateDirection = angleInDegrees > this.rotationTotal ? Vector3.forward : Vector3.back;

        if (this.rotationTotal > angleInDegrees)
        {
            transform.RotateAround(this.player.transform.position, rotateDirection, 720 * Time.deltaTime);
            this.rotationTotal -= 720 * Time.deltaTime;
        }
        else if (this.rotationTotal < angleInDegrees)
        {
            transform.RotateAround(this.player.transform.position, rotateDirection, 720 * Time.deltaTime);
            this.rotationTotal += 720 * Time.deltaTime;
        }

        foreach (int snapPoint in this.rotationSnapPoints)
        {
            if (this.rotationTotal > snapPoint - 1 && this.rotationTotal < snapPoint + 1 && this.rotationTotal != snapPoint)
            {
                this.errorAmount = snapPoint - this.rotationTotal;
                this.rotationTotal = snapPoint;

                rotateDirection = this.errorAmount > 0 ? Vector3.forward : Vector3.back;

                transform.RotateAround(this.player.transform.position, rotateDirection, this.errorAmount * Time.deltaTime);
            }
        }
    }

}
