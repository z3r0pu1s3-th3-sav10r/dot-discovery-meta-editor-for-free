using DiscordRPC;
using DiscordRPC.Events;

#nullable enable
public sealed class DiscordRPCManager
{
  private static DiscordRpcClient client;

  public DiscordRPCManager() => this.Initialize();

  public void Initialize()
  {
    DiscordRPCManager.client = new DiscordRpcClient("1235982522706563214");
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: reference to a compiler-generated field
    // ISSUE: method pointer
    DiscordRPCManager.client.OnReady += DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9__2_0 ?? (DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9__2_0 = new OnReadyEvent((object) DiscordRPCManager.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitialize\u003Eb__2_0)));
    DiscordRPCManager.client.Initialize();
  }

  public void SetPresence(string state)
  {
    RichPresence richPresence1 = new RichPresence();
    ((BaseRichPresence) richPresence1).State = state;
    ((BaseRichPresence) richPresence1).Details = "DISCOVERY ®";
    ((BaseRichPresence) richPresence1).Assets = new Assets()
    {
      LargeImageKey = "https://pbs.twimg.com/profile_images/1740042200166068225/lcLreexT_400x400.png",
      LargeImageText = "http://www.discovery.onl"
    };
    richPresence1.Buttons = new Button[2]
    {
      new Button()
      {
        Label = "DISCOVERY Website",
        Url = "https://discovery.onl/"
      },
      new Button()
      {
        Label = "DISCOVERY Patreon",
        Url = "http://www.patreon.com/dotdiscovery"
      }
    };
    RichPresence richPresence2 = richPresence1;
    DiscordRPCManager.client.SetPresence(richPresence2);
  }

  public void Shutdown() => DiscordRPCManager.client.Dispose();
}
