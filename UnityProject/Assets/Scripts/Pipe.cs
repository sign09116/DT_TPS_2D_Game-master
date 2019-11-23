// 繼承：可以享有繼承類別的成員
public class Pipe : Ground
{
    private void Start()
    {
        // gmaeObject 指的是此類別的遊戲物件
        // 刪除(物件，延遲時間)
        //

    }
    //在攝影機畫面外執行一次
    //掛此類別物件須有Mesh Renderer
    private void OnBecameInvisible()
    {
        Destroy(gameObject, 2f);
    }
    //在攝影機畫面內執行一次
    //private void OnBecameVisible()
    //{}
}
