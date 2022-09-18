using System;

public static class PlayerEvents {
    public static event Action OnWin;
    public static event Action<int> OnHeal;
    public static event Action<int> OnDamage;

    public static void OnWinCall() { OnWin?.Invoke(); }
    public static void OnHealCall(int hp) { OnHeal?.Invoke(hp); }
    public static void OnDamageCall(int hp) { OnDamage?.Invoke(hp); }

}
