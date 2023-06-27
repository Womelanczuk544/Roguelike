using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Item : MonoBehaviour
{
    protected GameObject player;

    public abstract int classId();
    public abstract void onAdd();
    public abstract void onRemove();
    public abstract void triggerEffect();
}
