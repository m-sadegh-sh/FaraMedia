namespace FaraMedia.Services.Tests {
    using System;

    using FaraMedia.Core.Domain.Settings;
    using FaraMedia.Services.Media;

    using NUnit.Framework;

    [TestFixture]
    public class MediaUtilsTest {
        [Test]
        public void ValidateBinary() {
            var bytes = new byte[100];

            Assert.Throws<ArgumentException>(() => new MediaUtils(new MediaSettings {
                MaximumImageSize = 100,
                ImageQuality = 50
            }).ValidatePicture(bytes, "image/jpeg"));
        }
    }
}