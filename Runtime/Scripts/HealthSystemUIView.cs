using UnityEngine;

namespace FGT.Prototypes.HealthSystem
{
    public class HealthSystemUIView : HealthSystemView
    {
        [SerializeField] GameObject _container;
        [SerializeField] Transform _fill;

        public override void SetPercentage(float percentage)
        {
            if (percentage < 0f || percentage > 1f)
                return;

            _fill.localScale = new Vector3(percentage, _fill.localScale.y, _fill.localScale.z);
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
