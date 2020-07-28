// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Keys.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @KeysControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @KeysControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Keys"",
    ""maps"": [
        {
            ""name"": ""Fase"",
            ""id"": ""07e82025-15cb-4fb7-8051-7f1d4b6c6add"",
            ""actions"": [
                {
                    ""name"": ""Restart"",
                    ""type"": ""Button"",
                    ""id"": ""ea3b24c0-1a76-454d-abe3-7e1db40b4dde"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Exit"",
                    ""type"": ""Button"",
                    ""id"": ""df50441b-348f-4df8-8b60-f349e8cd031a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ce4b9b1f-f062-43c2-be1d-f8b4aae25dcb"",
                    ""path"": ""<Keyboard>/#(R)"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Restart"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3ac4a390-4c1f-4a65-9527-43aa153194c9"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": ""Press"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Exit"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Fase
        m_Fase = asset.FindActionMap("Fase", throwIfNotFound: true);
        m_Fase_Restart = m_Fase.FindAction("Restart", throwIfNotFound: true);
        m_Fase_Exit = m_Fase.FindAction("Exit", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Fase
    private readonly InputActionMap m_Fase;
    private IFaseActions m_FaseActionsCallbackInterface;
    private readonly InputAction m_Fase_Restart;
    private readonly InputAction m_Fase_Exit;
    public struct FaseActions
    {
        private @KeysControls m_Wrapper;
        public FaseActions(@KeysControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Restart => m_Wrapper.m_Fase_Restart;
        public InputAction @Exit => m_Wrapper.m_Fase_Exit;
        public InputActionMap Get() { return m_Wrapper.m_Fase; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(FaseActions set) { return set.Get(); }
        public void SetCallbacks(IFaseActions instance)
        {
            if (m_Wrapper.m_FaseActionsCallbackInterface != null)
            {
                @Restart.started -= m_Wrapper.m_FaseActionsCallbackInterface.OnRestart;
                @Restart.performed -= m_Wrapper.m_FaseActionsCallbackInterface.OnRestart;
                @Restart.canceled -= m_Wrapper.m_FaseActionsCallbackInterface.OnRestart;
                @Exit.started -= m_Wrapper.m_FaseActionsCallbackInterface.OnExit;
                @Exit.performed -= m_Wrapper.m_FaseActionsCallbackInterface.OnExit;
                @Exit.canceled -= m_Wrapper.m_FaseActionsCallbackInterface.OnExit;
            }
            m_Wrapper.m_FaseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Restart.started += instance.OnRestart;
                @Restart.performed += instance.OnRestart;
                @Restart.canceled += instance.OnRestart;
                @Exit.started += instance.OnExit;
                @Exit.performed += instance.OnExit;
                @Exit.canceled += instance.OnExit;
            }
        }
    }
    public FaseActions @Fase => new FaseActions(this);
    public interface IFaseActions
    {
        void OnRestart(InputAction.CallbackContext context);
        void OnExit(InputAction.CallbackContext context);
    }
}
