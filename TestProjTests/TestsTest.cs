using System;
using TestProj;

namespace TestProjTests
{
    [TestClass]
    public class TestsTest
    {
        [TestMethod]
        public void WeightTest_in80_out4()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 80;

            WeightTest wt = new WeightTest();
            Assert.AreEqual(("", 4), wt.Test(candidate));
        }

        [TestMethod]
        public void WeightTest_in110_out2()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 110;

            WeightTest wt = new WeightTest();
            Assert.AreEqual(("Вес кандидата (110) больше 100 (неудовлетворительно)", 2), wt.Test(candidate));
        }

        [TestMethod]
        public void WeightTest_in60_out2()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 60;

            WeightTest wt = new WeightTest();
            Assert.AreEqual(("Вес кандидата (60) меньше 70 (неудовлетворительно)", 2), wt.Test(candidate));
        }

        [TestMethod]
        public void WeightTest_in72_out3()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 72;

            WeightTest wt = new WeightTest();
            Assert.AreEqual(("Вес кандидата (72) меньше 75 (удовлетворительно)", 3), wt.Test(candidate));
        }

        [TestMethod]
        public void WeightTest_in92_out3()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 92;

            WeightTest wt = new WeightTest();
            Assert.AreEqual(("Вес кандидата (92) больше 90 (удовлетворительно)", 3), wt.Test(candidate));
        }

        [TestMethod]
        public void HeightTest_in175_out4()
        {
            Candidate candidate = new Candidate();
            candidate.height = 175;

            HeightTest ht = new HeightTest();
            Assert.AreEqual(("", 4), ht.Test(candidate));
        }

        [TestMethod]
        public void HeightTest_in200_out2()
        {
            Candidate candidate = new Candidate();
            candidate.height = 200;

            HeightTest ht = new HeightTest();
            Assert.AreEqual(("Рост кандидата (200) больше 190 (неудовлетворительно)", 2), ht.Test(candidate));
        }

        [TestMethod]
        public void HeightTest_in150_out2()
        {
            Candidate candidate = new Candidate();
            candidate.height = 150;

            HeightTest ht = new HeightTest();
            Assert.AreEqual(("Рост кандидата (150) меньше 160 (неудовлетворительно)", 2), ht.Test(candidate));
        }

        [TestMethod]
        public void HeightTest_in165_out3()
        {
            Candidate candidate = new Candidate();
            candidate.height = 165;

            HeightTest ht = new HeightTest();
            Assert.AreEqual(("Рост кандидата (165) меньше 170 (удовлетворительно)", 3), ht.Test(candidate));
        }

        [TestMethod]
        public void HeightTest_in187_out()
        {
            Candidate candidate = new Candidate();
            candidate.height = 187;

            HeightTest ht = new HeightTest();
            Assert.AreEqual(("Рост кандидата (187) больше 185 (удовлетворительно)", 3), ht.Test(candidate));
        }

        [TestMethod]
        public void AgeTest_in30_out4()
        {
            Candidate candidate = new Candidate();
            candidate.age = 30;

            AgeTest at = new AgeTest();
            Assert.AreEqual(("", 4), at.Test(candidate));
        }

        [TestMethod]
        public void AgeTest_in40_out2()
        {
            Candidate candidate = new Candidate();
            candidate.age = 40;

            AgeTest at = new AgeTest();
            Assert.AreEqual(("Возраст кандидата (40) больше 37 (неудовлетворительно)", 2), at.Test(candidate));
        }

        [TestMethod]
        public void AgeTest_in20_out2()
        {
            Candidate candidate = new Candidate();
            candidate.age = 20;

            AgeTest at = new AgeTest();
            Assert.AreEqual(("Возраст кандидатa (20) меньше 23 (неудовлетворительно)", 2), at.Test(candidate));
        }

        [TestMethod]
        public void AgeTest_in24_out3()
        {
            Candidate candidate = new Candidate();
            candidate.age = 24;

            AgeTest at = new AgeTest();
            Assert.AreEqual(("Возраст кандидата (24) меньше 25 (удовлетворительно)", 3), at.Test(candidate));
        }

        [TestMethod]
        public void AgeTest_in36_out3()
        {
            Candidate candidate = new Candidate();
            candidate.age = 36;

            AgeTest at = new AgeTest();
            Assert.AreEqual(("Возраст кандидата (36) больше 35 (удовлетворительно)", 3), at.Test(candidate));
        }

        [TestMethod]
        public void VisionTest_in1_out4()
        {
            Candidate candidate = new Candidate();
            candidate.vision = 1;

            VisionTest vt = new VisionTest();
            Assert.AreEqual(("", 4), vt.Test(candidate));
        }

        [TestMethod]
        public void VisionTest_in05_out2()
        {
            Candidate candidate = new Candidate();
            candidate.vision = 0.5;

            VisionTest vt = new VisionTest();
            Assert.AreEqual(("Зрение кандидата (0,5) меньше 1 (неудовлетворительно)", 2), vt.Test(candidate));
        }

        [TestMethod]
        public void SmokingTest_in_false_out4()
        {
            Candidate candidate = new Candidate();
            candidate.smoking = false;

            SmokingTest st = new SmokingTest();
            Assert.AreEqual(("", 4), st.Test(candidate));
        }

        [TestMethod]
        public void SmokingTest_in_true_out4()
        {
            Candidate candidate = new Candidate();
            candidate.smoking = true;

            SmokingTest st = new SmokingTest();
            Assert.AreEqual(("Кандидат курит (неудовлетворительно)", 2), st.Test(candidate));
        }

        [TestMethod]
        public void TherapistTest_in0_out4()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { };

            TherapistTest tt = new TherapistTest();
            Assert.AreEqual(("", 4), tt.Test(candidate));
        }

        [TestMethod]
        public void TherapistTest_in3_out3()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold", "virus", "quinsy" };

            TherapistTest tt = new TherapistTest();
            Assert.AreEqual(("Кандидат имеет следующие болезни: cold, virus, quinsy (удовлетворительно)", 3), tt.Test(candidate));
        }

        [TestMethod]
        public void TherapistTest_in4_out2()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold", "virus", "quinsy", "insomnia" };

            TherapistTest tt = new TherapistTest();
            Assert.AreEqual(("Кандидат имеет следующие болезни: cold, virus, quinsy, insomnia (неудовлетворительно)", 2), tt.Test(candidate));
        }

        [TestMethod]
        public void PsychologistTest_in0_out4()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { };

            PsychologistTest pt = new PsychologistTest();
            Assert.AreEqual(("", 4), pt.Test(candidate));
        }

        [TestMethod]
        public void PsychologistTest_in1_out3()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "insomnia" };

            PsychologistTest pt = new PsychologistTest();
            Assert.AreEqual(("Кандидат имеет следующие болезни: insomnia (удовлетворительно)", 3), pt.Test(candidate));
        }

        [TestMethod]
        public void PsychologistTest_in2_out2()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "insomnia", "injury" };

            PsychologistTest pt = new PsychologistTest();
            Assert.AreEqual(($"Кандидат имеет следующие болезни: insomnia, injury (неудовлетворительно)", 2), pt.Test(candidate));
        }

        [TestMethod]
        public void WeightAndHabitsTest_125_out2()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold" };
            candidate.smoking = true;
            candidate.weight = 125;

            WeightAndHabitsTest waht =new WeightAndHabitsTest();
            Assert.AreEqual(("Кандидат курит, имеет простуду и/или вирусы и его вес (125) больше 120 (неудовлетворительно)", 2), waht.Test(candidate));
        }

        [TestMethod]
        public void WeightAndHabitsTest_55_out2()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold" };
            candidate.smoking = true;
            candidate.weight = 55;

            WeightAndHabitsTest waht = new WeightAndHabitsTest();
            Assert.AreEqual(("Кандидат курит, имеет простуду и/или вирусы и его вес (55) меньше 60 (неудовлетворительно)", 2), waht.Test(candidate));
        }

        [TestMethod]
        public void WeightAndHabitsTest_120_out3()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold" };
            candidate.weight = 120;

            WeightAndHabitsTest waht = new WeightAndHabitsTest();
            Assert.AreEqual(("Кандидат имеет простуду и/или вирусы и его вес (120) больше 110 (удовлетворительно)", 3), waht.Test(candidate));
        }

        [TestMethod]
        public void WeightAndHabitsTest_85_out4()
        {
            Candidate candidate = new Candidate();
            candidate.weight = 85;
            candidate.smoking = false;
            candidate.diseases = new HashSet<string>();

            WeightAndHabitsTest waht = new WeightAndHabitsTest();
            Assert.AreEqual(("", 4), waht.Test(candidate));
        }

        [TestMethod]
        public void WeirdTest_inP_out4()
        {
            Candidate candidate = new Candidate();
            candidate.name = "Павел Александров";

            WeirdTest wt = new WeirdTest();
            Assert.AreEqual(("", 4), wt.Test(candidate));
        }

        [TestMethod]
        public void WeirdTest_in70_out3()
        {
            Candidate candidate = new Candidate();
            candidate.name = "Анна Александрова";
            candidate.age = 70;

            WeirdTest wt = new WeirdTest();
            Assert.AreEqual(("Возраст кандидата (70) больше 68 и его имя не начинается на букву 'П' (удовлетворительно)", 3), wt.Test(candidate));
        }

        [TestMethod]
        public void WeirdTest_in50_out2()
        {
            Candidate candidate = new Candidate();
            candidate.name = "Анна Александрова";
            candidate.age = 50;

            WeirdTest wt = new WeirdTest();
            Assert.AreEqual(("Возраст кандидата (50) меньше 68 и его имя не начинается на букву 'П' (неудовлетворительно)", 2), wt.Test(candidate));
        }

        [TestMethod]
        public void MathematicTest_out2()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string> { "cold" };
            candidate.height = 186;

            MathematicTest mt = new MathematicTest();
            Assert.AreEqual(("У кандидата насморк и его рост (186) делится на 3 (неудовлетворительно)", 2), mt.Test(candidate));
        }

        [TestMethod]
        public void MathematicTest_out4()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string>();
            candidate.height = 180;

            MathematicTest mt = new MathematicTest();
            Assert.AreEqual(("", 4), mt.Test(candidate));
        }

        [TestMethod]
        public void MathematicTest_out3()
        {
            Candidate candidate = new Candidate();
            candidate.diseases = new HashSet<string>();
            candidate.height = 91;

            MathematicTest mt = new MathematicTest();
            Assert.AreEqual(("Кандидат здоров и его рост (91) не делится на 2 (удовлетворительно)", 3), mt.Test(candidate));
        }
    }
}
