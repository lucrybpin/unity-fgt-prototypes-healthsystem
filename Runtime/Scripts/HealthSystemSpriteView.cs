using UnityEngine;

namespace FGT.Prototypes.HealthSystem
{
    public class HealthSystemSpriteView : HealthSystemView
    {
        [SerializeField] GameObject _container;
        [SerializeField] Transform _fillPivot;

        public override void SetPercentage(float percentage)
        {
            if (percentage < 0f || percentage > 1f)
                return;

            _fillPivot.localScale = new Vector3(percentage, _fillPivot.localScale.y, _fillPivot.localScale.z);
        }

        public override void Show()
        {
            _container.SetActive(true);
        }

        public override void Hide()
        {
            _container.SetActive(false);
        }
    }
}
