using System;
using Xunit;
using reef.shared.Models;

namespace reef.testing {
  public class BasicTests {
    [Fact]
    public void BasicTest() {
      var res = 1 + 1;
      Assert.True(res == 2);
    }

    [Fact]
    public void WorldTest() {

      // Can we make a new world
      var world = new World();
      Assert.NotNull(world);

      // This should throw an exception. Singleton pattern.
      Assert.Throws<Exception>(() => new World());
    }
  }
}
