namespace MyGame.Core;

public record GoInfo(string Colony, string Heap, int Warrios, int Workers, int Special)
{
    public override string ToString()
    {
        return $"- {Colony}, отправились: рабочих={Workers}, воинов={Warrios}, особых={Special} на {Heap}";
    }
}

public record BackInfo(
    string Colony,
    int TwigsCount, int PebbliesCount, int LeafsCount, int DewdropsCount,
    int WarriosBack, int WorkersBack, int SpecialBack,
    int WarriosLoss, int WorkersLoss, int SpecialLoss,
    string LarvaeInfo)
{
    public override string ToString()
    {
        return $@"{Colony}, вернулись:

--- р={WorkersBack}, в={WarriosBack}, о={SpecialBack}

--- Добыто ресурсов: к={PebbliesCount}, л={LeafsCount}, в={TwigsCount}, р={DewdropsCount}

--- Потери: р={WorkersLoss}, в={WarriosLoss}, о={SpecialLoss}

{LarvaeInfo}";
    }
}

public class HikeInfo
{
    public HikeInfo(List<GoInfo> goInfos, List<BackInfo> backInfos)
    {
        GoInfos = goInfos;
        BackInfos = backInfos;
    }

    public readonly List<GoInfo> GoInfos;
    public readonly List<BackInfo> BackInfos;
}
