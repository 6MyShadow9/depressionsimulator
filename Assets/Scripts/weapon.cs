using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : Collidable
{
    // Damage struct
    public int damagePoint = 5;
    public float pushForce = 2.0f;

    // Upgrade
    public int weaponLevel = 0;
    private SpriteRenderer spriteRenderer;

    //swing
    private Animator anim;
    private float cooldown = 0.5f;
    private float lastSwing;

    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    protected override void Update()
    {
        base.Update();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(Time.time - lastSwing > cooldown)
            {
                lastSwing = Time.time;
                Swing();
                //Debug.Log("hit a fighter");
            }
        }
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (coll.tag == "Fighter")
        {
            if (coll.name == "Player")
            {
                return;
            }
            //create a new damage object, then we'll send it to the fighter we've hit
            damage dmg = new damage
            {
                damageAmount = damagePoint,
                origin = transform.position,
                pushForce = pushForce
            };

            coll.SendMessage("RecieveDamage", dmg);
        }
    }
    private void Swing()
    {
        anim.SetTrigger("Swing");

    }
}
