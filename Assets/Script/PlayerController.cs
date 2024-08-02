using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class PlayerController : MonoBehaviour
{


    public VariableJoystick joystick;
    public CharacterController controller;
    public Canvas inputCanvas;
    public bool isJoystick;
    public float movementSpeed;
    public float rotationSpeed;
    public bool walking;


    private void Awake()
    {
        

    }
    void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null)
        {
            Inventory.instance.AddItem(item);
            Destroy(other.gameObject); // Remove the item from the scene
        }
    }
    private void UseItem(Item item)
    {
        
    }

    private void Start()
    {

        Time.timeScale = 1f;
        EnableJoystickInput();
    }

    public void EnableJoystickInput()
    {
        isJoystick = true;
        inputCanvas.gameObject.SetActive(true);
    }
    private void Update()
    {
        if (isJoystick)
        {
            var movementDirection = new Vector3(joystick.Direction.x, 0f, joystick.Direction.y);
            controller.SimpleMove(movementDirection * movementSpeed);

            if (movementDirection.sqrMagnitude <= 0)
            {

                return;
            }

            walking = true;
            var targetDirection = Vector3.RotateTowards(controller.transform.forward,
                movementDirection, rotationSpeed * Time.deltaTime, 0f);
            controller.transform.rotation = Quaternion.LookRotation(targetDirection);
        }

    }



}
