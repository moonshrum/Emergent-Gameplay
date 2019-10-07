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
                    ""type"": ""Value"",
                    ""id"": ""b5ee230c-047d-455d-8395-a2c445f0ca3e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Collect"",
                    ""type"": ""Button"",
                    ""id"": ""9e1c433f-3f26-409b-87a8-7c3f8bee2c11"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""7a279acd-c14b-47c4-9037-f86b04971ea7"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""33423cd0-f441-470b-a10e-835dc0710f02"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shop"",
                    ""type"": ""Button"",
                    ""id"": ""c76244b4-af83-41a8-ad1d-07cb7e906365"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Category Selection"",
                    ""type"": ""Value"",
                    ""id"": ""5ed4af4c-5682-4e5a-bf15-36d2658033c9"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item Selection"",
                    ""type"": ""Value"",
                    ""id"": ""67d5d499-e221-4cad-b6f6-e4dbe9e78772"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BuyItem"",
                    ""type"": ""Button"",
                    ""id"": ""04e8379d-fb6c-4785-b433-efc9b252db55"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventoryItemSelection"",
                    ""type"": ""Value"",
                    ""id"": ""fa8a026f-8a77-442f-9629-5b47a253b0ec"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvItemInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""c2cacd94-e60b-4e95-93db-55d26e745038"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlaceTrap"",
                    ""type"": ""Button"",
                    ""id"": ""6c43ec86-8342-4f75-bf74-3400cfde1480"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelTrapPlacing"",
                    ""type"": ""Button"",
                    ""id"": ""f6bc4b70-d499-41e0-a5bc-e084006e6dc3"",
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
                    ""id"": ""e0082a71-9ec6-4740-a069-c918904e856c"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""72ce8f85-7628-46d4-855e-c31d98c89f34"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""85de72fb-b838-44f5-984c-d2dab02aca4d"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d5c0a835-a307-4455-9bfa-5ffa952a2232"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Attack"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c39780eb-8de5-4d02-82ca-f6887a9545bf"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""40a02181-7830-4434-b52e-02a926392d67"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Dodge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff33a4d7-f29c-42c3-ba9f-1b51ae9d5fa2"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Shop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e8d460e8-735b-43e4-8717-48c71eb8c923"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard and Mouse"",
                    ""action"": ""Shop"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4adfcf66-ebbc-40c6-ac08-f4ff99bbb0f8"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Category Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""a4a2cc09-d97b-4ab0-94ba-155cf34f3f7a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Category Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""73b14f87-2fd9-48a8-90d9-00638e939268"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Category Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""8ef843e7-fa1f-4e15-843a-cfa8b55fc94d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Category Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""acd61473-3fab-4ec2-beea-d856b567e45d"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Category Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7f91e211-08c6-4ce1-8b31-e6bc82581b99"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Category Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""7f0a019b-2008-42b1-9a2b-b6a16157554a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""7766734c-8082-471b-988a-e4b4c217b316"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fc81a226-c53c-415d-9be5-e2321afcb07f"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""41ab127a-2f4a-4e23-999b-2380eb77607f"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""4a4f8583-77c9-4c8e-bc36-33e75c69d8ca"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""bded899d-b430-49dc-a2b9-3fe016f2284c"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Item Selection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a9811e62-6e87-4912-9c0e-1b559f558c42"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""BuyItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""57b5aaf0-4c36-4990-acdc-58a4f111a909"",
                    ""path"": ""<Keyboard>/b"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""BuyItem"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""a774111a-3663-45b5-b32a-95778429fc93"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9365eb3f-b7a2-4820-99b2-b9f882ee79c7"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c7b479d-ca9e-47a6-b27a-4b43c22be565"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""fa7a4851-860c-432d-b15a-f4c0c3b3bc7f"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7accea97-6ef0-4566-b50e-67367de71a34"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""1efacfb1-6319-4a6d-8ea6-6ef31342d74b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7fc4d81d-0047-4ae1-b86c-00e289238e93"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""InvItemInteraction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c26168e8-e67e-44ca-b558-72612602c49e"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""PlaceTrap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae6198d2-cf48-4ef3-9ade-4adab133fa62"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CancelTrapPlacing"",
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
        m_Player_Collect = m_Player.GetAction("Collect");
        m_Player_Attack = m_Player.GetAction("Attack");
        m_Player_Dodge = m_Player.GetAction("Dodge");
        m_Player_Shop = m_Player.GetAction("Shop");
        m_Player_CategorySelection = m_Player.GetAction("Category Selection");
        m_Player_ItemSelection = m_Player.GetAction("Item Selection");
        m_Player_BuyItem = m_Player.GetAction("BuyItem");
        m_Player_InventoryItemSelection = m_Player.GetAction("InventoryItemSelection");
        m_Player_InvItemInteraction = m_Player.GetAction("InvItemInteraction");
        m_Player_PlaceTrap = m_Player.GetAction("PlaceTrap");
        m_Player_CancelTrapPlacing = m_Player.GetAction("CancelTrapPlacing");
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
    private readonly InputAction m_Player_Collect;
    private readonly InputAction m_Player_Attack;
    private readonly InputAction m_Player_Dodge;
    private readonly InputAction m_Player_Shop;
    private readonly InputAction m_Player_CategorySelection;
    private readonly InputAction m_Player_ItemSelection;
    private readonly InputAction m_Player_BuyItem;
    private readonly InputAction m_Player_InventoryItemSelection;
    private readonly InputAction m_Player_InvItemInteraction;
    private readonly InputAction m_Player_PlaceTrap;
    private readonly InputAction m_Player_CancelTrapPlacing;
    public struct PlayerActions
    {
        private PlayerInputs m_Wrapper;
        public PlayerActions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_Move;
        public InputAction @Collect => m_Wrapper.m_Player_Collect;
        public InputAction @Attack => m_Wrapper.m_Player_Attack;
        public InputAction @Dodge => m_Wrapper.m_Player_Dodge;
        public InputAction @Shop => m_Wrapper.m_Player_Shop;
        public InputAction @CategorySelection => m_Wrapper.m_Player_CategorySelection;
        public InputAction @ItemSelection => m_Wrapper.m_Player_ItemSelection;
        public InputAction @BuyItem => m_Wrapper.m_Player_BuyItem;
        public InputAction @InventoryItemSelection => m_Wrapper.m_Player_InventoryItemSelection;
        public InputAction @InvItemInteraction => m_Wrapper.m_Player_InvItemInteraction;
        public InputAction @PlaceTrap => m_Wrapper.m_Player_PlaceTrap;
        public InputAction @CancelTrapPlacing => m_Wrapper.m_Player_CancelTrapPlacing;
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
                Collect.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollect;
                Collect.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollect;
                Collect.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCollect;
                Attack.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                Attack.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                Attack.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnAttack;
                Dodge.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                Dodge.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                Dodge.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnDodge;
                Shop.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShop;
                Shop.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShop;
                Shop.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnShop;
                CategorySelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                CategorySelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                CategorySelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                ItemSelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemSelection;
                ItemSelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemSelection;
                ItemSelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnItemSelection;
                BuyItem.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuyItem;
                BuyItem.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuyItem;
                BuyItem.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnBuyItem;
                InventoryItemSelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryItemSelection;
                InventoryItemSelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryItemSelection;
                InventoryItemSelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventoryItemSelection;
                InvItemInteraction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
                PlaceTrap.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceTrap;
                PlaceTrap.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceTrap;
                PlaceTrap.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnPlaceTrap;
                CancelTrapPlacing.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelTrapPlacing;
                CancelTrapPlacing.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelTrapPlacing;
                CancelTrapPlacing.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelTrapPlacing;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
                Collect.started += instance.OnCollect;
                Collect.performed += instance.OnCollect;
                Collect.canceled += instance.OnCollect;
                Attack.started += instance.OnAttack;
                Attack.performed += instance.OnAttack;
                Attack.canceled += instance.OnAttack;
                Dodge.started += instance.OnDodge;
                Dodge.performed += instance.OnDodge;
                Dodge.canceled += instance.OnDodge;
                Shop.started += instance.OnShop;
                Shop.performed += instance.OnShop;
                Shop.canceled += instance.OnShop;
                CategorySelection.started += instance.OnCategorySelection;
                CategorySelection.performed += instance.OnCategorySelection;
                CategorySelection.canceled += instance.OnCategorySelection;
                ItemSelection.started += instance.OnItemSelection;
                ItemSelection.performed += instance.OnItemSelection;
                ItemSelection.canceled += instance.OnItemSelection;
                BuyItem.started += instance.OnBuyItem;
                BuyItem.performed += instance.OnBuyItem;
                BuyItem.canceled += instance.OnBuyItem;
                InventoryItemSelection.started += instance.OnInventoryItemSelection;
                InventoryItemSelection.performed += instance.OnInventoryItemSelection;
                InventoryItemSelection.canceled += instance.OnInventoryItemSelection;
                InvItemInteraction.started += instance.OnInvItemInteraction;
                InvItemInteraction.performed += instance.OnInvItemInteraction;
                InvItemInteraction.canceled += instance.OnInvItemInteraction;
                PlaceTrap.started += instance.OnPlaceTrap;
                PlaceTrap.performed += instance.OnPlaceTrap;
                PlaceTrap.canceled += instance.OnPlaceTrap;
                CancelTrapPlacing.started += instance.OnCancelTrapPlacing;
                CancelTrapPlacing.performed += instance.OnCancelTrapPlacing;
                CancelTrapPlacing.canceled += instance.OnCancelTrapPlacing;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);
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
        void OnCollect(InputAction.CallbackContext context);
        void OnAttack(InputAction.CallbackContext context);
        void OnDodge(InputAction.CallbackContext context);
        void OnShop(InputAction.CallbackContext context);
        void OnCategorySelection(InputAction.CallbackContext context);
        void OnItemSelection(InputAction.CallbackContext context);
        void OnBuyItem(InputAction.CallbackContext context);
        void OnInventoryItemSelection(InputAction.CallbackContext context);
        void OnInvItemInteraction(InputAction.CallbackContext context);
        void OnPlaceTrap(InputAction.CallbackContext context);
        void OnCancelTrapPlacing(InputAction.CallbackContext context);
    }
}
