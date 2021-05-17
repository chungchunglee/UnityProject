using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject prfHpBar;
    public GameObject canvas;
    public string enemyName;
    public int maxHp;
    public int nowHp;
    public int atkDmg;
    Image nowHpbar;
    new Rigidbody2D rigidbody2D;


    private void SetEnemyStatus(string _enemyName, int _maxHp, int _atkDmg)
    {
        enemyName = _enemyName;
        maxHp = _maxHp;
        atkDmg = _atkDmg;
        nowHp = maxHp;
    }
    /*
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player_Coin")
        {

            nowHp = nowHp - player.atkDmg;
            Destroy(collision.gameObject);
            Debug.Log("coin Hit"+nowHp);
        }
    }
    */
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player_Coin")
        {

            nowHp = nowHp - Player_Attack.atkDmg;
            Debug.Log("Coin Hit" + nowHp + " &&" + Player_Attack.atkDmg);
            Destroy(collision.gameObject);
            Debug.Log("coin Hit" + nowHp);
            rigidbody2D.AddForce(new Vector2(10, 10), ForceMode2D.Impulse);


        }
    }


    RectTransform hpBar;

    public float height = 0.4f;

    // Start is called before the first frame update
    void Awake()
    {
        hpBar = Instantiate(prfHpBar, canvas.transform).GetComponent<RectTransform>();
        hpBar.transform.localScale = new Vector3(0.2f, 0.2f, 0);
        SetEnemyStatus("StartEnemy1", 30, 10);
        nowHpbar = hpBar.transform.GetChild(0).GetComponent<Image>();
        rigidbody2D = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        Vector3 _hpbarPos = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x, transform.position.y + height, 0));
        hpBar.position = _hpbarPos;
        nowHpbar.fillAmount = (float)nowHp / (float)maxHp;
        if (nowHp == 0)
        {
            Destroy(gameObject);
            Destroy(prfHpBar);
        }


    }
}
