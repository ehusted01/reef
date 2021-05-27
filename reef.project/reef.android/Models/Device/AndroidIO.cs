using System.IO;
using System.IO.IsolatedStorage;
using Android.App;
using Newtonsoft.Json;
using reef.shared.Models.Device;

namespace reef.android.Models.Device {
  public class AndroidIO : GameIO {
    private static readonly IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
    private static readonly JsonSerializer serializer = new JsonSerializer();

    public override StreamReader ReadLocalJsonFile(string filePath) {
      using var isoStream = Application.Context.Assets.Open("fish.json");
      StreamReader sr = new StreamReader(isoStream);
      return sr;
    }
  }
}
