using Assets.Scripts.ScriptableObjects.Events;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemController : MonoBehaviour
{

    [SerializeField]
    private InputSystemEvent OnKeyDownJumpStarded = null;

    [SerializeField]
    private InputSystemEvent OnKeyDownJumpCanceled = null;

    [SerializeField]
    private InputSystemEvent OnMovePerformed = null;

    [SerializeField]
    private InputSystemEvent OnShootPerformed = null;

    [SerializeField]
    private InputSystemEvent OnShootCanceled = null;

    [SerializeField]
    private InputSystemEvent OnReloadPerformed = null;

    [SerializeField]
    private InputSystemEvent OnWeaponSwitchPerformed = null;

    [SerializeField]
    private InputSystemEvent OnMouseRightClickPerformed = null;

    private InputMaster _controls;

    private void Awake()
    {
        _controls = new InputMaster();

        _controls.Player.Move.performed             += Move_performed;
        _controls.Player.Jump.started               += Jump_started;
        _controls.Player.Jump.canceled              += Jump_canceled;
        _controls.Player.Reload.performed           += Reload_performed;
        _controls.Player.Shoot.performed            += Shoot_performed;
        _controls.Player.Shoot.canceled             += Shoot_canceled;
        _controls.Player.SwitchWeapon.performed     += SwitchWeapon_performed;
        _controls.Player.MouseEyeSight.performed    += MouseRightClick_performed;


    }

    private void Shoot_canceled(InputAction.CallbackContext obj)
    {
        OnShootCanceled?.Raise(obj);
    }

    private void SwitchWeapon_performed(InputAction.CallbackContext obj)
    {
        OnWeaponSwitchPerformed?.Raise(obj);
    }

    private void Shoot_performed(InputAction.CallbackContext obj)
    {
        OnShootPerformed?.Raise(obj);
    }

    private void Reload_performed(InputAction.CallbackContext obj)
    {
        OnReloadPerformed?.Raise(obj);
    }

    private void Move_performed(InputAction.CallbackContext obj)
    {
        OnMovePerformed?.Raise(obj);
    }

    private void Jump_canceled(InputAction.CallbackContext obj)
    {
        OnKeyDownJumpCanceled?.Raise(obj);
    }

    private void Jump_started(InputAction.CallbackContext obj)
    {
        OnKeyDownJumpStarded?.Raise(obj);
    }

    private void MouseRightClick_performed(InputAction.CallbackContext obj)
    {
        OnMouseRightClickPerformed?.Raise(obj);
    }

    private void OnEnable()
    {
        _controls.Enable();
    }

    private void OnDisable()
    {
        _controls.Disable();
    }

    private void OnDestroy()
    {
        _controls.Player.Move.performed         -= Move_performed;
        _controls.Player.Jump.started           -= Jump_started;
        _controls.Player.Jump.canceled          -= Jump_canceled;
        _controls.Player.Reload.performed       -= Reload_performed;
        _controls.Player.Shoot.performed        -= Shoot_performed;
        _controls.Player.SwitchWeapon.performed -= SwitchWeapon_performed;
        _controls.Player.MouseEyeSight.performed -= MouseRightClick_performed;

    }
}
