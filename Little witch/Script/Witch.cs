using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Witch : MonoBehaviour
{

  public float speed;

  public float stoppingDistanceFromHero;
  public Transform target;


  private Rigidbody2D rb;
  public Animator anim;
  // Start is called before the first frame update
  void Start()
  {
    rb = GetComponent<Rigidbody2D>();
    anim = GetComponent<Animator>();
    target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
  }

  // Update is called once per frame
  void Update()
  {


    if (transform.position.x < target.transform.position.x)
    {
      if (Vector2.Distance(transform.position, target.position) > stoppingDistanceFromHero)
      {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        anim.SetBool("Attack", false);
        transform.localScale = new Vector2(4, 4);
      }
      else
      {
        anim.SetBool("Attack", true);
      }

    }

    else
    {


      if (Vector2.Distance(transform.position, target.position) > stoppingDistanceFromHero)
      {
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        anim.SetBool("Attack", false);
        transform.localScale = new Vector2(-4, 4);
      }
      else
      {
        anim.SetBool("Attack", true);
      }



    }




  }


}
