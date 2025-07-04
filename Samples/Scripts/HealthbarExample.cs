using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace FGT.Prototypes.HealthSystem.Demo
{
    public class HealthbarExample : MonoBehaviour
    {
        [SerializeField] Mushroom _mushroom;
        [SerializeField] Button _buttonHit;
        [SerializeField] Button _buttonHeal;
        [SerializeField] Button _buttonRevive;
        [SerializeField] Button _buttonChangeMaxHealth;
        [SerializeField] Button _buttonDmgOverTime;
        [SerializeField] TMP_Text _lifeText;
        void Start()
        {
            _mushroom.OnStart();

            _buttonHit.onClick.AddListener(() => { _mushroom.Hit(12); });
            _buttonHeal.onClick.AddListener(() => { _mushroom.Heal(12); });
            _buttonRevive.onClick.AddListener(() => { _mushroom.Revive(0.3f); });
            _buttonDmgOverTime.onClick.AddListener(() => { new DamageOverTime(_mushroom, 5, 4); });
            _buttonChangeMaxHealth.onClick.AddListener(() => { _mushroom.ChangeMaxHealth(Random.Range(100f, 200f)); });

            _mushroom.OnHealthChanged += (x) => { _lifeText.text = $"{_mushroom.GetCurrentHealth().ToString("F0")} / {_mushroom.GetMaxHealth().ToString("F0")}"; };
            _mushroom.OnRevive += () => { _lifeText.text = $"{_mushroom.GetCurrentHealth().ToString("F0")} / {_mushroom.GetMaxHealth().ToString("F0")}"; };
        }
    }
}