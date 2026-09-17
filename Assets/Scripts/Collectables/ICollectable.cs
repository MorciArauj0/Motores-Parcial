using UnityEngine;

public interface ICollectable
{
    void Collect();
    ItemID ID { get; }
}
