using UnityEngine;

public class LearnOperator : MonoBehaviour
{
    public int a = 10, b = 3, c = 10, d = 10;
    public int score = 50;
    public int num1 = 90, num2 = 10;

    public bool boolA = true, boolB = false;
    public int hp = 100, prop = 10;

    private void Start()
    {
        #region 數學運算子區域
        // 數學運算子
        print(a + b);   // 加 13
        print(a - b);   // 減 7
        print(a * b);   // 乘 30
        print(a / b);   // 除 3
        print(a % b);   // 餘 10 / 3 = 3...1

        // 遞增 ++、遞減 --
        print(c++);     // 先輸出再執行遞增
        print(++d);     // 先執行遞增再輸出

        // 指定運算：等號右邊會先運算再傳給左邊
        // = 指定
        // 適用所有數學運算
        score = score + 10;
        score += 10;
        #endregion

        #region 比較運算子
        // 比較運算子 (結果為布林值)
        print(num1 > num2);
        print(num1 < num2);
        print(num1 >= num2);
        print(num1 <= num2);
        print(num1 == num2);    // 等於
        print(num1 != num2);    // 不等
        #endregion

        // 邏輯運算子
        // 並且 &&
        print(boolA && boolB);  // 只要有一個 false 結果為 false
        print(true && true);    // t
        print(true && false);   // f
        print(false && true);   // f
        print(false && false);  // f
        // 或者 ||
        print(boolA || boolB);  // 只要有一個 true 結果為 true
        print(true || true);    // t
        print(true || false);   // t
        print(false || true);   // t
        print(false || false);  // f

        // 過關條件：HP > 50 並且 道具 > 7
        print(hp > 50 && prop > 7);

        // 相反
        print(!true);       // f
        print(!false);      // t
    }
}
