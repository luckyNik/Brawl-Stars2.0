using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimDatabase
{
    UnitsAnimationReference Get(int id);
}