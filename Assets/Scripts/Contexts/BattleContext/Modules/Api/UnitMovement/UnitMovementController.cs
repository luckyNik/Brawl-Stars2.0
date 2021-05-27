using UnityEngine;

public class UnitMovementController : MonoBehaviour
{
    private Animator _animator;
    private VariableJoystick _joystick;
    private CharacterController _controller;
    private PlayerManager _playerManager;

    private UnitModel _model;

    public void Initialize(UnitModel model)
    {
        _model = model;
    }
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponent<CharacterController>();
        _playerManager = GetComponent<PlayerManager>();

        _joystick = BattleHUD.Instance.LeftJoystick;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_playerManager.IsMine)
            return;

        var move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical);

        _animator.SetFloat("Velocity X", _joystick.Horizontal * 2);
        _animator.SetFloat("Velocity Z", _joystick.Vertical * 2);

        _controller.Move(move * Time.deltaTime * 15);

        _model.CurrentPosition = transform.position;
    }
}