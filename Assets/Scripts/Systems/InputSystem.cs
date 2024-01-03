using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public partial class InputSystem : ComponentSystem
{
    private EntityQuery _inputQuery;
    private InputAction _moveAction;
    private InputAction _shootAction;
    private InputAction _reloadAction;
    private float2 _moveInput;
    private float _shootInput;
    private float _reloadInput;

    protected override void OnCreate()
    {
        _inputQuery = GetEntityQuery(ComponentType.ReadOnly<InputData>());
    }

    public void OnMoveInput(Vector2 input)
    {
        _moveInput = input;
    }

    public Vector2 GetMoveInput()
    {
        return _moveInput;
    }

    protected override void OnStartRunning()
    {
        _moveAction = new InputAction("move", InputActionType.Value, "<Gamepad>/rightStick");
        _moveAction.AddCompositeBinding("Dpad")
            .With(name: "Up", binding: "<Keyboard>/w")
            .With(name: "Down", binding: "<Keyboard>/s")
            .With(name: "Left", binding: "<Keyboard>/a")
            .With(name: "Right", binding: "<Keyboard>/d");
        _moveAction.performed += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.started += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.canceled += context => { _moveInput = context.ReadValue<Vector2>(); };
        _moveAction.Enable();

        _shootAction = new InputAction(name: "shoot", binding: "mouse/leftButton");
        _shootAction.performed += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.started += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.canceled += context => { _shootInput = context.ReadValue<float>(); };
        _shootAction.Enable();

        _reloadAction = new InputAction(name: "reload", binding: "mouse/rightButton");
        _reloadAction.performed += context => { _reloadInput = context.ReadValue<float>(); };
        _reloadAction.started += context => { _reloadInput = context.ReadValue<float>(); };
        _reloadAction.canceled += context => { _reloadInput = context.ReadValue<float>(); };
        _reloadAction.Enable();

    }

    protected override void OnStopRunning()
    {
        _moveAction.Disable();
        _shootAction.Disable();
        _reloadAction.Disable();
    }

    protected override void OnUpdate()
    {
        Entities.With(_inputQuery).ForEach(
            (Entity entity,ref ReloadData reloadData, ref ShootData shootData, ref InputData inputData) =>
            {
                inputData.Move = _moveInput;
                shootData.Shoot = _shootInput;
                reloadData.Reload = _reloadInput;
                
            });
    }
}
