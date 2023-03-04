using System;
using System.Threading.Tasks;

public interface IPlayerDataProvider
{
    Task<PlayerData> GetOrCreatePlayerData(string loginname);
    Task SavePlayerData(string loginname, PlayerData data);
}