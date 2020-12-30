using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float MoveSpeed = 1;
    public float JumpForce = 3;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var movement = Input.GetAxis("Horizontal");
        transform.position += new Vector3(movement, 0, 0) * Time.deltaTime * MoveSpeed;
        if(Input.GetButtonDown("Jump")&& Mathf.Abs(rb.velocity.y)<0.001f)
        {
            rb.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
        }
        Vector3 CharScale = transform.localScale;
        if(Input.GetAxis("Horizontal")<0)
        {
            CharScale.x = -1;
        }
        if(Input.GetAxis("Horizontal")>0)
        {
            CharScale.x = 1;
        }
        transform.localScale = CharScale;
    }
}
