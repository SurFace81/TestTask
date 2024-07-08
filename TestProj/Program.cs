using System.Runtime.CompilerServices;
using System;

[assembly: InternalsVisibleTo("TestProjTests")]
namespace TestProj
{
    // Instead of a structure, you can use a class to avoid copying all values when passing to the method
    struct Candidate
    {
        public string name;
        public int weight, height, age;
        public double vision;
        public bool smoking;
        public HashSet<string> diseases;    // The average search speed will be O(1)
    }

    public class Program
    {
        static int cntr_2 = 0, cntr_3 = 0, cntr_4 = 0;
        public static void Main(string[] args)
        {
            Console.Write(">>> ");
            bool enabled = true;

            while (enabled)
            {
                string general = Console.ReadLine();
                Candidate candidate = (new Parser()).ParseCandidate(general);

                // Perhaps it is possible to rewrite through exceptions
                if (IsNotValid(candidate))
                {
                    Console.Write("\n>>> ");
                    continue;
                }

                List<(string, int)> res = (new CandidateTesting()).Testing(candidate);
                CountEvals(res);
                Decision(candidate, res);

                bool not_answ = true;
                while (not_answ)
                {
                    Console.Write("\nЖелаете протестировать следующего? [Y/N] ");
                    string answ = Console.ReadLine();
                    if (answ != null && answ.Equals("N"))
                    {
                        enabled = false;
                        not_answ = false;
                    }
                    if (answ != null && answ.Equals("Y"))
                    {
                        not_answ = false;
                        cntr_2 = 0; cntr_3 = 0; cntr_4 = 0;
                        Console.Write("\n>>> ");
                    }
                }
            }
        }

        private static bool IsNotValid(Candidate candidate) 
        {
            return candidate.name == "" || candidate.weight <= 0 || candidate.height <= 0 ||
                    candidate.age <= 0 || candidate.vision <= 0 || Parser.bool_error;
        }

        private static void Decision(Candidate candidate, List<(string, int)> result)
        {
            if (cntr_2 > 0 || cntr_3 >= 3)
            {
                Console.WriteLine($"Кандидат {candidate.name} не прошел тестирование. Проблемы:");
                foreach (var r in result)
                {
                    if (r.Item2 != 4)
                    {
                        Console.WriteLine($"\t* " + r.Item1);
                    }
                }
            }
            else
            {
                Console.WriteLine($"Кандидат {candidate.name} подходит");
            }
        }

        private static void CountEvals(List<(string, int)> result)
        {
            foreach (var r in result)
            {
                if (r.Item2 == 2)
                {
                    cntr_2 += 1;
                }
                if (r.Item2 == 3)
                {
                    cntr_3 += 1;
                }
                if (r.Item2 == 4)
                {
                    cntr_4 += 1;
                }
            }
        }
    }
}
