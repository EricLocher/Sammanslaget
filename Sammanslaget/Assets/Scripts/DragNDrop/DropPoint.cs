using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Drop
{
    public abstract class DropPoint : MonoBehaviour, IDropHandler
    {
        public abstract void OnDrop(PointerEventData eventData);
    }
}