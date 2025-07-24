using UnityEngine;

public class BatterManager : MonoBehaviour
{
    void Update()
    {
        // スペースキーが押されたらスイング
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Swing();
        }
    }

    void Swing()
    {
        Animator animator = GetComponent<Animator>();
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