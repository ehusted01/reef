using System;
using Xunit;
using Microsoft.Xna.Framework;
using reef.shared;
using reef.shared.Models;

namespace reef.testing {
  class TestObj : GameObj {
    public int UpdateCount = 0;
    public override void Update(GameTime time) {
      UpdateCount++;
    }
  }

  public class ObjCollectionTests {
    [Fact]
    public void AddObj() {
      var objs = new GameObjs();
      var obj = new TestObj();

      Assert.True(objs.Objs.Count == 0);
      objs.Add(obj);
      Assert.True(objs.Objs.Count == 1);
    }

    [Fact]
    public void RemoveObj() {
      var objs = new GameObjs();
      var obj = new TestObj();

      Assert.True(objs.Objs.Count == 0);
      objs.Add(obj);
      objs.Remove(obj);
      Assert.True(obj.UpdateCount == 0);
    }

    [Fact]
    public void UpdateObjs() {
      var objs = new GameObjs();
      var obj = new TestObj();
      var gameTime = new GameTime();
      objs.Add(obj);

      Assert.True(obj.UpdateCount == 0);
      objs.Update(gameTime);
      Assert.True(objs.Objs.Count == 1);
    }
  }
}
