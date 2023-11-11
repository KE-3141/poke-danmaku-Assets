using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AvailableArea : MonoBehaviour
{
    [Header("Area Configuration")]
    [SerializeField] public Vector2 leftUpPosition;
    [SerializeField] public Vector2 rightUpPosition;
    [SerializeField] public Vector2 leftDownPosition;
    [SerializeField] public Vector2 rightDownPosition;
    [SerializeField] public bool isCircle;
    [SerializeField] public bool isTouchingWall;

    private float width
    {
        get
        {
            return this.rightUpPosition.x - this.leftUpPosition.x;
        }
    }
    private float height
    {
        get
        {
            return this.leftUpPosition.y - this.leftDownPosition.y;
        }
    }
    private SpriteRenderer spriteRenderer;
    private GameObject spriteMask;

    public void Start()
    {
        this.InitializeSpriteRenderer();

        if (!isCircle)
        {
            this.DrawRectangleMask();
        }
        else
        {
            this.DrawCircleMask();
        }
    }

    private void InitializeSpriteRenderer()
    {
        this.spriteMask = new GameObject("SpriteMask");
        this.spriteMask.AddComponent<SpriteMask>();
        this.spriteMask.transform.position = transform.position;

        this.spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        this.spriteRenderer.drawMode = SpriteDrawMode.Simple;
        this.spriteRenderer.size = new Vector2(this.width, this.height);
        this.spriteRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    private void DrawRectangleMask()
    {
        this.spriteMask.GetComponent<SpriteMask>().sprite =
            Resources.Load<Sprite>("Sprites/Square");
        this.spriteMask.transform.transform.localScale = new Vector3(
            this.width,
            this.height,
            1
        );

        this.spriteMask.transform.position = this.transform.position;
    }

    private void DrawCircleMask()
    {
        this.spriteMask.GetComponent<SpriteMask>().sprite =
            Resources.Load<Sprite>("Sprites/Circle");
        this.spriteMask.transform.transform.localScale = new Vector3(
            this.width,
            this.height,
            1
        );

        float radius = (this.leftDownPosition.x - this.rightDownPosition.x) / 2;
    }

    public Vector2 RestrictPositionOf(Player player, Vector2 position)
    {
        float playerWidth = player.GetComponent<SpriteRenderer>().bounds.size.x;
        float playerHeight = player.GetComponent<SpriteRenderer>().bounds.size.y;

        if (!isCircle)
        {
            float x = Mathf.Clamp(
                position.x,
                this.leftUpPosition.x - 0.75f + playerWidth / 2,
                this.rightUpPosition.x - 0.75f - playerWidth / 2
            );
            float y = Mathf.Clamp(
                position.y,
                this.leftDownPosition.y + playerHeight / 2,
                this.leftUpPosition.y - playerHeight / 2
            );

            if (x == position.x)
            {
                this.isTouchingWall = true;
            }
            else
            {
                this.isTouchingWall = false;
            }

            return new Vector2(x, y);
        }
        else
        {
            float radius = (this.rightDownPosition.x - this.leftDownPosition.x) / 2;
            position = Vector2.ClampMagnitude(position, radius - playerWidth / 2);

            if (position.magnitude == radius - playerWidth / 2)
            {
                this.isTouchingWall = true;
            }
            else
            {
                this.isTouchingWall = false;
            }

            return position;
        }
    }
}
