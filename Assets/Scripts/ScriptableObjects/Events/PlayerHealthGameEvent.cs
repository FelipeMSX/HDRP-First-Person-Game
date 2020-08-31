using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScriptableObjects.Events
{

    [CreateAssetMenu(fileName = "New Player Health Event", menuName = "ScriptableObjects/New Player Health Event", order = 3)]
    public class PlayerHealthGameEvent : BaseGameEvent<Health>
    {
    }
}
