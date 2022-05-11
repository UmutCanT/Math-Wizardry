using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float movementSpeed = 10f;
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
            targetPosition.x = Camera.main.ScreenToWorldPoint(Input.mousePosition).x;
        }
    }

    void TouchMovement()
    {
        //TO-DO Touch control movement for phones
    }

    IEnumerator MoveToTargetPos(Vector3 targetPosition)
    {
        if (targetPosition != transform.position)
        {
            // Move Towards or Lerp? Decide when I use with sprite
            transform.position = Vector3.Lerp(transform.position, targetPosition, movementSpeed * Time.deltaTime);
        }
        else
        {
            yield return null;
        }
    }

    void StopMovement()
    {
        enabled = false;
    }

    void OnDisable()
    {
        Health.OnHealthDepleted -= StopMovement;
    }
}
