using System;
using Xunit;
using reef.testing.Helpers;
using reef.shared.Controllers;
using reef.shared.Models.Fishes;
using System.IO;

namespace reef.testing {
  public class FishLibraryTests {

    [Fact]
    public void ReadData() {
      var testIO = new TestIO();
      testIO.ReadLocalJsonFile(TestConfig.FishFile, (StreamReader reader) => {
        Assert.True(reader != null);
      });
    }

    [Fact]
    public void PopulateData() {
      var testIO = new TestIO();
      var library = new FishLibrary();
      var controller = new FishController(library);
      controller.Load(testIO, TestConfig.FishFile);

      Assert.True(library.fishCount() > 0);
    }

  }
}
