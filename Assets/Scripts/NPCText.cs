using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : Collidable
{
    public string message;
    private float cooldown = 6.0f;
    private float last;

    protected override void Start()
    {
        base.Start();
        last = -cooldown;
    }
    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - last > cooldown)
        {
            last = Time.time;
            GameManager.instance.ShowText(message, 20, Color.white, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, 3.0f);
        }
    }
}
