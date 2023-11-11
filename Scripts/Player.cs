using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : Character
{
    [SerializeField] private AudioClip crySound;
    public bool isSlow { get; private set; }
    public bool isInCharacterSelectScene = false;

    // The area that the player can move in
    public AvailableArea availableArea;
    public List<Option> options;
    protected Ability ability;
    public PlayerInformation playerInformation;
    public Sprite sprite;

    public string prefabResourcePath()
    {
        return $"Prefabs/Players/{this.playerInformation.prefabName}/{this.playerInformation.prefabName}";
    }

    public virtual void Instantiate()
    {
    }

    public void Awake()
    {
        this.Instantiate();
    }

    new public void Start()
    {
        base.Start();
        this.availableArea = GetComponentInParent<AvailableArea>().GetComponent<AvailableArea>();
        this.options = new List<Option>(GetComponentsInChildren<Option>());
    }

    public void Cry()
    {
        AudioSource.PlayClipAtPoint(this.crySound, Camera.main.transform.position);
    }

    public void Move()
    {
        Vector2 position = transform.localPosition;

        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (x == 0 && y == 0)
        {
            return;
        }

        Vector2 direction = new Vector2(x, y).normalized * (this.isSlow ? 0.3f : 1.0f);

        position += direction * this.speed * Time.deltaTime;
        position = this.availableArea.RestrictPositionOf(this, position);

        transform.localPosition = position;
    }

    private void ManagePlayerAnimation()
    {
        if (this.isInCharacterSelectScene)
        {
            this.freezeAnimation();

            foreach (Option option in this.options)
            {
                option.freezeAnimation();
            }
        }
        else
        {
            this.unfreezeAnimation();

            foreach (Option option in this.options)
            {
                option.unfreezeAnimation();
            }
        }
    }

    public void Update()
    {
        this.ManagePlayerAnimation();


        if (!this.isInCharacterSelectScene)
        {
            this.isSlow = Input.GetKey(KeyCode.LeftShift);
            this.isShooting = Input.GetKey(KeyCode.Z);

            this.ability.Perform();
            this.Shoot();
            this.Move();
        }

    }
}
