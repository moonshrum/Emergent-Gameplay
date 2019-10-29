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
                    ""name"": ""OnA"",
                    ""type"": ""Button"",
                    ""id"": ""a8489651-dd1f-437f-9adc-40712deb6cfb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnX"",
                    ""type"": ""Button"",
                    ""id"": ""2cf4c213-a21b-432e-864b-6e5ef7459e1a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnB"",
                    ""type"": ""Button"",
                    ""id"": ""37f52215-a707-441f-bed2-3c879986e97e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnLT"",
                    ""type"": ""Button"",
                    ""id"": ""9be5b7b6-0a32-4402-b972-1ef52bd6691f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnRB"",
                    ""type"": ""Button"",
                    ""id"": ""0334661c-923b-4726-9ca4-c4ae77ebcc97"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnRT"",
                    ""type"": ""Button"",
                    ""id"": ""06aed2db-aa30-4327-88fc-d7f3bfa87897"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""LeftStick"",
                    ""type"": ""Value"",
                    ""id"": ""b5ee230c-047d-455d-8395-a2c445f0ca3e"",
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
                    ""name"": ""InventorySlotSelection"",
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
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7e58d621-1013-455c-a2f5-c5d5cc4f4b90"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=0.19)"",
                    ""groups"": ""Controller"",
                    ""action"": ""LeftStick"",
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
                    ""name"": """",
                    ""id"": ""1efacfb1-6319-4a6d-8ea6-6ef31342d74b"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=0.19)"",
                    ""groups"": ""Controller"",
                    ""action"": ""InventorySlotSelection"",
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
                    ""id"": ""e39aaac1-cbc4-480d-afa5-81de64527d5d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""82c58038-ebbb-4eed-aea4-fd48f58f0958"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b0362cfb-a934-41aa-9e1c-90184b0b01ec"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fb694c76-33f4-4192-bf19-8b7d481f18db"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnLT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fd5e4fc5-de3d-412c-8ca0-3f3def3df0cd"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnRB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""abf80266-91d8-4eea-ac50-0065683ae456"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""OnRT"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Player1"",
            ""id"": ""c4cb93bc-c8fd-45e6-b3ba-787f645b279a"",
            ""actions"": [
                {
                    ""name"": ""OnA"",
                    ""type"": ""Button"",
                    ""id"": ""182d9253-51fa-49aa-b0e3-81388ad69869"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnX"",
                    ""type"": ""Button"",
                    ""id"": ""8f3987ec-ea2d-469d-91a6-3c8f4fd27afb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""OnB"",
                    ""type"": ""Button"",
                    ""id"": ""9c73d359-5661-4359-8077-e5960a7d5f2c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""9e1f3e52-ee10-4c0d-bece-4c402bf997e6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Collect"",
                    ""type"": ""Button"",
                    ""id"": ""b015b907-3b8b-4d13-8b42-fca4dbd0332e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Attack"",
                    ""type"": ""Button"",
                    ""id"": ""092a3f38-206b-41e0-83b5-900b5b3c8385"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Dodge"",
                    ""type"": ""Button"",
                    ""id"": ""24d81b28-53ca-4aa3-8d7c-59ee4539393b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shop"",
                    ""type"": ""Button"",
                    ""id"": ""bea49007-6776-4cc1-86ae-37408eea2fdc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Category Selection"",
                    ""type"": ""Value"",
                    ""id"": ""2fde6516-0aa2-49c0-97e1-9f1ba472f3eb"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Item Selection"",
                    ""type"": ""Value"",
                    ""id"": ""7851e970-ac58-4fed-9dc2-9e6c4b0d4a2c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""BuyItem"",
                    ""type"": ""Button"",
                    ""id"": ""a5eb9ed6-5bb2-419b-bf5a-a1e2cefd91ad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InventoryItemSelection"",
                    ""type"": ""Value"",
                    ""id"": ""5c905598-75e6-4ae3-a63b-2497b5928ecc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""InvItemInteraction"",
                    ""type"": ""Button"",
                    ""id"": ""711dd211-15b0-4c0a-827e-9e3f785add6d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""PlaceTrap"",
                    ""type"": ""Button"",
                    ""id"": ""bb551fb8-5dee-45a5-8f27-923865b8a76d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelTrapPlacing"",
                    ""type"": ""Button"",
                    ""id"": ""a8bfee18-5fed-4df3-a11a-260b376a8a0b"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Guard"",
                    ""type"": ""Button"",
                    ""id"": ""b8202f4a-d911-4a2e-9a00-fd2289ec3c75"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9526d5cf-e95b-45f8-a79a-027ddb557159"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=0.19)"",
                    ""groups"": ""Controller"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard "",
                    ""id"": ""c9d0f2d1-58f5-46dd-92dc-222fcaa4e11c"",
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
                    ""id"": ""66dcea2c-b9b4-478d-8832-99fa8024455d"",
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
                    ""id"": ""24764256-cb8e-4e36-a1a1-a9654be3790d"",
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
                    ""id"": ""e67b3b56-c8cb-4e79-886e-5dd813cc319e"",
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
                    ""id"": ""dbdb47b2-944b-4263-8ddf-22e759a4ef87"",
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
                    ""id"": ""1035fa06-1853-496f-b7f8-8168cf48beb3"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Collect"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0f07cb9-b988-45a1-a8a1-d01d05582bf4"",
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
                    ""id"": ""54e32d6f-5996-4833-9f1f-14a10ca37310"",
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
                    ""id"": ""51686e40-6e6f-4f73-ac95-8ca88bb8d797"",
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
                    ""id"": ""6928a763-3469-4d1f-ae99-9c6814753cce"",
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
                    ""id"": ""61db183c-2dc8-49b0-94d4-10cf06a9fdb6"",
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
                    ""id"": ""307d3249-0c1e-4757-aebd-919a0a72a9bd"",
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
                    ""id"": ""bd21ef26-c255-4f92-85d0-8cc1ed015d3a"",
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
                    ""id"": ""07118bc9-a77d-41af-a423-206da9f88bd9"",
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
                    ""id"": ""e06b2848-25bd-4d6b-9562-7f610283ca60"",
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
                    ""id"": ""de235642-3835-4daf-8f50-791b38dc977b"",
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
                    ""id"": ""f2007a73-ab27-4df0-9349-f679626ca33a"",
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
                    ""id"": ""2c88f8a9-e42a-4179-b8d4-6a4913884e08"",
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
                    ""id"": ""7c680e1e-5f21-4803-83aa-f2788a292a0b"",
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
                    ""id"": ""bd229da9-e894-4bf6-b8f6-b4f4315a8ce7"",
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
                    ""id"": ""695149b5-ad33-41ac-8a62-f07e5e61f4d1"",
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
                    ""id"": ""fd737c3c-a021-4a11-b99a-ea9ea34da448"",
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
                    ""id"": ""9fe2dc90-b2e0-4b87-80bd-64071d14db40"",
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
                    ""id"": ""d20237f9-6f34-42e6-9f0d-250ca169ddf6"",
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
                    ""id"": ""14c397d0-7c40-4f43-ae8a-365142f769eb"",
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
                    ""id"": ""c78c745d-7345-4aae-88f5-058399a1d03c"",
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
                    ""id"": ""445ca4ec-f314-45b9-921f-304ee2035f76"",
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
                    ""id"": ""0ea08f0a-dbe1-487a-9f50-50da1a89419e"",
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
                    ""id"": ""354a63b6-39e2-4ac6-ba28-b996f2845307"",
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
                    ""id"": ""56991a94-d362-4e09-ad75-54c2e04dc30e"",
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
                    ""id"": ""bf2838f5-c6fe-42cd-be73-56c2a2cefb22"",
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
                    ""id"": ""852cc656-efde-4747-b4fa-e0973fb7d9d2"",
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
                    ""id"": ""449be39a-73f6-42e3-b2aa-bf29baabf3e8"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": ""StickDeadzone(max=0.19)"",
                    ""groups"": ""Controller"",
                    ""action"": ""InventoryItemSelection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef2d81fe-02b2-4257-91a4-624efd1a6b31"",
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
                    ""id"": ""cdf436dc-b9ff-48d2-9a40-aa37e6ad5119"",
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
                    ""id"": ""cc161c54-6861-41f7-b2e4-3cb3557ba848"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""CancelTrapPlacing"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""69cc2f72-ae2e-481d-b0ad-f58fca823ffa"",
                    ""path"": ""<Gamepad>/leftTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Controller"",
                    ""action"": ""Guard"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d738a169-628f-4b02-8e3d-baa06847de42"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnA"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0ce5a13b-7afe-4747-a787-a786520d8ea5"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnX"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cfef072d-480a-4182-a9ed-8f2c1782b660"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""OnB"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""New action map"",
            ""id"": ""ffbd0f0f-9f85-43b8-9a9b-edd590e129df"",
            ""actions"": [
                {
                    ""name"": ""New action"",
                    ""type"": ""Button"",
                    ""id"": ""765a0055-f8e1-48dd-b0f0-98e915336176"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""2368c6cc-5c87-48dd-b386-aa400b5cd911"",
                    ""path"": """",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""New action"",
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
        m_Player_OnA = m_Player.GetAction("OnA");
        m_Player_OnX = m_Player.GetAction("OnX");
        m_Player_OnB = m_Player.GetAction("OnB");
        m_Player_OnLT = m_Player.GetAction("OnLT");
        m_Player_OnRB = m_Player.GetAction("OnRB");
        m_Player_OnRT = m_Player.GetAction("OnRT");
        m_Player_LeftStick = m_Player.GetAction("LeftStick");
        m_Player_CategorySelection = m_Player.GetAction("Category Selection");
        m_Player_InventorySlotSelection = m_Player.GetAction("InventorySlotSelection");
        m_Player_InvItemInteraction = m_Player.GetAction("InvItemInteraction");
        // Player1
        m_Player1 = asset.GetActionMap("Player1");
        m_Player1_OnA = m_Player1.GetAction("OnA");
        m_Player1_OnX = m_Player1.GetAction("OnX");
        m_Player1_OnB = m_Player1.GetAction("OnB");
        m_Player1_Move = m_Player1.GetAction("Move");
        m_Player1_Collect = m_Player1.GetAction("Collect");
        m_Player1_Attack = m_Player1.GetAction("Attack");
        m_Player1_Dodge = m_Player1.GetAction("Dodge");
        m_Player1_Shop = m_Player1.GetAction("Shop");
        m_Player1_CategorySelection = m_Player1.GetAction("Category Selection");
        m_Player1_ItemSelection = m_Player1.GetAction("Item Selection");
        m_Player1_BuyItem = m_Player1.GetAction("BuyItem");
        m_Player1_InventoryItemSelection = m_Player1.GetAction("InventoryItemSelection");
        m_Player1_InvItemInteraction = m_Player1.GetAction("InvItemInteraction");
        m_Player1_PlaceTrap = m_Player1.GetAction("PlaceTrap");
        m_Player1_CancelTrapPlacing = m_Player1.GetAction("CancelTrapPlacing");
        m_Player1_Guard = m_Player1.GetAction("Guard");
        // New action map
        m_Newactionmap = asset.GetActionMap("New action map");
        m_Newactionmap_Newaction = m_Newactionmap.GetAction("New action");
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
    private readonly InputAction m_Player_OnA;
    private readonly InputAction m_Player_OnX;
    private readonly InputAction m_Player_OnB;
    private readonly InputAction m_Player_OnLT;
    private readonly InputAction m_Player_OnRB;
    private readonly InputAction m_Player_OnRT;
    private readonly InputAction m_Player_LeftStick;
    private readonly InputAction m_Player_CategorySelection;
    private readonly InputAction m_Player_InventorySlotSelection;
    private readonly InputAction m_Player_InvItemInteraction;
    public struct PlayerActions
    {
        private PlayerInputs m_Wrapper;
        public PlayerActions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnA => m_Wrapper.m_Player_OnA;
        public InputAction @OnX => m_Wrapper.m_Player_OnX;
        public InputAction @OnB => m_Wrapper.m_Player_OnB;
        public InputAction @OnLT => m_Wrapper.m_Player_OnLT;
        public InputAction @OnRB => m_Wrapper.m_Player_OnRB;
        public InputAction @OnRT => m_Wrapper.m_Player_OnRT;
        public InputAction @LeftStick => m_Wrapper.m_Player_LeftStick;
        public InputAction @CategorySelection => m_Wrapper.m_Player_CategorySelection;
        public InputAction @InventorySlotSelection => m_Wrapper.m_Player_InventorySlotSelection;
        public InputAction @InvItemInteraction => m_Wrapper.m_Player_InvItemInteraction;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                OnA.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnA;
                OnA.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnA;
                OnA.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnA;
                OnX.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnX;
                OnX.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnX;
                OnX.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnX;
                OnB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnB;
                OnB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnB;
                OnB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnB;
                OnLT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnLT;
                OnLT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnLT;
                OnLT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnLT;
                OnRB.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRB;
                OnRB.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRB;
                OnRB.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRB;
                OnRT.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRT;
                OnRT.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRT;
                OnRT.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnOnRT;
                LeftStick.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                LeftStick.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                LeftStick.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLeftStick;
                CategorySelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                CategorySelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                CategorySelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCategorySelection;
                InventorySlotSelection.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventorySlotSelection;
                InventorySlotSelection.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventorySlotSelection;
                InventorySlotSelection.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInventorySlotSelection;
                InvItemInteraction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInvItemInteraction;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                OnA.started += instance.OnOnA;
                OnA.performed += instance.OnOnA;
                OnA.canceled += instance.OnOnA;
                OnX.started += instance.OnOnX;
                OnX.performed += instance.OnOnX;
                OnX.canceled += instance.OnOnX;
                OnB.started += instance.OnOnB;
                OnB.performed += instance.OnOnB;
                OnB.canceled += instance.OnOnB;
                OnLT.started += instance.OnOnLT;
                OnLT.performed += instance.OnOnLT;
                OnLT.canceled += instance.OnOnLT;
                OnRB.started += instance.OnOnRB;
                OnRB.performed += instance.OnOnRB;
                OnRB.canceled += instance.OnOnRB;
                OnRT.started += instance.OnOnRT;
                OnRT.performed += instance.OnOnRT;
                OnRT.canceled += instance.OnOnRT;
                LeftStick.started += instance.OnLeftStick;
                LeftStick.performed += instance.OnLeftStick;
                LeftStick.canceled += instance.OnLeftStick;
                CategorySelection.started += instance.OnCategorySelection;
                CategorySelection.performed += instance.OnCategorySelection;
                CategorySelection.canceled += instance.OnCategorySelection;
                InventorySlotSelection.started += instance.OnInventorySlotSelection;
                InventorySlotSelection.performed += instance.OnInventorySlotSelection;
                InventorySlotSelection.canceled += instance.OnInventorySlotSelection;
                InvItemInteraction.started += instance.OnInvItemInteraction;
                InvItemInteraction.performed += instance.OnInvItemInteraction;
                InvItemInteraction.canceled += instance.OnInvItemInteraction;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // Player1
    private readonly InputActionMap m_Player1;
    private IPlayer1Actions m_Player1ActionsCallbackInterface;
    private readonly InputAction m_Player1_OnA;
    private readonly InputAction m_Player1_OnX;
    private readonly InputAction m_Player1_OnB;
    private readonly InputAction m_Player1_Move;
    private readonly InputAction m_Player1_Collect;
    private readonly InputAction m_Player1_Attack;
    private readonly InputAction m_Player1_Dodge;
    private readonly InputAction m_Player1_Shop;
    private readonly InputAction m_Player1_CategorySelection;
    private readonly InputAction m_Player1_ItemSelection;
    private readonly InputAction m_Player1_BuyItem;
    private readonly InputAction m_Player1_InventoryItemSelection;
    private readonly InputAction m_Player1_InvItemInteraction;
    private readonly InputAction m_Player1_PlaceTrap;
    private readonly InputAction m_Player1_CancelTrapPlacing;
    private readonly InputAction m_Player1_Guard;
    public struct Player1Actions
    {
        private PlayerInputs m_Wrapper;
        public Player1Actions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @OnA => m_Wrapper.m_Player1_OnA;
        public InputAction @OnX => m_Wrapper.m_Player1_OnX;
        public InputAction @OnB => m_Wrapper.m_Player1_OnB;
        public InputAction @Move => m_Wrapper.m_Player1_Move;
        public InputAction @Collect => m_Wrapper.m_Player1_Collect;
        public InputAction @Attack => m_Wrapper.m_Player1_Attack;
        public InputAction @Dodge => m_Wrapper.m_Player1_Dodge;
        public InputAction @Shop => m_Wrapper.m_Player1_Shop;
        public InputAction @CategorySelection => m_Wrapper.m_Player1_CategorySelection;
        public InputAction @ItemSelection => m_Wrapper.m_Player1_ItemSelection;
        public InputAction @BuyItem => m_Wrapper.m_Player1_BuyItem;
        public InputAction @InventoryItemSelection => m_Wrapper.m_Player1_InventoryItemSelection;
        public InputAction @InvItemInteraction => m_Wrapper.m_Player1_InvItemInteraction;
        public InputAction @PlaceTrap => m_Wrapper.m_Player1_PlaceTrap;
        public InputAction @CancelTrapPlacing => m_Wrapper.m_Player1_CancelTrapPlacing;
        public InputAction @Guard => m_Wrapper.m_Player1_Guard;
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer1Actions instance)
        {
            if (m_Wrapper.m_Player1ActionsCallbackInterface != null)
            {
                OnA.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnA;
                OnA.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnA;
                OnA.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnA;
                OnX.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnX;
                OnX.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnX;
                OnX.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnX;
                OnB.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnB;
                OnB.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnB;
                OnB.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnOnB;
                Move.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnMove;
                Collect.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCollect;
                Collect.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCollect;
                Collect.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCollect;
                Attack.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                Attack.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                Attack.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnAttack;
                Dodge.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDodge;
                Dodge.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDodge;
                Dodge.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnDodge;
                Shop.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShop;
                Shop.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShop;
                Shop.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnShop;
                CategorySelection.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCategorySelection;
                CategorySelection.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCategorySelection;
                CategorySelection.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCategorySelection;
                ItemSelection.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnItemSelection;
                ItemSelection.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnItemSelection;
                ItemSelection.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnItemSelection;
                BuyItem.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBuyItem;
                BuyItem.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBuyItem;
                BuyItem.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnBuyItem;
                InventoryItemSelection.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInventoryItemSelection;
                InventoryItemSelection.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInventoryItemSelection;
                InventoryItemSelection.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInventoryItemSelection;
                InvItemInteraction.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInvItemInteraction;
                InvItemInteraction.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnInvItemInteraction;
                PlaceTrap.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPlaceTrap;
                PlaceTrap.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPlaceTrap;
                PlaceTrap.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnPlaceTrap;
                CancelTrapPlacing.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCancelTrapPlacing;
                CancelTrapPlacing.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCancelTrapPlacing;
                CancelTrapPlacing.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnCancelTrapPlacing;
                Guard.started -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGuard;
                Guard.performed -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGuard;
                Guard.canceled -= m_Wrapper.m_Player1ActionsCallbackInterface.OnGuard;
            }
            m_Wrapper.m_Player1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                OnA.started += instance.OnOnA;
                OnA.performed += instance.OnOnA;
                OnA.canceled += instance.OnOnA;
                OnX.started += instance.OnOnX;
                OnX.performed += instance.OnOnX;
                OnX.canceled += instance.OnOnX;
                OnB.started += instance.OnOnB;
                OnB.performed += instance.OnOnB;
                OnB.canceled += instance.OnOnB;
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
                Guard.started += instance.OnGuard;
                Guard.performed += instance.OnGuard;
                Guard.canceled += instance.OnGuard;
            }
        }
    }
    public Player1Actions @Player1 => new Player1Actions(this);

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Newaction;
    public struct NewactionmapActions
    {
        private PlayerInputs m_Wrapper;
        public NewactionmapActions(PlayerInputs wrapper) { m_Wrapper = wrapper; }
        public InputAction @Newaction => m_Wrapper.m_Newactionmap_Newaction;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                Newaction.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                Newaction.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
                Newaction.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnNewaction;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Newaction.started += instance.OnNewaction;
                Newaction.performed += instance.OnNewaction;
                Newaction.canceled += instance.OnNewaction;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
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
        void OnOnA(InputAction.CallbackContext context);
        void OnOnX(InputAction.CallbackContext context);
        void OnOnB(InputAction.CallbackContext context);
        void OnOnLT(InputAction.CallbackContext context);
        void OnOnRB(InputAction.CallbackContext context);
        void OnOnRT(InputAction.CallbackContext context);
        void OnLeftStick(InputAction.CallbackContext context);
        void OnCategorySelection(InputAction.CallbackContext context);
        void OnInventorySlotSelection(InputAction.CallbackContext context);
        void OnInvItemInteraction(InputAction.CallbackContext context);
    }
    public interface IPlayer1Actions
    {
        void OnOnA(InputAction.CallbackContext context);
        void OnOnX(InputAction.CallbackContext context);
        void OnOnB(InputAction.CallbackContext context);
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
        void OnGuard(InputAction.CallbackContext context);
    }
    public interface INewactionmapActions
    {
        void OnNewaction(InputAction.CallbackContext context);
    }
}
