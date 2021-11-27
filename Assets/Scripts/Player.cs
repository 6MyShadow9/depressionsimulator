using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player : mover
{
    public SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    public bool buzisbool = true;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();

        DontDestroyOnLoad(gameObject);
    }

    protected override void RecieveDamage(damage dmg)
    {
        if(!isAlive)
            return;
        
        base.RecieveDamage(dmg);
        GameManager.instance.OnHitPointChange();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");  
        
        if(isAlive)
            UpdateMotor(new Vector3(x,y,0));


    }

    public void getSprite()
    {

    }
    public void SwapSprite(int skinID)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinID];
    }

    public void OnLevelUp()
    {
        maxHitpoint++;
        hitpoint = maxHitpoint;
    }

    // set the level on load
    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
            OnLevelUp();
    }

    public void Heal(int healingAmount)
    {
        if(hitpoint == maxHitpoint)
            return;
        hitpoint += healingAmount;

        if(hitpoint > maxHitpoint)
            hitpoint = maxHitpoint;
        GameManager.instance.ShowText("+" + healingAmount.ToString() + "hp", 25, Color.green, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitPointChange();
    }

    // death
    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.DeathMenuAnim.SetTrigger("Show");

    }

    // respawn
    public void Respawn()
    {
        Heal(maxHitpoint);
        isAlive = true;
        buzisbool = false;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
