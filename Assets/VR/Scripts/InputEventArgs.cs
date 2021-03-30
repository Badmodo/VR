using UnityEngine;
using UnityEngine.Events;
using Valve.VR;
using Serializable = System.SerializableAttribute;

namespace BreadandButter.VR
{
    [Serializable]
    public class VRInputEvent : UnityEvent<InputEventArgs> { }

    [Serializable]
    public class InputEventArgs
    {
        public VRController controller;

        public SteamVR_Input_Sources sources;

        public Vector2 touchpadAxis;

        public InputEventArgs(VRController _controller, SteamVR_Input_Sources _source, Vector2 _touchpadAxis)
        {
            controller = _controller;
            sources = _source;
            touchpadAxis = _touchpadAxis;
        }
    }
}