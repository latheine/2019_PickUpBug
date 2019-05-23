using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Visitor : MonoBehaviour
{
    //参照　https://en.wikipedia.org/wiki/Visitor_pattern#C#_example　(Wikipedia [Visitor Pattern C#])
    public abstract void Visit(ItemAcceptor acceptor);
    public abstract void Visit(LogsAcceptor accsptor);
    public abstract void Visit(DoorAcceptor acceptor);
}
