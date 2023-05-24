namespace controlflow
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            //======= If Conditional ======//
            int hour = 19;

            if (hour > 0 && hour < 12)
            {
                Console.WriteLine("It's Morning! :)");
            }
                
            else if (hour > 12 && hour < 18)
            {
                Console.WriteLine("It's Afternoon! :)");
            }
                
            else
            {
                Console.WriteLine("It's Evening! :)");
            }
            //======== Conditional (ternary) Operator =======//
            bool isGoldCustomer = false;

            //float price;
            //if (isgoldcustomer)
            //    price = 19.95f;
            //else
            //    price = 29.95f;

            float price = (isGoldCustomer) ? 19.95f : 29.95f;
            Console.WriteLine(price);

            //======== Switch Case Conditional =======//
            var masyaf = Season.Summer;
            switch(masyaf)
            {
                case Season.Autumn: 
                    Console.WriteLine("Masyaf in Autumn");
                    break;
                case Season.Spring:
                case Season.Winter:
                    Console.WriteLine("We have a promotion!");
                    break;

                default:
                    Console.WriteLine("El donya 7arr ya 3m !!!");
                    break;
            }
        }
    }
}