using UnityEngine;

public class PitcherManager : MonoBehaviour
{
    Animator animator;
    void Start()
    {
        // Animatorコンポーネントを取得
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        // スペースキーが押されたらボールを投げる
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {

        // ボールを投げる処理をここに記述
        Debug.Log("ボールを投げました！");
    }
}