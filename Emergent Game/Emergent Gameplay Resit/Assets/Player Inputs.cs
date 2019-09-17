// GENERATED AUTOMATICALLY FROM 'Assets/Player Inputs.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerInputs : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerInputs()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player Inputs"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""52ba7820-4e17-46b5-b470-c7a5078a42de"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b5ee230c-047d-455d-8395-a2c445f0ca3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""b5ceea7a-8bd4-4f48-bc9c-960d31c8d058"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7e58d621-1013-455c-a2f5-c5d5cc4f4b90"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard "",
                    ""id"": ""96e4fa17-66d0-4c3c-ae1e-5b746f418964"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""a97a1127-117f-4dfe-ab0e-febcb233a5af"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""9d95a592-32b1-445e-945b-5c4876d0cac0"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""6290b52b-8cd7-42fa-bbc2-33ab479e1c83"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""23b07393-e6db-4307-8da6-a21bedc25752"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""2860c823-295d-4520-98b0-c2fc5ec6cdff"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Mouselook"",
                    ""id"": ""91b1a458-b3a0-4b60-83ee-3f32f68c1067"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7466ce85-950a-4e03-9ab3-4749cbdfc1ce"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""0ed5d57b-ea0f-470b-9c9f-8e63311c3e51"",
                    ""path"": ""<Mouse>/delta/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player2"",
            ""id"": ""6f384cc1-bd0a-43dc-a20a-b72b7e27b91b"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""c792ec0d-3435-4d6e-ba83-e602f578cf00"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Rotate"",
                    ""type"": ""Button"",
                    ""id"": ""3c557835-7a59-4405-b177-a88155884f70"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c924b88f-59e4-4ae4-8f8d-6aa8e820f8d1"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b1bc9ba6-b43a-4fb7-9cbd-67817fc35f5e"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Rotate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Controller"",
            ""bindingGroup"": ""Controller"",
            ""devices"": [
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard and Mouse"",
            ""bindingGroup"": ""Keyboard and Mouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player
        m_Player = asset.GetActionMap("Player");
        m_Player_Move = m_Player.GetAction("Move");
        m_Player_Rotate = m_Player.GetAction("Rotate");
        // Player2
        m_Player2 = asset.GetActionMap("Player2");
        m_Player2_Move = m_Player2.GetAction("Move");
        m_Player2_Rotate = m_Player2.GetAction("Rotate");
    }

    ~PlayerInputs()
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

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Move;
    private readonly InputAction m_Player_Rotate;
    public struct PlayerActions
    {
        private PlayerInputs m_Wrapper;
        public PlayerActions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Rotate => m_Wrapper.m_Player_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMove;
                Rotate.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player2
    private readonly InputActionMap m_Player2;
    private IPlayer2Actions m_Player2ActionsCallbackInterface;
    private readonly InputAction m_Player2_Move;
    private readonly InputAction m_Player2_Rotate;
    public struct Player2Actions
    {
        private PlayerInputs m_Wrapper;
        public Player2Actions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player2_Move;
        public InputAction @Rotate => m_Wrapper.m_Player2_Rotate;
        public InputActionMap Get() { return m_Wrapper.m_Player2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer2Actions instance)
        {
            if (m_Wrapper.m_Player2ActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnMove;
                Rotate.started -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
                Rotate.performed -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
                Rotate.canceled -= m_Wrapper.m_Player2ActionsCallbackInterface.OnRotate;
            }
            m_Wrapper.m_Player2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Rotate.started += instance.OnRotate;
                Rotate.performed += instance.OnRotate;
                Rotate.canceled += instance.OnRotate;
            }
        }
    }
    public Player2Actions @Player2 => new Player2Actions(this);
    private int m_ControllerSchemeIndex = -1;
    public InputControlScheme ControllerScheme
    {
        get
        {
            if (m_ControllerSchemeIndex == -1) m_ControllerSchemeIndex = asset.GetControlSchemeIndex("Controller");
            return asset.controlSchemes[m_ControllerSchemeIndex];
        }
    }
    private int m_KeyboardandMouseSchemeIndex = -1;
    public InputControlScheme KeyboardandMouseScheme
    {
        get
        {
            if (m_KeyboardandMouseSchemeIndex == -1) m_KeyboardandMouseSchemeIndex = asset.GetControlSchemeIndex("Keyboard and Mouse");
            return asset.controlSchemes[m_KeyboardandMouseSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
    public interface IPlayer2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRotate(InputAction.CallbackContext context);
    }
}
