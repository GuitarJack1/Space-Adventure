//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Input System/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""SpaceShip"",
            ""id"": ""a5319264-3c84-497d-b896-2239565a9238"",
            ""actions"": [
                {
                    ""name"": ""Rotation (Pitch/Roll)"",
                    ""type"": ""Value"",
                    ""id"": ""21764f9a-cc92-4692-ae90-b5df83f42715"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Boost"",
                    ""type"": ""Button"",
                    ""id"": ""df2e2721-9d4c-47ea-8da2-51a04125672f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""fd5ce863-6104-44c1-8e76-3d9fbc4c5da3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotation (Pitch/Roll)"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""463d8ee6-5356-4139-bea1-4d86801b7f72"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotation (Pitch/Roll)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""4f558dc3-1860-4332-b4a9-163d9dd03f92"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotation (Pitch/Roll)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""370ceed6-fbf9-4c60-b330-c36062346943"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotation (Pitch/Roll)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4bb2efd8-9fc3-4676-b207-991b4bd8c0ad"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Rotation (Pitch/Roll)"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""7dc1dcc4-48ee-4f44-8fa0-d98852b74a90"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Boost"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Planet_Creation"",
            ""id"": ""0f5a4f6f-dc79-4d25-ac13-e6bc2968072b"",
            ""actions"": [
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""8790723c-6c69-467d-84d9-af7b5d2bd693"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e153fb93-b239-4aed-b17a-3cb0f5c7bdfa"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": []
        }
    ]
}");
        // SpaceShip
        m_SpaceShip = asset.FindActionMap("SpaceShip", throwIfNotFound: true);
        m_SpaceShip_RotationPitchRoll = m_SpaceShip.FindAction("Rotation (Pitch/Roll)", throwIfNotFound: true);
        m_SpaceShip_Boost = m_SpaceShip.FindAction("Boost", throwIfNotFound: true);
        // Planet_Creation
        m_Planet_Creation = asset.FindActionMap("Planet_Creation", throwIfNotFound: true);
        m_Planet_Creation_Select = m_Planet_Creation.FindAction("Select", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // SpaceShip
    private readonly InputActionMap m_SpaceShip;
    private List<ISpaceShipActions> m_SpaceShipActionsCallbackInterfaces = new List<ISpaceShipActions>();
    private readonly InputAction m_SpaceShip_RotationPitchRoll;
    private readonly InputAction m_SpaceShip_Boost;
    public struct SpaceShipActions
    {
        private @PlayerControls m_Wrapper;
        public SpaceShipActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RotationPitchRoll => m_Wrapper.m_SpaceShip_RotationPitchRoll;
        public InputAction @Boost => m_Wrapper.m_SpaceShip_Boost;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShip; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActions set) { return set.Get(); }
        public void AddCallbacks(ISpaceShipActions instance)
        {
            if (instance == null || m_Wrapper.m_SpaceShipActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_SpaceShipActionsCallbackInterfaces.Add(instance);
            @RotationPitchRoll.started += instance.OnRotationPitchRoll;
            @RotationPitchRoll.performed += instance.OnRotationPitchRoll;
            @RotationPitchRoll.canceled += instance.OnRotationPitchRoll;
            @Boost.started += instance.OnBoost;
            @Boost.performed += instance.OnBoost;
            @Boost.canceled += instance.OnBoost;
        }

        private void UnregisterCallbacks(ISpaceShipActions instance)
        {
            @RotationPitchRoll.started -= instance.OnRotationPitchRoll;
            @RotationPitchRoll.performed -= instance.OnRotationPitchRoll;
            @RotationPitchRoll.canceled -= instance.OnRotationPitchRoll;
            @Boost.started -= instance.OnBoost;
            @Boost.performed -= instance.OnBoost;
            @Boost.canceled -= instance.OnBoost;
        }

        public void RemoveCallbacks(ISpaceShipActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(ISpaceShipActions instance)
        {
            foreach (var item in m_Wrapper.m_SpaceShipActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_SpaceShipActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public SpaceShipActions @SpaceShip => new SpaceShipActions(this);

    // Planet_Creation
    private readonly InputActionMap m_Planet_Creation;
    private List<IPlanet_CreationActions> m_Planet_CreationActionsCallbackInterfaces = new List<IPlanet_CreationActions>();
    private readonly InputAction m_Planet_Creation_Select;
    public struct Planet_CreationActions
    {
        private @PlayerControls m_Wrapper;
        public Planet_CreationActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Select => m_Wrapper.m_Planet_Creation_Select;
        public InputActionMap Get() { return m_Wrapper.m_Planet_Creation; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Planet_CreationActions set) { return set.Get(); }
        public void AddCallbacks(IPlanet_CreationActions instance)
        {
            if (instance == null || m_Wrapper.m_Planet_CreationActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_Planet_CreationActionsCallbackInterfaces.Add(instance);
            @Select.started += instance.OnSelect;
            @Select.performed += instance.OnSelect;
            @Select.canceled += instance.OnSelect;
        }

        private void UnregisterCallbacks(IPlanet_CreationActions instance)
        {
            @Select.started -= instance.OnSelect;
            @Select.performed -= instance.OnSelect;
            @Select.canceled -= instance.OnSelect;
        }

        public void RemoveCallbacks(IPlanet_CreationActions instance)
        {
            if (m_Wrapper.m_Planet_CreationActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPlanet_CreationActions instance)
        {
            foreach (var item in m_Wrapper.m_Planet_CreationActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_Planet_CreationActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public Planet_CreationActions @Planet_Creation => new Planet_CreationActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface ISpaceShipActions
    {
        void OnRotationPitchRoll(InputAction.CallbackContext context);
        void OnBoost(InputAction.CallbackContext context);
    }
    public interface IPlanet_CreationActions
    {
        void OnSelect(InputAction.CallbackContext context);
    }
}
