
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class EnemyMove : MonoBehaviour
{
    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriteRenderer;
    public int nextMove;// ൿ  ǥ              
    public float 몬스터이동속도;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();


        Invoke("Think", 2);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //          θ   ˾Ƽ       ̰ 
        rigid.velocity = new Vector2(nextMove * 몬스터이동속도, rigid.velocity.y);//            ϱ  -1, y     0          ū ϳ !


        // ÷    üũ 
        //   ʹ       üũ ؾ  
        Vector2 frontVec = new Vector2(rigid.position.x + nextMove * 몬스터이동속도 * 0.2f, rigid.position.y);
        Debug.DrawRay(frontVec, Vector3.down, new Color(0, 1, 0));
        //     ,         

        RaycastHit2D rayHit = Physics2D.Raycast(frontVec, Vector3.down, 1, LayerMask.GetMask("땅"));


        if (rayHit.collider == null)
        {

            Turn();

        }
    }
    // ൿ  ǥ    ٲ     Լ       -->     Ŭ     Ȱ   

    void Think()
    {

        //set next active
        nextMove = Random.Range(-1, 2); //-1 ̸      , 0 ̸     ߱ ,1 ̸             ̵ 

        //sprite animation
        //anim.SetInteger("WalkSpeed", nextMove);

        //      ٲٱ  (0              ٲ   ʿ   ⿡    ǹ        ذ )
        if (nextMove != 0)
        {
            spriteRenderer.flipX = (nextMove == 1); //nextMove   1 ̸      ٲٱ 
        }

        //    
        float nextThinkTime = Random.Range(2f, 5f);//     ϴ   ð             

        Invoke("Think", nextThinkTime);//   




    }

    void Turn()
    {
        nextMove = nextMove * (-1);
        spriteRenderer.flipX = (nextMove == 1); //nextMove   1 ̸      ٲٱ 


        CancelInvoke();
        Invoke("Think", 2);
    }
}
