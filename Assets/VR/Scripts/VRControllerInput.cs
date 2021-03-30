using UnityEngine;
using Valve.VR;

namespace BreadandButter.VR
{
    public class VRControllerInput : MonoBehaviour
    {
        public VRController Controller => controller;
        #region Properties
        public VRInputEvent OnPointerPressed => onPointerPressed;
        public VRInputEvent OnPointerReleased => onPointerReleased;
        public VRInputEvent OnTeleportPressed => onTeleportPressed;
        public VRInputEvent OnTeleportReleased => onTeleportReleased;
        public VRInputEvent OnUsePressed => onUsePressed;
        public VRInputEvent OnUseRealeased => onUseRealeased;
        public VRInputEvent OnGrabPressed => onGrabPressed;
        public VRInputEvent OnGrabReleased => onGrabReleased;
        public VRInputEvent OnTouchPadAxisChanged => onTouchPadAxisChanged;
        #endregion

        #region Steam Actions (the input actions)
        [Header("Steam Actions")]
        [SerializeField] private SteamVR_Action_Boolean pointer;
        [SerializeField] private SteamVR_Action_Boolean teleport;
        [SerializeField] private SteamVR_Action_Boolean use;
        [SerializeField] private SteamVR_Action_Boolean grab;
        [SerializeField] private SteamVR_Action_Vector2 touchpadAxis;
        #endregion

        #region Unity Input Events
        [Header("Unity Actions")]
        [SerializeField] private VRInputEvent onPointerPressed = new VRInputEvent();
        [SerializeField] private VRInputEvent onPointerReleased = new VRInputEvent();
        [SerializeField] private VRInputEvent onTeleportPressed = new VRInputEvent();
        [SerializeField] private VRInputEvent onTeleportReleased = new VRInputEvent();
        [SerializeField] private VRInputEvent onUsePressed = new VRInputEvent();
        [SerializeField] private VRInputEvent onUseRealeased = new VRInputEvent();
        [SerializeField] private VRInputEvent onGrabPressed = new VRInputEvent();
        [SerializeField] private VRInputEvent onGrabReleased = new VRInputEvent();
        [SerializeField] private VRInputEvent onTouchPadAxisChanged = new VRInputEvent();
        #endregion

        #region Steam VR Input Callbacks
        private void OnPointerDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onPointerPressed.Invoke(GenerateArgs());
        private void OnPointerUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onPointerReleased.Invoke(GenerateArgs());
        private void OnTeleportDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onTeleportPressed.Invoke(GenerateArgs());
        private void OnTeleportUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onTeleportReleased.Invoke(GenerateArgs());
        private void OnUseDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onUsePressed.Invoke(GenerateArgs());
        private void OnUseUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onUseRealeased.Invoke(GenerateArgs());
        private void OnGrabDown(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onGrabPressed.Invoke(GenerateArgs());
        private void OnGrabUp(SteamVR_Action_Boolean _action, SteamVR_Input_Sources _source) => onGrabReleased.Invoke(GenerateArgs());
        private void OnTouchpadChanged(SteamVR_Action_Vector2 _action, SteamVR_Input_Sources _source, Vector2 _axis, Vector2 _delta) => OnTouchPadAxisChanged.Invoke(GenerateArgs());

        #endregion

        private VRController controller;

        public void Initialise(VRController _controller)
        {
            controller = _controller;

            pointer.AddOnStateDownListener(OnPointerDown, controller.InputSource);
            pointer.AddOnStateUpListener(OnPointerUp, controller.InputSource);
            teleport.AddOnStateDownListener(OnTeleportDown, controller.InputSource);
            teleport.AddOnStateUpListener(OnTeleportUp, controller.InputSource);
            grab.AddOnStateDownListener(OnGrabDown, controller.InputSource);
            grab.AddOnStateUpListener(OnGrabUp, controller.InputSource);
            use.AddOnStateDownListener(OnUseDown, controller.InputSource);
            use.AddOnStateUpListener(OnUseUp, controller.InputSource);
            touchpadAxis.AddOnChangeListener(OnTouchpadChanged, controller.InputSource);
        }

        private InputEventArgs GenerateArgs() => new InputEventArgs(controller, controller.InputSource, touchpadAxis.axis);
    }
}