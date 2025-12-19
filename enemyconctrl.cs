using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO.Pipes;

public class enemyconctrl : MonoBehaviour
{
    public GameObject player;
    public GameObject failpng;
    private Rigidbody2D rbody;
    private Transform ptrans;
    private SpriteRenderer png;
    private Vector3 dir, ppos;
    private Animator ani;
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        ptrans = player.GetComponent<Transform>();
        ani = GetComponent<Animator>();
        png = failpng.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        ppos = ptrans.position;
        dir = ppos - transform.position;
        if (Math.Abs(dir.x) > Math.Abs(dir.y))
        {
            if (dir.x < 0)
            {
                ani.SetFloat("horizontal", -1f);
                ani.SetFloat("vertical", 0);
                ani.SetBool("ismove", true);
                Vector2 movedir = new Vector2(-0.3f, 0);
                rbody.velocity = movedir;
            }
            if (dir.x > 0)
            {
                ani.SetFloat("horizontal", 1f);
                ani.SetFloat("vertical", 0);
                ani.SetBool("ismove", true);
                Vector2 movedir = new Vector2(0.3f, 0);
                rbody.velocity = movedir;
            }
        }
        if (Math.Abs(dir.x) < Math.Abs(dir.y))
        {
            if (dir.y < 0)
            {
                ani.SetFloat("horizontal", 0);
                ani.SetFloat("vertical", -1f);
                ani.SetBool("ismove", true);
                Vector2 movedir = new Vector2(0, -0.3f);
                rbody.velocity = movedir;
            }
            if (dir.y > 0)
            {
                ani.SetFloat("horizontal", 0);
                ani.SetFloat("vertical", 1f);
                ani.SetBool("ismove", true);
                Vector2 movedir = new Vector2(0, 0.3f);
                rbody.velocity = movedir;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("you were caught!");
            int sortingLayerID = SortingLayer.NameToID("png");
            ptrans.position = new Vector3(0.013f, 0.87f, 0);
            png.sortingLayerID = sortingLayerID;
            Time.timeScale = 0;
        }

    }


}
