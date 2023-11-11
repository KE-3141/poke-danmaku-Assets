using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class PlayerPicture : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private Player player;

    public void Awake()
    {
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.animator = GetComponent<Animator>();
    }

    public void DetectFinishedFadeOutAnimation()
    {
        this.spriteRenderer.sprite = this.player.sprite;
        this.player.Cry();
        this.animator.Play("FadeIn", 0, 0f);
    }

    public void ChangeCharacter(Player player)
    {
        this.player = player;
        this.animator.Play("FadeOut", 0, 0f);
    }

    public void Update()
    {

    }
}
