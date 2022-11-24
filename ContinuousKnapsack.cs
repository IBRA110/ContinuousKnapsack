namespace ContinuousKnapsack
{
    public class Knapsack
    {
        public static void Run()
        {
            string[] input = Console.ReadLine().Split();

            int n = int.Parse(input[0]);
            int W = int.Parse(input[1]);

            Item[] items = new Item[n];

            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine().Split();
                items[i] = new Item(input);
            }
            
            Array.Sort(items);
            double result = 0;

            foreach (Item i in items)
            {
                if (i.weight <= W)
                {
                    result += i.cost;
                    W -= i.weight;
                }
                else 
                {
                    result += (double)i.cost * W / i.weight;
                    break;
                }
            }

            Console.WriteLine(result);
        }
    }
    public struct Item: IComparable<Item>
    {
        public int cost;
        public int weight;
        private double res;

        public Item(string[] str)
        {
            cost = int.Parse(str[0]);
            weight = int.Parse(str[1]);
            res = (double)cost / weight;
        }
        public int CompareTo(Item i)
        {
            return -res.CompareTo(i.res);
        }

        public override string ToString()
        {
            return $"[{cost}, {weight}]";
        }
    }
}