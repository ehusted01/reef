using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using reef.shared.Models.Device;

namespace reef.testing {
    /// <summary>
    /// Tests for DeviceActivity.
    /// </summary>
    public class DeviceActivityTests {

        /// <summary>
        /// Mock application 1
        /// </summary>
        private static readonly AppInfo App1 = new AppInfo("App1", "Package1");
        /// <summary>
        /// Mock application 2
        /// </summary>
        private static readonly AppInfo App2 = new AppInfo("App2", "Package2");

        /// <summary>
        /// Mock usage value for App1
        /// </summary>
        private static readonly double Usage1 = 0.2;
        /// <summary>
        /// Mock usage value for App2
        /// </summary>
        private static readonly double Usage2 = 0.3;

        /// <summary>
        /// Tests the ability of DeviceActivity to track and untrack problem apps.
        /// </summary>
        [Fact]
        public void TestTracking() {
            // Construct a DeviceActivity and assert that App1 and App2 are not tracked
            DeviceActivity devAct = new DeviceActivity();
            Assert.False(devAct.IsTracked(App1));
            Assert.False(devAct.IsTracked(App2));

            // Track App1 and App2 and assert that they are tracked
            devAct.Track(App1);
            Assert.True(devAct.IsTracked(App1));
            devAct.Track(App2);
            Assert.True(devAct.IsTracked(App2));

            // Untrack App1 and App2 and assert that they are not tracked
            devAct.UnTrack(App1);
            Assert.False(devAct.IsTracked(App1));
            devAct.UnTrack(App2);
            Assert.False(devAct.IsTracked(App2));
        }

        /// <summary>
        /// Tests for correct behaviour in the case of a two consecutive calls to Track().
        /// </summary>
        [Fact]
        public void TestDoubleTrack() {
            // Construct a DeviceActivity and assert App1 is not tracked
            DeviceActivity devAct = new DeviceActivity();
            Assert.False(devAct.IsTracked(App1));
            // Double track App1
            devAct.Track(App1);
            devAct.Track(App1);
            // Assert App1 is tracked
            Assert.True(devAct.IsTracked(App1));
        }

        /// <summary>
        /// Tests for correct behaviour in the case of a two consecutive calls to UnTrack().
        /// </summary>
        [Fact]
        public void TestDoubleUnTrack() {
            // Construct a DeviceActivity and track App1, assert that it is tracked
            DeviceActivity devAct = new DeviceActivity();
            devAct.Track(App1);
            Assert.True(devAct.IsTracked(App1));

            // Double UnTrack
            devAct.UnTrack(App1);
            devAct.UnTrack(App1);
            // Assert App2 is not tracked
            Assert.False(devAct.IsTracked(App1));
        }

        /// <summary>
        /// Tests the ability of DeviceActivity to return problem apps.
        /// </summary>
        [Fact]
        public void TestGetProblemApps() {
            // Construct a DeviceActivity and assert that it has no problem apps
            DeviceActivity devAct = new DeviceActivity();
            Assert.Empty(devAct.GetProblemApps());

            // Track App1 and App2
            devAct.Track(App1);
            devAct.Track(App2);

            // Assert that the DeviceActivity now contains App1 and App2 in its problem apps
            Assert.Equal(2, devAct.GetProblemApps().Count);
            Assert.Contains<AppInfo>(App1, devAct.GetProblemApps());
            Assert.Contains<AppInfo>(App2, devAct.GetProblemApps());
        }

        /// <summary>
        /// Tests usage queries where an exception should be thrown.
        /// </summary>
        [Fact]
        public void TestUsageExceptions() {
            DeviceActivity devAct = new DeviceActivity();
            // Assert that an exception is thrown when getting stats for an untracked app
            Assert.Throws<ArgumentException>(() => devAct.GetPastStats(App1, 0));
            devAct.Track(App1);
            // Assert that an exception is thrown when getting stats from -1 queries ago
            Assert.Throws<ArgumentException>(() => devAct.GetPastStats(App1, -1));
        }

        /// <summary>
        /// Tests the ability of DeviceActivity to query usage.
        /// </summary>
        [Fact]
        public void TestUsage() {
            // Construct a DeviceActivity and track App1 and App2
            DeviceActivity devAct = new DeviceActivity();
            devAct.Track(App1);
            devAct.Track(App2);

            // Assert there is no current data for App1 and App2
            Assert.Equal(AppActivityLog.NO_DATA, devAct.GetPastStats(App1, 0));
            Assert.Equal(AppActivityLog.NO_DATA, devAct.GetPastStats(App2, 0));

            // Record usage from 2 using the mock response and assert
            // that App1 and App2 both have 0 usage
            devAct.RecordUsage(2, mockResponse);
            Assert.Equal(0, devAct.GetPastStats(App1, 0));
            Assert.Equal(0, devAct.GetPastStats(App2, 0));

            // Record usage from 1 using the mock response and assert
            // that App1 has Usage1 and App2 has 0 usage
            devAct.RecordUsage(1, mockResponse);
            Assert.Equal(Usage1, devAct.GetPastStats(App1, 0));
            Assert.Equal(0, devAct.GetPastStats(App2, 0));

            // Assert that App1 and App2 both have 0 usage from the previous query
            Assert.Equal(0, devAct.GetPastStats(App1, 1));
            Assert.Equal(0, devAct.GetPastStats(App2, 1));

            // Record usage from 0 using the mock response and assert
            // that App1 has Usage1 and App2 has Usage2
            devAct.RecordUsage(0, mockResponse);
            Assert.Equal(Usage1, devAct.GetPastStats(App1, 0));
            Assert.Equal(Usage2, devAct.GetPastStats(App2, 0));

            // Assert that the previous queries still store the correct usage
            Assert.Equal(Usage1, devAct.GetPastStats(App1, 1));
            Assert.Equal(0, devAct.GetPastStats(App2, 1));
            Assert.Equal(0, devAct.GetPastStats(App1, 2));
            Assert.Equal(0, devAct.GetPastStats(App2, 2));
        }

        /// <summary>
        /// A mock response for usage of App1 and App2.
        /// </summary>
        /// <param name="time">the time from which to query</param>
        /// <returns>a Dictionary mapping App1 and App2 to their usage</returns>
        private static IDictionary<String, double> mockResponse(long time) {
            IDictionary<String, double> resp = new Dictionary<String, double>();
            // If time < 2, add App1 and its usage
            if (time < 2) {
                resp.Add(App1.GetPackage(), Usage1);
            }
            // If time < 1, also add App2 and its usage
            if (time < 1) {
                resp.Add(App2.GetPackage(), Usage2);
            }
            return resp;
        }
    }
}
