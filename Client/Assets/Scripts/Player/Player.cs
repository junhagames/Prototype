using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 8f;
    public float jumpForce = 800f;
    public int jumpCount = 2;

    [Space(10)]
    [Header("Checkers")]
    public LayerMask whatIsGround;
    public Transform groundCheck1;
    public Transform groundCheck2;

    //컴포넌트 참조 변수들
    Rigidbody2D rigid;
    BoxCollider2D boxCol;
    Animator anim;

    //내부 속성변수들
    float xMove;
    float yMove;
    bool facingRight = true;
    int currentJumpCount = 0;
    bool isGround;
    bool groundHit;
    bool jumpKeyDown = false;

    void Awake() {
        rigid = GetComponent<Rigidbody2D>();
        boxCol = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate() {
        rigid.velocity = new Vector2(xMove * moveSpeed, rigid.velocity.y);

        bool groundHit = Physics2D.OverlapArea(groundCheck1.position, groundCheck2.position, whatIsGround);
        if (groundHit && rigid.velocity.y <= 0) {
            if (!isGround) {
                currentJumpCount = jumpCount;
                isGround = true;
            }
            else if (groundHit) {
                isGround = true;
            }
            else {
                isGround = false;
            }
        }

        if (jumpKeyDown) {
            if (isGround || currentJumpCount > 0) {
                rigid.velocity = new Vector2(rigid.velocity.x, 0);
                rigid.AddForce(new Vector2(0, jumpForce));
                jumpKeyDown = false;
                currentJumpCount--;
            }
            else {
                jumpKeyDown = false;
            }
        }
    }

    void Update() {
        xMove = Input.GetAxis("Horizontal");
        yMove = Input.GetAxis("Vertical");

        if (xMove > 0 && !facingRight || xMove < 0 && facingRight) {
            Flip();
        }

        if (Input.GetButtonDown("Jump")) {
            jumpKeyDown = true;
        }

        UpdateAnimator();
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    void UpdateAnimator() {
        anim.SetFloat("xSpeed", Mathf.Abs(xMove));
        anim.SetFloat("ySpeed", rigid.velocity.y);
        anim.SetBool("ground", isGround);
    }
}
