using Meta.Core.IO;
using Meta.Editor.Controls;
using Meta.Editor.Windows;
using MetaEditor;
using System;

#nullable enable
namespace Meta.Editor.Extensions
{
  public static class GameUnlocker
  {
    public static bool UnlockWWE2K23()
    {
      if (App.GameActive)
      {
        MetaTaskWindow.Show("Unlocking everything", "This may take a minute, remember to save after", (MetaTaskCallback) (task =>
        {
          Mem mem = new Mem();
          if (!mem.OpenProcess(App.CurrentGame.Exe))
            return;
          UIntPtr num1 = (UIntPtr) (ulong) (long) mem.mProc.MainModule.BaseAddress + App.CurrentGame.Memory.Regions["Unlock"];
          int num2 = App.CurrentGame.Memory.Regions["UnlockTotal"] / 8;
          for (int index = 0; index < num2; ++index)
            mem.WriteBytes(num1 + 6 + 8 * index, new byte[1]
            {
              (byte) 3
            });
          mem.CloseProcess();
          App.Logger.Log("WWE 2K23 has been unlocked", Array.Empty<object>());
        }));
        return true;
      }
      int num = (int) MetaMessageBox.Show("Error: The game is not running");
      return false;
    }
  }
}
