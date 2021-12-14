using System;
using WormsWorld.WorldSimulator;

namespace WormsWorld.FileWriter
{
    public interface IFileWriter : IDisposable
    {
        void WriteHistory(WorldService worldService);
    }
}