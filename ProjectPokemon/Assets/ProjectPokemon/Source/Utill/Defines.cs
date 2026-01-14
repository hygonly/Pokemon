using UnityEngine;

public class Defines
{
    public enum PokemonType
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
        Eletric = 13,   //전기
        Phychic = 14,   //에스퍼
        Ice = 15,       //얼음
        Dragon = 16,    //드래곤
        Drak = 17,      //악
    }

    public enum SceneType
    {
        StartScene,
        ResourceDownloadScene,
        GameScene
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
        Hp,     //체력
        Atk,    //공격
        SpAtk,  //특공
        Def,    //방
        SpDef,  //특방
        Speed,  //스피드
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
}
