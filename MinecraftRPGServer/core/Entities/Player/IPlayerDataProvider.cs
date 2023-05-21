using System;
using System.Threading.Tasks;
using NBT;

public interface IPlayerDataProvider
{
    Task<NBTTag> GetOrCreatePlayerData(string loginname);
    Task SavePlayerData(string loginname, NBTTag data);
}