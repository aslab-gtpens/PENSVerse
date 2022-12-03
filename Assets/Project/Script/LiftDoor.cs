using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftDoor : MonoBehaviour
{
    [SerializeField] Transform leftDoor;
    [SerializeField] Transform rightDoor;

    [Header("positioning")]
    [SerializeField] Vector3 leftTarget;
    [SerializeField] Vector3 rightTarget;
    Vector3 leftOrigin;
    Vector3 rightOrigin;

    [Header("Lift")]
    [Range(0,10)]public int speedModifier;
     float _speed => 0.001f * speedModifier;

    public bool isOpen;
    

    

    private void Awake()
    {
        leftOrigin = leftDoor.position;
        rightOrigin = rightDoor.position;
    }

    private void Start()
    {
        StartCoroutine(MoveDoor(true));
    }

    IEnumerator MoveDoor(bool open)
    {
        Vector3 lTarget = (open) ? leftTarget : leftOrigin;
        Vector3 rTarget = (open) ? rightTarget : rightOrigin;

        while(Mathf.Abs(lTarget.x - leftDoor.localPosition.x) > 0.1f && Mathf.Abs(rTarget.x - rightDoor.localPosition.x) > 0.1f)
        {
            leftDoor.localPosition = Vector3.MoveTowards(leftDoor.localPosition, lTarget, _speed);
            rightDoor.localPosition = Vector3.MoveTowards(rightDoor.localPosition, rTarget, _speed);
            
            yield return null;
        }
        
        
        isOpen = open;

        yield return null;
    }

}
