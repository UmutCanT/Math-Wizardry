using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] SpriteRenderer sRenderer;

    float movementSpeed = 5f;
    Vector3 targetPosition;   

    // Start is called before the first frame update
    void Start()
    {
        Health.OnHealthDepleted += StopMovement;
        targetPosition = transform.position;       
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        MouseMovement();
#else
        TouchMovement();
#endif
    }

    void FixedUpdate()
    {
        StartCoroutine(MoveToTargetPos(targetPosition));
    }

    void MouseMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("isMoving", true);
            targetPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
            DirectionChanger();
        }
    }

    void TouchMovement()
    {
        Touch touch;
        if(Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            animator.SetBool("isMoving", true);
            targetPosition.x = Camera.main.ScreenToWorldPoint(touch.position).x;
            DirectionChanger();
        }
    }

    IEnumerator MoveToTargetPos(Vector3 targetPosition)
    {
        if (targetPosition != transform.position)
        {
            // Move Towards or Lerp? Decide when I use with sprite
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isMoving", false);
            yield return null;
        }
    }

    void DirectionChanger()
    {
        if (targetPosition.x < transform.position.x)
        {
            sRenderer.flipX = true;                     
        }
        else if (targetPosition.x >= transform.position.x)
        {
            sRenderer.flipX = false;
        }
    }

    void StopMovement()
    {
        animator.SetTrigger("gameOver");
        enabled = false;
    }

    void OnDisable()
    {
        Health.OnHealthDepleted -= StopMovement;
    }
}
