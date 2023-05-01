using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour
{
    protected GameObject player;
    // Start is called before the first frame update
    public abstract void onAdd();
    public abstract void onRemove();
    public abstract void triggerEffect();
}
