using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
  public Animator animator;

  public float speed;
  public float jumpforce;
  private float moveInput;

  private BoxCollider2D boxCollider2d;

  private Rigidbody2D rb;

  private bool facingRight = true;

  public LayerMask groundLayer; // Insert the layer here.

  AudioSource audioSrc;
  bool isMoving = false;


  void Start()
  {

    rb = GetComponent<Rigidbody2D>();
    boxCollider2d = transform.GetComponent<BoxCollider2D>();
    audioSrc = GetComponent<AudioSource> ();
  }

  void FixedUpdate()
  {



    moveInput = Input.GetAxisRaw("Horizontal");
    rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

    animator.SetFloat("Speed", Mathf.Abs(moveInput));

    if (facingRight == false && moveInput > 0)
    {
      Flip();
    }
    else if (facingRight == true && moveInput < 0)
    {
      Flip();
    }



  }



  public void Update()
  {

    if (IsGrounded() && Input.GetKeyDown("space"))
    {
      rb.velocity = Vector2.up * jumpforce;
      animator.SetTrigger("Jump");
    }
    if (rb.velocity.x >= 1 || rb.velocity.x <= -1)
      isMoving = true;
    else
      isMoving = false;

    if (isMoving) {
      if (!audioSrc.isPlaying)
      audioSrc.Play ();
    }
    else
      audioSrc.Stop ();

  }

  private bool IsGrounded()
  {
    float extraHeight = 1f;

    RaycastHit2D rayCast = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down, extraHeight, groundLayer);


    return rayCast.collider != null;
  }


  void Flip()
  {
    facingRight = !facingRight;
    Vector3 Scaler = transform.localScale;
    Scaler.x *= -1;
    transform.localScale = Scaler;

  }

}