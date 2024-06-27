using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Walk : MonoBehaviour
{
    public float speed=1.0f;
    private bool facingRight=true;
    public float jumpforce=5f;
    Animator myAnim;
    Rigidbody2D myRigi;
    bool isJumPressed,canJump;
    public HealthManager healthManager;
    public int damage=1;
    void Start() {
        myAnim=GetComponent<Animator>();
        myRigi=GetComponent<Rigidbody2D>();
        isJumPressed=false;
        canJump=true;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump==true){
            isJumPressed=true;
            canJump=false;
        }
    }
    void FixedUpdate() {
        float moveHorizontal=Input.GetAxisRaw("Horizontal");
        myAnim.SetFloat("Run",Mathf.Abs(moveHorizontal));
        Vector3 movement=new Vector3(moveHorizontal,0.0f,0.0f);
        transform.position=transform.position+movement*speed*Time.deltaTime;
        if (moveHorizontal>0 && !facingRight)
        Flip();
        else if (moveHorizontal<0 && facingRight)
        Flip();
        if (isJumPressed){
            myRigi.AddForce(Vector2.up*jumpforce,ForceMode2D.Impulse);
            isJumPressed=false;
        }
        myRigi.velocity=new Vector2(moveHorizontal*speed,myRigi.velocity.y);
    }
    void Flip(){
        facingRight=!facingRight;
        Vector3 theScale=transform.localScale;
        theScale.x*=-1;
        transform.localScale=theScale;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.collider.name=="Square"){
            canJump=true;
        }
        if (collision.gameObject.CompareTag("Enemy")){
            healthManager.ChangeHealth(damage);
        }

    }
}
