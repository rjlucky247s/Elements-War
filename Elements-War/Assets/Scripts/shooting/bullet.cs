using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20;
    public Rigidbody2D rb;
    public GameObject impacteffect;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        
        

        Destroy(Instantiate(impacteffect, transform.position, transform.rotation),0.1f);
        Destroy(gameObject);
      
       
        

    }



}
