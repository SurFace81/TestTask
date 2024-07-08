using TestProj;

namespace TestProjTests
{
    [TestClass]
    public class ParserTests
    {
        [TestMethod]
        public void ParserTest()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 1 false cold");
            Assert.AreEqual("hello hello", candidate.name);
            Assert.AreEqual(80, candidate.weight);
            Assert.AreEqual(180, candidate.height);
            Assert.AreEqual(45, candidate.age);
            Assert.AreEqual(1, candidate.vision);
            Assert.AreEqual(false, candidate.smoking);
        }

        [TestMethod]
        public void ParserBoolErrorTest()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 1 -1 cold");
            Assert.AreEqual(true, Parser.bool_error);
        }

        [TestMethod]
        public void ParserDoubleTest1()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 0,9 false cold");
            Assert.AreEqual(0.9, candidate.vision);
        }

        [TestMethod]
        public void ParserDoubleTest2()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 0.9 false cold");
            Assert.AreEqual(0.9, candidate.vision);
        }

        [TestMethod]
        public void ParserDoubleErrorTest1()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 h false cold");
            Assert.AreEqual(-1, candidate.vision);
        }

        [TestMethod]
        public void ParserDoubleErrorTest2()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 -0.9 false cold");
            Assert.AreEqual(-1, candidate.vision);
        }

        [TestMethod]
        public void ParserDoubleErrorTest3()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello 80 180 45 1.2 false cold");
            Assert.AreEqual(-1, candidate.vision);
        }

        [TestMethod]
        public void ParserIntErrorTest1()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello h 180 45 1 false cold");
            Assert.AreEqual(-1, candidate.weight);
        }

        [TestMethod]
        public void ParserIntErrorTest2()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("hello hello -1 180 45 1 false cold");
            Assert.AreEqual(-1, candidate.weight);
        }

        [TestMethod]
        public void ParserNameErrorTest()
        {
            Parser p = new Parser();
            Candidate candidate = p.ParseCandidate("");
            Assert.AreEqual("", candidate.name);
        }
    }
}