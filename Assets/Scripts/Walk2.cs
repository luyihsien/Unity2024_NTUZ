using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Walk2 : MonoBehaviour
{
    private bool facingRight=false;
    public Transform target;
    public float speed=1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float step=speed*Time.deltaTime;
        transform.position=Vector3.MoveTowards(transform.position,target.position,step);
        if (target.position.x-transform.position.x<0 && facingRight){
            Flip();
        }
        else if (target.position.x-transform.position.x>0 && !facingRight){
            Flip();
        }
    }
    
    void Flip(){
        facingRight=!facingRight;
        Vector3 theScale=transform.localScale;
        theScale.x*=-1;
        transform.localScale=theScale;
    }
}
