using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playercontrol : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rbody;
    public GameObject winpng;
    private SpriteRenderer png;
    void Start()
    {
        animator = GetComponent<Animator>();
        rbody = GetComponent<Rigidbody2D>();
        png = winpng.GetComponent<SpriteRenderer>();
    }


    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if (horizontal != 0)
        {
            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", 0);
        }
        if (vertical != 0)
        {
            animator.SetFloat("Vertical", vertical);
            animator.SetFloat("Horizontal", 0);
        }
        Vector2 dir = new Vector2(horizontal, vertical);
        animator.SetFloat("speed", dir.magnitude);
        rbody.velocity = dir * 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Door")
        {
            Debug.Log("you win!");
            int sortingLayerID = SortingLayer.NameToID("png");
            transform.position = new Vector3(0.013f, 0.87f, 0);
            png.sortingLayerID = sortingLayerID;
            Time.timeScale = 0;
        }
    }
}
