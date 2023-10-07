using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 7f;

    public float Horizontal;
    public float Vertical;
    Animator animator;
    bool facing;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
        animator.SetFloat("Speed",Mathf.Abs(Horizontal!=0? Horizontal: Vertical));
    }
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(Horizontal*Speed, Vertical*Speed, 0.0f);
        transform.position = transform.position + movement*Time.deltaTime;
        Flip(Horizontal);
    }
    private void Flip(float Horizontal)
    {
        if (Horizontal<0 && !facing || Horizontal >0 && facing)
        {
            facing = !facing;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale=scale;

        }
    }

}
