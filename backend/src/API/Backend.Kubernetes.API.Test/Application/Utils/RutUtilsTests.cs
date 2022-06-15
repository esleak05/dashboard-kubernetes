using Backend.Kubernetes.API.Domain.Exceptions;
using Xunit;

namespace Backend.Kubernetes.API.Application.Utils.Tests
{
    public class RutUtilsTests
    {
        [Fact()]
        public void GetRutTest()
        {
            var (rut, dv) = RutUtils.GetRut("12905.200-8");
            Assert.Equal("8", dv);
            Assert.Equal(12905200, rut);
        }

        [Fact()]
        public void GetRutNullTest()
        {
            Assert.Throws<InvalidRutException>(() => RutUtils.GetRut(null));
        }

        [Fact()]
        public void IsRutValidTest()
        {
            Assert.True(RutUtils.IsValidRut("12905270-8"));
        }

        [Fact()]
        public void IsRutValidFalseTest()
        {
            Assert.False(RutUtils.IsValidRut("12905270-9"));
        }

        [Fact()]
        public void IsRutInvalidTest()
        {
            Assert.False(RutUtils.IsValidRut("12K905270-9"));
        }
    }
}