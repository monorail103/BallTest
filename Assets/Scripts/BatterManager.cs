using UnityEngine;
using UnityEngine.InputSystem; // 👈 これを追加

public class BatterManager : MonoBehaviour
{
    public Animator animator;

    void Update()
    {
        // スペースキーが押されたらスイング
        // if (Input.GetKeyDown(KeyCode.Space)) // 👈 古いコード
        if (Keyboard.current != null && Keyboard.current.spaceKey.wasPressedThisFrame) // 👈 新しいコードに修正
        {
            Swing();
        }
    }

    void Swing()
    {
        if (animator != null)
        {
            animator.SetTrigger("Swing");
        }
        else
        {
            Debug.LogWarning("Animator component not found on " + gameObject.name);
        }
    }
}