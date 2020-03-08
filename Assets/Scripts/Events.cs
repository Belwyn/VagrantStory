using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Belwyn.Events {

    public class IntEvent : UnityEvent<int> { }
    public class FloatEvent : UnityEvent<float> { }
    public class BoolEvent : UnityEvent<bool> { }
    public class StringEvent : UnityEvent<string> { }
    public class Vector2Event : UnityEvent<Vector2> { }
    public class Vector3Event : UnityEvent<Vector3> { }

    public class GameObjectEvent : UnityEvent<GameObject> { }
    public class BehaviourEvent : UnityEvent<MonoBehaviour> { }
    
}
