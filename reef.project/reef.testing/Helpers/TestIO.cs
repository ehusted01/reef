using System;
using System.IO;
using System.Reflection;
using reef.shared.Models.Device;
namespace reef.testing.Helpers {
  public class TestIO : GameIO {
    public TestIO() {
    }

    private static string FixPath(string path) {
      var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
      var fix = Path.Combine(dir, path);
      return fix;
    }

    public override void ReadLocalJsonFile(string filePath, Action<StreamReader> cb) {
      using var reader = new StreamReader(FixPath(filePath));
      cb(reader);
    }
  }
}
