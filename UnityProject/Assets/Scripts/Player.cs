
using UnityEngine;

public class Player : MonoBehaviour
{
    #region  屬性
    [Header("跳躍力道"), Range(5, 10)]
    public float JumpForce = 5;
    [Header("是否死亡"), Tooltip("是否死亡視為true，否為false")]
    public bool isDead;
    public GameObject _Player;
    [Header("玩家移動速度"), Range(10, 100)]
    public float PlayerSpeed = 1;

    #endregion

    #region  事件
    private void Start()
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
    }
    private void Update()
    {
        PlayerMove();
        if (Input.GetMouseButtonDown(0))
        {
            PlayerJump();
            WaitForSeconds wait = new WaitForSeconds(1);
            PlayerReSet();
        }


    }

    #endregion

    #region  方法
    /// <summary>
    /// 玩家移動方法
    /// </summary>
    void PlayerMove()
    {
        _Player.transform.Translate(Vector3.right * PlayerSpeed * Time.deltaTime, Space.World);
    }
    /// <summary>
    /// 玩家跳躍方法
    /// </summary>
    void PlayerJump()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1;
        GetComponent<Rigidbody2D>().AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        // _Player.transform.Rotate(0, 0, 45, Space.World);

    }
    /// <summary>
    /// 玩家重製方法
    /// </summary>
    void PlayerReSet()
    {
        //_Player.transform.Rotate(0, 0, -45, Space.World);
    }
    #endregion
    /// <summary>
    /// 玩家死亡方法
    /// </summary>
    void PlayerDead()
    {
        isDead = true;

    }
    /// <summary>
    /// 當玩家進入加分區域時呼叫GM的加分方法
    /// </summary>
    /// <param name="Touch"></param>
    private void OnTriggerEnter2D(Collider2D Touch)
    {
        if (Touch.GetComponent<Collider2D>().tag == "AddScore")
        {
            GameObject.FindWithTag("GM").GetComponent<GameManager>().AddScore();
        }
    }

}
