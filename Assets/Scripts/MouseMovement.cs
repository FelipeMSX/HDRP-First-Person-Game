using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMovement : MonoBehaviour
{
    [SerializeField]
    private float _mouseSensitivity = 300f;
    public float MouseSensitivity
    {
        get =>_mouseSensitivity; 
        set => _mouseSensitivity = value; 
    }

    [SerializeField]
    private Transform _playerBody;
    public Transform PlayerBody 
    {
        get =>_playerBody; 
        set => _playerBody = value; 
    }

    [SerializeField]
    private GameObject _currentWeapon;
    public GameObject CurrentWeapon
    {
        get => _currentWeapon;
        set => _currentWeapon = value;
    }

    private float _xRotation = 0f;

    private Mouse _mouse;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        _mouse = InputSystem.GetDevice<Mouse>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseDeltValue = _mouse.delta.ReadValue();
        //_mouse.position.x;
        float mouseX = mouseDeltValue.x * MouseSensitivity * Time.deltaTime;
        float mouseY = mouseDeltValue.y * MouseSensitivity * Time.deltaTime;

        ////Pra fazer o player olhar pra cima é preciso rotacionar o vetorX com o movimento do mouse para cima. 
        _xRotation -= mouseY;
        ////Isso aqui não permite que o player consiga rotacionar para atrás dele.
        _xRotation = Mathf.Clamp(_xRotation, -45f, 45f);

        transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);

    }

}
