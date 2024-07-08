namespace TestProj
{
    interface ITest
    {
        (string, int) Test(Candidate candidate);
    }

    internal class MathematicTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.diseases.Contains("cold") && candidate.height % 3 == 0)
            {
                return ($"У кандидата насморк и его рост ({candidate.height}) делится на 3 (неудовлетворительно)", 2);
            }
            else if (candidate.height % 2 == 0)
            {
                return ("", 4);
            }
            else
            {
                return ($"Кандидат здоров и его рост ({candidate.height}) не делится на 2 (удовлетворительно)", 3);
            }
        }
    }

    internal class WeirdTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.name[0] == 'П')
            {
                return ("", 4);
            }
            else if (candidate.age > 68)
            {
                return ($"Возраст кандидата ({candidate.age}) больше 68 и его имя не начинается на букву 'П' (удовлетворительно)", 3);
            }
            else
            {
                return ($"Возраст кандидата ({candidate.age}) меньше 68 и его имя не начинается на букву 'П' (неудовлетворительно)", 2);
            }
        }
    }

    internal class WeightAndHabitsTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            bool cold_virus = (candidate.diseases.Contains("cold") || candidate.diseases.Contains("virus"));
            if (candidate.smoking && cold_virus && (candidate.weight > 120 || candidate.weight < 60))
            {
                if (candidate.weight > 120)
                {
                    return ($"Кандидат курит, имеет простуду и/или вирусы и его вес ({candidate.weight}) больше 120 (неудовлетворительно)", 2);
                }
                else
                {
                    return ($"Кандидат курит, имеет простуду и/или вирусы и его вес ({candidate.weight}) меньше 60 (неудовлетворительно)", 2);
                }

            }
            else if (cold_virus && candidate.weight > 110)
            {
                return ($"Кандидат имеет простуду и/или вирусы и его вес ({candidate.weight}) больше 110 (удовлетворительно)", 3);
            }
            else
            {
                return ("", 4);
            }
        }
    }

    internal class PsychologistTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            int dis_counter = 0;
            HashSet<string> diseases_list = new HashSet<string>() { "alcoholism", "insomnia",
                                                              "narcomania", "injury"};
            HashSet<string> res_diseases = new HashSet<string>();
            foreach (var disease in candidate.diseases)
            {
                if (diseases_list.Contains(disease))
                {
                    res_diseases.Add(disease);
                    dis_counter += 1;
                }
            }

            if (dis_counter == 0)
            {
                return ("", 4);
            }
            else if (dis_counter == 1)
            {
                return ($"Кандидат имеет следующие болезни: {string.Join(", ", res_diseases)} (удовлетворительно)", 3);
            }
            else
            {
                return ($"Кандидат имеет следующие болезни: {string.Join(", ", res_diseases)} (неудовлетворительно)", 2);
            }
        }
    }

    internal class TherapistTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            int dis_counter = 0;
            HashSet<string> diseases_list = new HashSet<string>() { "cold", "bronchitis", "virus",
                                                              "allergy", "quinsy", "insomnia"};
            HashSet<string> res_diseases = new HashSet<string>();
            foreach (var disease in candidate.diseases)
            {
                if (diseases_list.Contains(disease))
                {
                    res_diseases.Add(disease);
                    dis_counter += 1;
                }
            }

            if (dis_counter <= 2)
            {
                return ("", 4);
            }
            else if (dis_counter == 3)
            {
                return ($"Кандидат имеет следующие болезни: {string.Join(", ", res_diseases)} (удовлетворительно)", 3);
            }
            else
            {
                return ($"Кандидат имеет следующие болезни: {string.Join(", ", res_diseases)} (неудовлетворительно)", 2);
            }
        }
    }

    internal class SmokingTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (!candidate.smoking)
            {
                return ("", 4);
            }
            else
            {
                return ("Кандидат курит (неудовлетворительно)", 2);
            }
        }
    }

    internal class VisionTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.vision == 1)
            {
                return ("", 4);
            }
            else
            {
                return ($"Зрение кандидата ({candidate.vision}) меньше 1 (неудовлетворительно)", 2);
            }
        }
    }

    internal class AgeTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.age >= 25 && candidate.age <= 35)
            {
                return ("", 4);
            }
            else if (candidate.age > 37 || candidate.age < 23)
            {
                if (candidate.age > 37)
                {
                    return ($"Возраст кандидата ({candidate.age}) больше 37 (неудовлетворительно)", 2);
                }
                if (candidate.age < 23)
                {
                    return ($"Возраст кандидатa ({candidate.age}) меньше 23 (неудовлетворительно)", 2);
                }
            }
            else
            {
                if (candidate.age >= 23 && candidate.age < 25)
                {
                    return ($"Возраст кандидата ({candidate.age}) меньше 25 (удовлетворительно)", 3);
                }
                if (candidate.age > 35 && candidate.age <= 37)
                {
                    return ($"Возраст кандидата ({candidate.age}) больше 35 (удовлетворительно)", 3);
                }
            }

            return ("", 0);
        }
    }

    internal class HeightTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.height >= 170 && candidate.height <= 185)
            {
                return ("", 4);
            }
            else if (candidate.height > 190 || candidate.height < 160)
            {
                if (candidate.height > 190)
                {
                    return ($"Рост кандидата ({candidate.height}) больше 190 (неудовлетворительно)", 2);
                }
                else
                {
                    return ($"Рост кандидата ({candidate.height}) меньше 160 (неудовлетворительно)", 2);
                }
            }
            else
            {
                if (candidate.height >= 160 && candidate.height < 170)
                {
                    return ($"Рост кандидата ({candidate.height}) меньше 170 (удовлетворительно)", 3);
                }
                if (candidate.height > 185 && candidate.height <= 190)
                {
                    return ($"Рост кандидата ({candidate.height}) больше 185 (удовлетворительно)", 3);
                }
            }

            return ("", 0);
        }
    }

    internal class WeightTest : ITest
    {
        public (string, int) Test(Candidate candidate)
        {
            if (candidate.weight >= 75 && candidate.weight <= 90)
            {
                return ("", 4);
            }
            else if (candidate.weight > 100 || candidate.weight < 70)
            {
                if (candidate.weight > 100)
                {
                    return ($"Вес кандидата ({candidate.weight}) больше 100 (неудовлетворительно)", 2);
                }
                else
                {
                    return ($"Вес кандидата ({candidate.weight}) меньше 70 (неудовлетворительно)", 2);
                }
            }
            else
            {
                if ((candidate.weight >= 70 && candidate.weight < 75))
                {
                    return ($"Вес кандидата ({candidate.weight}) меньше 75 (удовлетворительно)", 3);
                }
                if (candidate.weight > 90 && candidate.weight <= 100)
                {
                    return ($"Вес кандидата ({candidate.weight}) больше 90 (удовлетворительно)", 3);
                }
            }

            return ("", 0);
        }
    }
}