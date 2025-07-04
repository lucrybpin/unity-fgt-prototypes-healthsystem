# FGT - Prototypes - HealthSystem

A fast and lightweight prototyping tool for adding a simple and flexible health system to your game objects.

Ideal for use in early-stage prototypes involving characters, NPCs, creatures, buildings, monsters, and more.


## How to use

### 1. Add the `HealthSystem` field to your MonoBehaviour class:

```csharp
[SerializeField] HealthSystem _health;
```

### 2. Initialize the `HealthSystem` with a max health value:

```csharp
_health = new HealthSystem(100);
```

### 3. Use the available methods to control health:

| Method                   | Description                                               |
|--------------------------|-----------------------------------------------------------|
| `ReceiveDamage(foat amount)` | Reduces current health by the specified amount.       |
| `Heal(float amount)`         | Restores health by the specified amount.              |
| `Revive()`                 | Restores health if the entity is currently at 0 HP.   |
| `SetMax(float max)`          | Changes the maximum health value.                     |
| `GetCurrent()`             | Returns the current health value.                     |
| `GetMax()`                 | Returns the maximum health value.                     |

---

## 📦 Installation

You can import this system as a Unity package via UPM.

[Github] - Button "<> Code" -> Tab Local -> Tab HTTPS -> Copy url displayed in the field.

[Unity] - Window -> Package Manager -> + -> Add Package from git URL... -> Paste the github https code.