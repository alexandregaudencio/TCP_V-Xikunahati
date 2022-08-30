using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Game
{
    public abstract class ViewHandler : MonoBehaviour
    {
        public virtual void Hide() => gameObject.SetActive(false);
        public virtual void Show() => gameObject.SetActive(true);

    }

}
