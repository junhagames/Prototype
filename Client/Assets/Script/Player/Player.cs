using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    Vector3 movement;
    bool isJumping = false;

    // 컴포넌트 참조 변수들
    Rigidbody2D rigid;
    Animator animator;
    SpriteRenderer renderer;

    void Awake() {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
        renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void Update() {
        if (Input.GetButtonDown("Jump")) {
            isJumping = true;
        }
    }

    void FixedUpdate() {
        move();
        jump();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("충돌: " + other.gameObject.layer);
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("해제: " + other.gameObject.layer);
    }

    // 사용자 지정 메서드
    void move() {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") < 0) {
            moveVelocity = Vector3.left;
            renderer.flipX = true;
            animator.SetBool("move", true);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0) {
            moveVelocity = Vector3.right;
            renderer.flipX = false;
            animator.SetBool("move", true);
        }
        else {
            animator.SetBool("move", false);
        }
        transform.position += moveVelocity * moveSpeed * Time.deltaTime;
    }

    void jump() {
        if (!isJumping) {
            return;
        }

        rigid.velocity = Vector2.zero;

        Vector2 jumpVelocity = new Vector2(0, jumpForce);
        rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);

        isJumping = false;
    }
}
