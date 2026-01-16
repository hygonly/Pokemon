using UnityEngine;

public static partial class ExtendedHelper
{
    public static float SecondsPerMillis(this int seconds) => (float)seconds * 0.001f;
    public static int MillisPerSecond(this int millis) => millis * 1000;
    public static int MillisPerSecond(this float millis) => (int)(millis * 1000f);
    public static int MillisPerSecond(this double millis) => (int)(millis * 1000d);

    public static long CaculateDamage(PokemonInfoScript script)
    {
        //(데미지 = (((((((레벨 × 2 ÷ 5) +2) × 위력 × 특수공격 ÷ 50) ÷ 특수방어) × Mod1) +2) × [[급소]] × Mod2 ×  랜덤수 ÷ 100) × 자속보정 × 타입상성1 × 타입상성2 × Mod3)

        //(특수공격 = 스탯 × [[랭크 (상태변화)|랭크]]보정 × [[특성]]보정 × [[도구]]보정)

        //(특수방어 = 스탯 × [[랭크]]보정 × Mod × 자폭보정)

        //Mod1 = [[화상]] × [[리플렉터]]·[[빛의장막]] × [[더블배틀]] × [[날씨]] × [[타오르는불꽃]]

        //Mod2
        //생명의구슬을 장착하면 1.3
        //메트로놈을 장착하고 같은 기술을 써나가면 1, 1.1, 1.2, 1.3, ..., 2
        //그 외는 1

        //(Mod3 = [[하드록]]·[[필터]] × [[달인의띠]] × [[색안경]] × 타입별위력반감[[열매]])

        return 0;
    }

    public static long GetModifierOne()
    {
        return 0;
    }

    public static long GetModifierTwo()
    {
        return 0;
    }

    public static long GetModifierThree()
    {
        return 0;
    }
}
