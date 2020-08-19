using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    [SerializeField] float moveSpeed = 8f;
    [SerializeField] float destroyPosition = -12f;
    [SerializeField] protected int points;
    Rigidbody2D rb;
    protected Player player;
   
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>(); 
        player = FindObjectOfType<Player>();
    }

    protected virtual void Update()
    {
        DestroyGameObject();
    }

    protected void DestroyGameObject()
    {
        if(gameObject.transform.position.y < destroyPosition)
          {
              Destroy(gameObject);
          }
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = Vector2.down * moveSpeed; 
    }
}

