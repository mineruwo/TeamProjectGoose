using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Job
{
    public IEnumerator GooseGetItems();
    public void GooseInCollider();
    public void ObjectsOn();
}
