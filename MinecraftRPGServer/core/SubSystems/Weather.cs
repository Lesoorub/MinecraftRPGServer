using Packets.Play;

public class Weather
{
    public bool IsRaining { get; private set; }
    public float IsThunder { get; private set; }
    public float Power { get; private set; }
    Player pl;

    public Weather(Player player)
    {
        pl = player;
    }

    public void SetRaining(bool isRainging, float power = 0)
    {
        if (this.IsRaining == isRainging)
        {
            if (Power == power) return;

            Power = power;
            pl.api.SendChangeGameState(ChangeGameState.ReasonType.RainLevelChange, power);
            return;
        }
        this.IsRaining = isRainging;
        if (IsRaining)
            pl.api.SendChangeGameState(ChangeGameState.ReasonType.BeginRaining, 0);
        else
            pl.api.SendChangeGameState(ChangeGameState.ReasonType.EndRaining, 0);
    }
    public void SetThunder(float power)
    {
        if (!IsRaining)
            SetRaining(true);
        Power = power;
        pl.api.SendChangeGameState(ChangeGameState.ReasonType.ThunderLevelChange, power);
    }
}