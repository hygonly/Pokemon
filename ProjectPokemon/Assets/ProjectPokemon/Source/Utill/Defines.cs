using UnityEngine;

public class Defines
{
    public enum UserSettingType
    {
        None = 0,
    }

    public enum MoveType
    {
        None = 0,
        Normal = 1,     //노말
        Fighting = 2,   //격투
        Flying = 3,     //비행
        Poison = 4,     //독
        Ground = 5,     //땅
        Rock = 6,       //바위
        Bug = 7,        //벌레
        Ghost = 8,      //고스트
        Steel = 9,      //강철
        Fire = 10,      //불
        Water = 11,     //물
        Grass = 12,     //풀
        Electric = 13,   //전기
        Psychic = 14,   //에스퍼
        Ice = 15,       //얼음
        Dragon = 16,    //드래곤
        Dark = 17,      //악
    }

    public enum NatureType
    {
        Lonely,     //외로움       (공업/방떨)
        Admant,     //고집        (공업/특공떨)
        Naughty,    //개구쟁이      (공업/특방떨)
        Brave,      //용감한       (공업/슾떨)
        Bold,       //대담        (방업/공떨)
        Impish,     //장난구러기     (방업/특공떨)
        Lax,        //촐랑        (방업/특방떨)
        Relaxed,    //무사태평     (방업/슾떨)
        Modest,     //조심        (특공업/공떨)
        Mild,       //의젓        (특공업/방떨)
        Rash,       //덜렁        (특공업/특방떨)
        Quiet,      //냉정        (특공업/슾떨)
        Calm,       //차분        (특방업/공떨)
        Gentle,     //얌전        (특방업/방떨)
        Careful,    //신중        (특방업/특공떨)
        Sassy,      //건방        (특방업/슾떨)
        Timid,      //겁쟁이       (슾업/공떨)
        Hasty,      //성급        (슾업/방떨)
        Jolly,      //명랑        (슾업/특공떨)
        Naive,      //천진난만      (슾업/특방떨)
        Bashful,    //수줍음       (무보정)
        Hardy,      //노력        (무보정)
        Docile,     //온순        (무보정)
        Quirky,     //변덕        (무보정)
        Serious,    //성실        (무보정)
    }

    public enum SceneType
    {
        StartScene,
        ResourceDownloadScene,
        GameScene
    }

    public enum UnitType
    {
        Player,
        Npc,
        AI,
        Pokemon,
    }

    public enum ObjectState
    {
        None,
        Idle,
        Move,
        Attack,
        Hit,
        Die
    }

    public enum Direction
    {
        Front,
        Right,
        Left,
        Down,
    }

    public enum SkillType
    {
        Active,     //사용 기술
        Passive,    //특성
    }

    public enum SkillArgType
    {
        Damage,                 //데미지
        Heal,                   //힐
        DotDamage,              //도트 데미지
        DotHeal,                //힐
        ConditionStatus,        //상태이상
        Binding,                //교체불가
        Embargo,                //금제 (지닌물건 사용 금지)
        Dead,                   //확정 죽음 (길동무, 멸망의 노래, 자폭 등)
        FixedHp,                //체력 고정 (%) ex) 옹골참, 배북
        Shield,                 //방어, 판별 등
        ExecuteAfterTurn,       //N턴후 실행
        DurationTurns,          //N턴동안 실행
    }

    public enum SkillCategoryType
    {
        Physical,       //물리
        Special,        //특수
        Status,         //변화기
    }

    public enum StatType
    {
        None,   //없음
        Hp,     //체력
        Atk,    //공격
        SpAtk,  //특공
        Def,    //방
        SpDef,  //특방
        Speed,  //스피드
    }

    public enum RankType
    {
        Atk,        //공
        SpAtk,      //특공
        Def,        //방
        SpDef,      //특방
        Speed,      //스피드
        Critical,   //급소
        Evasion,    //회피
        Accuracy    //명중
    }

    public enum ConditionStatusType
    {
        Poison,     //독
        Burn,       //화상
        Paralysis,  //마비
        Sleep,      //잠듦
        Freeze,     //얼음
        Confusion,  //혼란
        Flinch,     //풀죽음
        Attract,    //헤롱헤롱
    }

    public enum TargetType
    {
        Enemy,      //적
        Self,       //나
        Ally,       //아군
        All,        //전체 (나를 제외한)
    }

    public enum EffectActionState
    {
        Enter,
        Update,
        Exit,
        Finish
    }
}
