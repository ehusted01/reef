using System;
using Xunit;
using reef.shared.Models;

namespace reef.testing {
  public class FishCollectionTests {
    [Fact]
    public void AddFish() {
      var fish = new FishCollection();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount);
      fish.AddFish();
      Assert.True(fish.FishCount == 2);
      Assert.True(fish.FishUpdated = true);
    }

    [Fact]
    public void RemoveFish() {
      var fish = new FishCollection();
      Assert.True(fish.FishCount == FishCollection.DefaultFishCount);
      fish.RemoveFish();
      Assert.True(fish.FishCount == 0);
      Assert.True(fish.FishUpdated = true);
    }
  }
}
