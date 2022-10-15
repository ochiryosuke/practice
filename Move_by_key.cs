using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_by_key : MonoBehaviour
{
    private Rigidbody2D rb;
    const float power = 5.0f;

    //位置取得用
    private Vector2 pos;
    private Vector2 dpos;

    //範囲制限用定数
    private const float max_x = 3.5f;
    private const float min_x = -3.5f;
    private const float max_y = -1.0f;
    private const float min_y = -5.0f;

    Dictionary<string,bool> state = new Dictionary<string, bool>()
    {
        {"up",false},
        {"down",false},
        {"left",false},
        {"right",false}

    };
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dpos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            state["up"] = true;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            state["down"] = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            state["left"] = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            state["right"] = true;
        }
        else if (Time.timeScale == 0f)
        {
            rb.velocity = Vector2.zero;//速度をなくす

            transform.position = dpos;//初期位置代入
        }
    }

    private void FixedUpdate()
    {

        if (state["up"])
        {
            rb.AddForce((Vector2.up * power - rb.velocity), ForceMode2D.Force);
            state["up"] = false;
        }
        if (state["down"])
        {
            rb.AddForce((Vector2.down * power - rb.velocity), ForceMode2D.Force);
            state["down"] = false;
        }
        if (state["left"])
        {
            rb.AddForce((- Vector2.right * power - rb.velocity),ForceMode2D.Force);
            state["left"] = false;
        }
        if (state["right"])
        {
            rb.AddForce((Vector2.right * power - rb.velocity), ForceMode2D.Force);
            state["right"] = false;
        }

        this.MoveRanges();
    }

    private void MoveRanges()
    {
        
        //現在の位置取得
        this.pos = transform.position;

        //制限した値に収める
        this.pos.x = Mathf.Clamp(this.pos.x,min_x, max_x);
        this.pos.y = Mathf.Clamp(this.pos.y,min_y, max_y);

        //代入し直す
        transform.position = new Vector2(this.pos.x,this.pos.y);
    }
}
