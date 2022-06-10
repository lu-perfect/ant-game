namespace MyGame.Core;

public class AntLarva
{
    public readonly Type IAm;

    private int _daysBeforeHatching;
    private readonly AntQueen _mother;

    private const int ChanceBecomeQueen = 10;

    public AntLarva(AntQueen mother, int growthCycle, bool iCanBecomeAQueen)
    {
        _daysBeforeHatching = growthCycle;
        _mother = mother;

        if (iCanBecomeAQueen && RandomHelper.GetInt32(100) < ChanceBecomeQueen)
        {
            IAm = typeof(AntQueen);
        } 
        else
        {
            IAm = InsectFactory.GetRandomLarvaType();
        }
    }

    public void Grow()
    {
        if (--_daysBeforeHatching == 0)
            _mother.KickMother(this);
    }
}
