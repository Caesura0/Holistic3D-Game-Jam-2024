using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public class HotkeySelectedEventArgs : EventArgs
    {
        public int HotkeyValue { get; }

        public HotkeySelectedEventArgs(int hotkeyValue)
        {
            HotkeyValue = hotkeyValue;
        }
    }
    

    public static PlayerInput Instance { get; private set; }


    public event EventHandler OnInteractAction;
    public event EventHandler OnItemUseAction;
    public event EventHandler OnQuestUIAction;
    public event EventHandler OnRunCanceledAction;
    public event EventHandler OnRunAction;
    public event EventHandler<HotkeySelectedEventArgs> OnHotkeySelectedAction;
    //public event EventHandler OnPauseAction;
    public Vector2 Movement {  get; private set; }


    private PlayerControls controls;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        controls = new PlayerControls();


        // Setup input callbacks
        controls.KeyboardGamepad.Movement.performed += ctx => Movement = ctx.ReadValue<Vector2>();
        controls.KeyboardGamepad.Movement.canceled += ctx => Movement = Vector2.zero;

        controls.KeyboardGamepad.Interact.performed += Interact_performed;
        controls.KeyboardGamepad.UseItem.performed += ItemUse_performed;


        controls.KeyboardGamepad.Hotkeys.performed += OnHotkeySelected_Performed;

        controls.KeyboardGamepad.QuestUI.performed += QuestUI_performed; ;

        controls.KeyboardGamepad.Run.performed += Run_performed;
        controls.KeyboardGamepad.Run.canceled += Run_canceled;
    }

    private void Run_canceled(InputAction.CallbackContext obj)
    {
        OnRunCanceledAction?.Invoke(this, EventArgs.Empty);
    }

    private void Run_performed(InputAction.CallbackContext obj)
    {
        OnRunAction?.Invoke(this, EventArgs.Empty);
    }

    private void QuestUI_performed(InputAction.CallbackContext obj)
    {
        OnQuestUIAction?.Invoke(this, EventArgs.Empty);
    }

    private void Interact_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnInteractAction?.Invoke(this, EventArgs.Empty);
    }

    private void ItemUse_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        OnItemUseAction?.Invoke(this, EventArgs.Empty);
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }






    private void OnHotkeySelected_Performed(InputAction.CallbackContext context)
    {
        var selectedSlot = (int)context.ReadValue<float>(); // Directly read the value from the input
        OnHotkeySelectedAction?.Invoke(this, new HotkeySelectedEventArgs(selectedSlot));
    }
}