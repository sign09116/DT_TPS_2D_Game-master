using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("目前分數")]
    public int score;
    [Header("分數文字物件")]
    public Text scoreText;
    string _Score = "_Score";
    [Header("最高分數")]
    public int scoreHeight;
    [Header("水管")]
    // GameObject 可以存放場景上的遊戲物件與專案內的預製物
    public GameObject pipe;
    [Header("遊戲結算畫面")]
    public GameObject _GameOver;
    //static 靜態屬性可以直接調用(但不顯示於面板)
    public static bool isGameOver;
    

    // 修飾詞權限：
    // private 其他類別無法使用
    // public 其他類別可以使用

    /// <summary>
    /// 加分。
    /// </summary>
    public void AddScore()
    {
        print("加分");
        PlayerPrefs.SetInt(_Score, score);
        score++;
       // score +=Random.Range(1,5);
        PlayerPrefs.SetInt(_Score, score);
        
        
    }
    
    /// <summary>
    /// 最高分數判定。
    /// </summary>
    private void HeightScore()
    {
        _GameOver.transform.GetChild(0).GetChild(1).GetComponent<Text>().text= PlayerPrefs.GetInt(_Score, score).ToString();
    }

    /// <summary>
    /// 生成水管。
    /// </summary>
    private void SpawnPipe()
    {
        print("生水管~");
        // 生成(物件);
        //Instantiate(pipe);

        // 生成(物件，坐標，角度)
        float y = Random.Range(-1f, 1.2f);
        // 區域欄位(不需要修飾詞)
        Vector3 pos = new Vector3(10, y, 0);

        // Quaternion.identity 代表零角度
        Instantiate(pipe, pos, Quaternion.identity);
    }

    /// <summary>
    /// 遊戲失敗。
    /// </summary>
    public void GameOver()
    {
        HeightScore();
        _GameOver.SetActive(true);//顯示遊戲結算畫面
        isGameOver = true;//是否遊戲結算
        //停止呼叫Invoke的函式
        CancelInvoke("SpawnPipe");

       // Time.timeScale = 0;
    }
    public void ReGame() 
    {
        isGameOver = false;
        Application.LoadLevel("遊戲場景");
    }
    public void ExitGame() 
    {
        Application.Quit();
    }
    private void Awake()
    {
        PlayerPrefs.DeleteKey(_Score);
    }
    private void Start()
    {
        // 重複調用("方法名稱"，開始時間，間隔時間)
        
        InvokeRepeating("SpawnPipe", 0, 1.5f);
        
    }

}
