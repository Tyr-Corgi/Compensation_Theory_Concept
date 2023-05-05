using System;
using System.Linq;

namespace PointDistribution
{
    class Program
    {
        static void Main(string[] args)
        {
            int totalPoints = 120;
            string[] categories = { "1. Ruin", "2. Preservation", "3. Honor", "4. Mercy", "5. Cultivation", "6. Valor", "7. Odium", "8. Devotion", "9. Autonomy", "10. Domination", "11. Invention", "12. Whimsy", "13. Virtuosity", "14. Endowment", "15. Ambition", "16. Contentment" };
            int[] points = new int[categories.Length];
            int remainingPoints = totalPoints;

            Console.WriteLine("Please distribute 120 points among the following 16 categories. No category can have more than 10 points:");

            for (int i = 0; i < categories.Length; i++)
            {
                Console.Write(categories[i] + ": ");
                int input = int.Parse(Console.ReadLine());

                while (input > 10)
                {
                    Console.WriteLine("No category can have more than 10 points. Please try again.");
                    Console.Write(categories[i] + ": ");
                    input = int.Parse(Console.ReadLine());
                }

                points[i] = input;
                remainingPoints -= input;
                Console.WriteLine("Points remaining: " + remainingPoints);
                Console.WriteLine("Categories remaining: " + (categories.Length - (i + 1)));

                if (remainingPoints < 0)
                {
                    Console.WriteLine("You have distributed more than 120 points. Please try again.");
                    return;
                }
            }

            if (remainingPoints > 0)
            {
                Console.WriteLine("You have not distributed all 120 points. Please try again.");
                return;
            }

            Console.WriteLine("You have distributed all 120 points. Here is the breakdown:");

            var breakdown = categories.Zip(points, (category, point) => category + ": " + point + " points");
            Console.WriteLine(string.Join(Environment.NewLine, breakdown));

            Console.WriteLine("Do you want to adjust any category totals? (y/n)");
            string answer = Console.ReadLine();

            while (answer == "y")
            {
                Console.Write("Which category do you want to adjust? ");
                string category = Console.ReadLine();

                int index = Array.IndexOf(categories, category);

                if (index == -1)
                {
                    Console.WriteLine("Invalid category name. Please try again.");
                }
                else
                {
                    Console.Write("New total for " + category + ": ");
                    int newTotal = int.Parse(Console.ReadLine());

                    while (newTotal > 10)
                    {
                        Console.WriteLine("No category can have more than 10 points. Please try again.");
                        Console.Write("New total for " + category + ": ");
                        newTotal = int.Parse(Console.ReadLine());
                    }

                    remainingPoints += points[index];
                    remainingPoints -= newTotal;
                    points[index] = newTotal;

                    Console.WriteLine("Points remaining: " + remainingPoints);
                    Console.WriteLine("Categories remaining: " + (categories.Length - (index + 1)));

                    if (remainingPoints < 0)
                    {
                        Console.WriteLine("You have distributed more than 120 points. Please try again.");
                        return;
                    }

                    Console.WriteLine("Do you want to adjust any category totals? (y/n)");
                    answer = Console.ReadLine();
                }
            }

            Console.WriteLine("Here is the final breakdown:");

            breakdown = categories.Zip(points, (category, point) => category + ": " + point + " points");
            Console.WriteLine(string.Join(Environment.NewLine, breakdown));

            Console.ReadLine();
        }
    }
}