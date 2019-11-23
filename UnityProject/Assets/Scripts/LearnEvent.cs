using UnityEngine;

public class LearnEvent : MonoBehaviour
{
    public int count = 0;

    // 開始事件
    private void Start()
    {
        // 使用 API 方法：方法名稱();
        print("哈囉，沃德~");
        print(count);
    }

    // 更新事件
    private void Update()
    {
        print("嗨~");
    }
}
