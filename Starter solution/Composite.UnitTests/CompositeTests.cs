using Xunit;

namespace Composite.UnitTests
{
    public class CompositeTests
    {
        [Fact]
        public void Test1()
        {
            var root = new Directory("root", 0);
            var topLevelFile = new File("toplevel.txt", 100);
            var subDir1 = new Directory("subdir", 5);
            var subDir2 = new Directory("subdir2", 10);
            var subLevelFile1 = new File("sublevel1.txt", 1000);
            var subLevelFile2 = new File("sublevel2.txt", 2000);
            var subLevelFile3 = new File("sublevel3.txt", 3000);

            root.Add(topLevelFile);
            root.Add(subDir1);
            root.Add(subDir2);
            subDir1.Add(subLevelFile1);
            subDir1.Add(subLevelFile2);
            subDir2.Add(subLevelFile3);

            Assert.Equal(6115, root.GetSize());

            root.Remove(subDir1);
            
            Assert.Equal(3110, root.GetSize());
        }
    }
}