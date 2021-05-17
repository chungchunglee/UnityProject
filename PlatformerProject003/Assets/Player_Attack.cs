using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Attack : MonoBehaviour
{
    Camera camera;
    Vector2 mousePosition;
    public int maxHp;
    public int nowHp;
    public static int atkDmg;
    public float atkSpeed = 1;
    public bool atked = false;
    public Image nowHpbar;
    public GameObject atkPrf;
    new Rigidbody2D rigidbody2D;
    
    void AttackTrue()
    {
        atked = true;
    }
    void AttackFalse()
    {
        atked = false;
    }
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            
            nowHp-= collision.gameObject.GetComponent<Enemy>().atkDmg;
            Debug.Log("Enemy Hit" + nowHp+" &&"+ collision.gameObject.GetComponent<Enemy>().atkDmg);
            rigidbody2D.AddForce(new Vector2(20, 20), ForceMode2D.Impulse);
            Debug.Log("addForce");

            if (nowHp == 0)
            {
                Destroy(gameObject);
            }
        }
    }
    

    private void Start()
    {
        maxHp = 50;
        nowHp = 50;
        atkDmg = 10;
        atkSpeed = 1.0f;
        //카메라 값 get
        camera = GameObject.Find("Camera").GetComponent<Camera>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;

        float attack_distance;

        if (Input.GetMouseButtonDown(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = camera.ScreenToWorldPoint(mousePosition);
            attack_distance = Vector2.Distance(mousePosition, transform.position);
         
            if(attack_distance < 6.0)
            {
                GameObject atk = Instantiate(atkPrf);
                atk.transform.position = mousePosition;
            }




            Debug.Log("no hit");
            /* 디버그 로그 - 거리
            Debug.Log("this is mouse position" + mousePosition);
            Debug.Log("this is player position" + transform.position);
            Debug.Log("this is distance" + attack_distance);
            */
            //if // 공격거리 < 공격 가능 거리 && 몬스터 공격 가능 범위 


        }


    }

}
