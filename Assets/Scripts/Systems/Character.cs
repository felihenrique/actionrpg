using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D), typeof(SpriteRenderer))]
[RequireComponent(typeof(Animator))]
public class Character : MonoBehaviour {
    [SerializeField]
    private float speed = 0.5f;
    private Animator animator;
    private new Rigidbody2D rigidbody2D;

    public delegate void SpeedChangeDel();
    public event SpeedChangeDel SpeedChanged;

    public float Speed { 
        get { return speed; } 
        set {
            float percent = ((value - speed) / speed) + 1;
            animator.speed *= percent;
            SpeedChanged?.Invoke ();
            speed = value;
        }
    }

    void Start()
    {
        animator = GetComponent<Animator> ();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate () {
        bool moving = rigidbody2D.velocity.magnitude > 0.01f;
        if (moving) {
            animator.SetFloat ("speed_x", rigidbody2D.velocity.x);
            animator.SetFloat ("speed_y", rigidbody2D.velocity.y);
        }
        animator.SetBool ("moving", moving);
    }
}
