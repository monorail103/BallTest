using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random; // コルーチンを使うために必要

public class PitcherManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform throwPoint;
    public float throwInterval = 3.0f;

    public Animator animator;

    void Start()
    {
        // animator = GetComponent<Animator>();
        StartCoroutine(PitchingRoutine());
    }

    IEnumerator PitchingRoutine()
    {
        while (GameManager.instance.isGameActive)
        {
            yield return new WaitForSeconds(throwInterval);
            if (GameManager.instance.isGameActive)
            {
                // ThrowBallをコルーチンとして呼び出すように変更
                StartCoroutine(ThrowBall());
            }
        }
    }

    // voidからIEnumeratorに変更
    IEnumerator ThrowBall()
    {
        // 最初にアニメーショントリガーを発動
        if (animator != null)
        {
            animator.SetTrigger("Throw");
        }

        // アニメーションの投球ポイントに合わせるため1.5秒待機
        yield return new WaitForSeconds(1.2f);

        // 1.5秒後にボールを生成・初期化
        GameObject ball = Instantiate(ballPrefab, throwPoint.position, Quaternion.identity);
        Ball ballScript = ball.GetComponent<Ball>();

        // 球種の決定（ランダム）
        float randomValue = Random.value;
        if (randomValue < 0.6f)
        {
            Debug.Log("FourSeam");
            ballScript.Initialize(150f, 2600f);
        }
        else if (randomValue < 0.8f)
        {
            Debug.Log("Curve");
            ballScript.Initialize(110f, 2200f);
        }
        else
        {
            Debug.Log("Slider");
            ballScript.Initialize(132f, 2200f);
        }
    }
}