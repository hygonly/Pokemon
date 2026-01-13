using UnityEngine;

public class Defines
{
    public enum PokemonType
    {
        None,
        Normal,
        Fighting,
        Flying,
        Poison,
        Ground,
        Rock,
        Bug,
        Ghost,
        Steel,
        Fire,
        Water,
        Grass,
        Eletric,
        Phychic,
        Ice,
        Dragon,
        Drak,
        Fairy
    }

    public enum SceneType
    {
        Start,
        ResourceDownload,
        Game
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
}
