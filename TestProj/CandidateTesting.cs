namespace TestProj
{
    internal class CandidateTesting
    {
        List<ITest> tests = new List<ITest>();

        public CandidateTesting()
        {
            tests.Add(new WeightTest());
            tests.Add(new HeightTest());
            tests.Add(new AgeTest());
            tests.Add(new VisionTest());
            tests.Add(new SmokingTest());
            tests.Add(new TherapistTest());
            tests.Add(new PsychologistTest());
            tests.Add(new WeightAndHabitsTest());
            tests.Add(new WeirdTest());
        }

        public List<(string, int)> Testing(Candidate candidate)
        {
            List<(string, int)> res = new List<(string, int)>();

            foreach (var test in tests)
            {
                res.Add(test.Test(candidate));
            }

            return res;
        }
    }
}
