using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITrap
{
    void Force(Collision others);
    void VFX(Collision others);
    void Damge(Collision others);
}
