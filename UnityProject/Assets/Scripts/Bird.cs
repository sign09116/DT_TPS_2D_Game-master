using UnityEngine;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    #region 屬性
    /// <summary>
    /// 玩家跳躍的力道
    /// </summary>
    [Header("跳躍高度"), Range(1, 20)]
    public int _jump = 1;
    /// <summary>
    /// 玩家是否死亡
    /// </summary>
    [Header("是否死亡"), Tooltip("用來判斷角色是否死亡，true 死亡，false 還沒死亡")]
    public bool dead;
    [Header("旋轉角度"), Range(0, 30)]
    public float angle = 10;
    [Header("分數物件")]
    public GameObject GoScore;
    [ Header("管理器物件")]
    public GameObject GM;
   /// <summary>
   /// 玩家的鋼體
   /// </summary>
    public Rigidbody2D BirdRig;
    /// <summary>
    /// 遊戲管理器物件腳本
    /// </summary>
    [Header("GM腳本")]
    public GameManager _GM;
    string _Score = "_Score";
    [Header("音效")]
    //AudioSource存放喇叭元件
    //AudioClip存放音效檔
    public AudioSource _Audio;
    public AudioClip JumpSound, AddScoreSound, HurtSound;
    #endregion

    private void Awake()
    {
        BirdRig = GetComponent<Rigidbody2D>();
       // GoScore = Resources.Load("分數") as GameObject;
        //GM = Resources.Load("遊戲管理器") as GameObject;
        
    }
    private void Start()
    {
       
    }
    private void Update()
    {
        gameObject.transform.position = new Vector2(0, Mathf.Clamp(gameObject.transform.position.y, -3.7f, 4.5f)); 
    }
    private void FixedUpdate()
    {
        Jump();
    }
    /// <summary>
    /// 小雞跳躍方法
    /// </summary>
    private void Jump()
    {//輸入.按下(按件列舉.滑鼠左鍵)(手機觸控)
        //建議使用鋼體時設定在FixedUpdate()
        //如果玩家死亡直接跳出函式
        if (dead) return;//簡寫 如果只有一行敘述可省略大括弧
        //if (dead)
        //{
        //    return;
        //}
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            _Audio.PlayOneShot(JumpSound,3f);
            GoScore.SetActive(true);
            GM.SetActive(true);
            BirdRig.Sleep();
            BirdRig.gravityScale = 1;
            BirdRig.AddForce(Vector2.up * _jump, ForceMode2D.Impulse);       
            print("玩家按下左鍵");
        }
        print(BirdRig.velocity);
        //BirdRig.SetRotation(float)設定角度
        //BirdRig.velocity 加速度(二維向量x,y)
        BirdRig.SetRotation(angle * BirdRig.velocity.y);
       
    }


    /// <summary>
    /// 小雞死亡方法。
    /// </summary>
    private void Dead()
    {
        print("死掉了");
        dead = true;
        _GM.GameOver();
        //遊戲時間暫停
        //Time.timeScale = 0;
    }
    private void OnCollisionEnter2D(Collision2D Hit)
    {//碰到物件.遊戲物件.名稱或標籤
        print(Hit.gameObject.name);
        if (Hit.gameObject.name == "地板")
        {
            _Audio.PlayOneShot(HurtSound, 3f);
            Dead();  
        }
       
    }

    private void OnTriggerEnter2D(Collider2D Hit)
    {
        if (Hit.gameObject.tag == "Pipe") 
        {
            _Audio.PlayOneShot(HurtSound, 3f);
            Dead();
        }
       
       
    }
    private void OnTriggerExit2D(Collider2D Hit)
    {
        if (Hit.gameObject.tag == "AddScoreZone")
        {
            _Audio.PlayOneShot(AddScoreSound, 3f);
            _GM.AddScore();
            _GM.scoreText.text = PlayerPrefs.GetInt(_Score).ToString();

        }
    }

}
