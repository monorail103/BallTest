using UnityEngine;

public class Bat : MonoBehaviour
{
    // ボールがこの速度を参照しに来ます
    public Vector3 Velocity { get; private set; }

    private Vector3 lastPosition;
    
    public AudioSource audioSource;

    void Start()
    {
        // 最初のフレームの位置を記録
        lastPosition = transform.position;
    }

    // 物理演算のフレームごとに実行されるFixedUpdateが最適
    void FixedUpdate()
    {
        // 現在位置と前フレームの位置の差から、速度を計算
        // (現在位置 - 前の位置) / 時間 = 速度
        Velocity = (transform.position - lastPosition) / Time.fixedDeltaTime;

        // 次のフレームのために、現在の位置を「前の位置」として更新
        lastPosition = transform.position;
    }
}