using UnityEngine;

public class LearnField : MonoBehaviour
{
    // 定義欄位 Field
    // 語法：修飾詞 欄位類型 欄位名稱 (指定 值) 結束

    // 私人：隱藏 private (預設)
    // 公開：顯示 public

    // 整數 int       - 0, 1, 999, -100       - 預設 0
    // 浮點數 float   - -1.5, -999.9, 100.5   - 預設 0
    // 字串 string    - 紅色藥水、鞋子         - 預設 ""
    // 布林值 bool    - true、false           - 預設 false

    [Header("角色等級"), Range(1, 9999)]
    public int lv = 999;
    [Tooltip("角色的移動速度，不要調太高，角色會飛走。")]
    [Range(0.1f, 99.9f)]
    public float speed = 1.5f;
    public string prop1 = "紅色藥水";
    public bool mission = true;
}
