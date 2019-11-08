using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public float closedistance = 5f;
    public float speed = 4f;
    Rigidbody2D rb;
    public Animator animator;

    public float health = 100f;
   
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector3.Distance(player.transform.position, transform.position);
        Vector3 dist = player.transform.position - transform.position;


        if (Distance < closedistance)
        {
            rb.velocity = dist * 1f;
            animator.SetBool("walk", true);
            if (rb.velocity.x >= 0.01f)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (rb.velocity.x <= -0.01f)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        if (Distance > closedistance)
        {
            rb.velocity = dist * 0f;
            animator.SetBool("walk", false);
        }

    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {

        if (hitinfo.gameObject.CompareTag("bullet")) {
            health -= 25f;
            if (health <= 0)
            {

                animator.SetBool("death", true);
                Destroy(gameObject,0.45f);
            }
        }
       

    }
}
