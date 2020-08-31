using UnityEngine;
using UnityEngine.InputSystem;

public class ReticleController : MonoBehaviour
{

    [SerializeField]
    private float _defaultSize = 40f;
    public float DefaultSize
    {
        get { return _defaultSize; }
        set { _defaultSize = value; }
    }

    [SerializeField]
    private float _maxSize = 80f;
    public float MaxSize
    {
        get { return _maxSize; }
        set { _maxSize = value; }
    }

    [SerializeField]
    private float _speed = 6f;
    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    private float _currentSize;
    private RectTransform _reticle;
    //private InputMaster _controls;
    private bool IsMoving;


    // Start is called before the first frame update
    void Start()
    {
        _reticle = GetComponent<RectTransform>();

        //_controls = GetComponent<InputSystemController>().Controls;
        //_controls.Player.Move.performed += Move_Performed;
        //_controls.Player.Move.Enable();
    }

    private void Move_Performed(InputAction.CallbackContext obj)
    {
        IsMoving = !IsMoving;
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsMoving)
        //    _currentSize = Mathf.Lerp(_currentSize, MaxSize, Time.deltaTime * Speed);
        //else
        //    _currentSize = Mathf.Lerp(_currentSize, DefaultSize, Time.deltaTime * Speed);

        //_reticle.sizeDelta = new Vector2(_currentSize, _currentSize);

    }
}