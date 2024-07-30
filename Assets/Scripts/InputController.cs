using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private InputSystem_Actions inputSystem_Actions;
    void Start()
    {
        inputSystem_Actions = new InputSystem_Actions();
        inputSystem_Actions.Player.Enable();

        inputSystem_Actions.Player.Click.performed += Click_performed;
    }

    private void Click_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        Vector2 screenPosition = GetScreenPosition();
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit)){
            HandleRaycastHit(hit);
        }
    }

    private Vector2 GetScreenPosition()
    {
        if (Mouse.current != null)
        {
            return Mouse.current.position.ReadValue();
        }
        else
        {
            return Touchscreen.current.primaryTouch.position.ReadValue();
        }

    }
    private void HandleRaycastHit(RaycastHit hit)
    {
        Car car = hit.collider.gameObject.GetComponent<Car>();
        if (car)
        {
            car.StartMove();
            //car.isMove = true;
        }
    }

}
