using UnityEngine;
using System.Collections;

public class CubeController : MonoBehaviour
{

    // キューブの移動速度
    private float speed = -12;

    // 消滅位置
    private float deadLine = -10;

    // 効果音
    private AudioSource myAudio;

    // Use this for initialization
    void Start()
    {
        //AudioSourceコンポーネントを取得
        this.myAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // キューブを移動させる
        transform.Translate(this.speed * Time.deltaTime, 0, 0);

        // 画面外に出たら破棄する
        if (transform.position.x < this.deadLine)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        //地面とブロックが接触
        if (collision.gameObject.tag == "CubeBlock" ||
            collision.gameObject.tag == "Ground")
        {

            //音を鳴らす
            myAudio.Play();

        }

    }

}