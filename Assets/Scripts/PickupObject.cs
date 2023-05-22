using UnityEngine.InputSystem;
using UnityEngine;

public class PickupObject : MonoBehaviour
{
    private bool isHolding = false;
    private Transform player;
    private Vector3 objectPosition;
    private Quaternion objectRotation;
    private Transform hand;

    public void SetPlayer(Transform playerTransform,Transform playerHandTransform)
    {
        player = playerTransform;
        hand = playerHandTransform;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (isHolding)
        {
            
            transform.position = hand.position;
            transform.rotation = hand.rotation;

        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!isHolding)
            { 
                PickUp();
            }
            else
            {
                Drop();
            }
        }
    }

    private void PickUp()
    {
        isHolding = true;
        objectPosition = transform.position;
        objectRotation = hand.rotation;
        
        GetComponent<Rigidbody>().isKinematic = true;

        transform.parent = hand;

    }

    private void Drop()
    {
        isHolding = false;

        
        GetComponent<Rigidbody>().isKinematic = false;

        transform.parent = null;

        transform.position = objectPosition;
        transform.rotation = objectRotation;
    }
}