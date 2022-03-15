using Xunit;

namespace Singleton.Tests
{
    public class SingletonTests
    {
        [Fact]
        public void LoggerIsSingleton()
        {
            var instance1 = Logger.Instance;
            var instance2 = Logger.Instance;

            Assert.Equal(instance1, instance2);
        }

        [Fact]
        public void Logger_Logs_CorrectMessage()
        {
            var logger = Logger.Instance;
            logger.Log("What");
        }
    }
}