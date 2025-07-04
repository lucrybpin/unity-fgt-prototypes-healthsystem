using System;
using UnityEngine;

namespace FGT.Prototypes.HealthSystem
{
    [Serializable]
    public abstract class HealthSystemView : MonoBehaviour
    {
        public abstract void SetPercentage(float percentage);
        public abstract void Show();
        public abstract void Hide();
    }
}
