using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using reef.shared.Models.Device;

namespace reef.testing {
    public class DeviceActivityTests {

        private static readonly AppInfo App1 = new AppInfo("App1", "Package1");
        private static readonly AppInfo App2 = new AppInfo("App2", "Package2");

        private static readonly double Usage1 = 0.2;
        private static readonly double Usage2 = 0.3;

        [Fact]
        public void TestTracking() {
            DeviceActivity devAct = new DeviceActivity();
            Assert.False(devAct.IsTracked(App1));
            Assert.False(devAct.IsTracked(App2));

            devAct.Track(App1);
            Assert.True(devAct.IsTracked(App1));
            devAct.Track(App2);
            Assert.True(devAct.IsTracked(App2));

            devAct.UnTrack(App1);
            Assert.False(devAct.IsTracked(App1));
            devAct.UnTrack(App2);
            Assert.False(devAct.IsTracked(App2));
        }

        [Fact]
        public void TestDoubleTrack() {
            DeviceActivity devAct = new DeviceActivity();
            Assert.False(devAct.IsTracked(App1));
            devAct.Track(App1);
            devAct.Track(App1);
            Assert.True(devAct.IsTracked(App1));
        }

        [Fact]
        public void TestDoubleUnTrack() {
            DeviceActivity devAct = new DeviceActivity();
            devAct.Track(App1);
            Assert.True(devAct.IsTracked(App1));

            devAct.UnTrack(App1);
            devAct.UnTrack(App1);
            Assert.False(devAct.IsTracked(App1));
        }

        [Fact]
        public void TestGetProblemApps() {
            DeviceActivity devAct = new DeviceActivity();
            Assert.Empty(devAct.GetProblemApps());

            devAct.Track(App1);
            devAct.Track(App2);

            Assert.Equal(2, devAct.GetProblemApps().Count);
            Assert.Contains<AppInfo>(App1, devAct.GetProblemApps());
            Assert.Contains<AppInfo>(App2, devAct.GetProblemApps());
        }

        [Fact]
        public void TestUsageExceptions() {
            DeviceActivity devAct = new DeviceActivity();
            Assert.Throws<ArgumentException>(() => devAct.GetPastStats(App1, 0));
            devAct.Track(App1);
            Assert.Throws<ArgumentException>(() => devAct.GetPastStats(App1, -1));
        }

        [Fact]
        public void TestUsage() {
            DeviceActivity devAct = new DeviceActivity();
            devAct.Track(App1);
            devAct.Track(App2);

            Assert.Equal(AppActivityLog.NO_DATA, devAct.GetPastStats(App1, 0));
            Assert.Equal(AppActivityLog.NO_DATA, devAct.GetPastStats(App2, 0));

            devAct.RecordUsage(2, mockResponse);
            Assert.Equal(0, devAct.GetPastStats(App1, 0));
            Assert.Equal(0, devAct.GetPastStats(App2, 0));

            devAct.RecordUsage(1, mockResponse);
            Assert.Equal(Usage1, devAct.GetPastStats(App1, 0));
            Assert.Equal(0, devAct.GetPastStats(App2, 0));

            Assert.Equal(0, devAct.GetPastStats(App1, 1));
            Assert.Equal(0, devAct.GetPastStats(App2, 1));

            devAct.RecordUsage(0, mockResponse);
            Assert.Equal(Usage1, devAct.GetPastStats(App1, 0));
            Assert.Equal(Usage2, devAct.GetPastStats(App2, 0));

            Assert.Equal(Usage1, devAct.GetPastStats(App1, 1));
            Assert.Equal(0, devAct.GetPastStats(App2, 1));
            Assert.Equal(0, devAct.GetPastStats(App1, 2));
            Assert.Equal(0, devAct.GetPastStats(App2, 2));
        }

        private static IDictionary<String, double> mockResponse(long time) {
            IDictionary<String, double> resp = new Dictionary<String, double>();
            if (time < 2) {
                resp.Add(App1.GetPackage(), Usage1);
            }
            if (time < 1) {
                resp.Add(App2.GetPackage(), Usage2);
            }
            return resp;
        }
    }
}
