using System;
using System.Collections.Generic;
namespace ArrayList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //=================Array=====================//
            // I. DECLARATION
            //==================

            // int[] krsha = new int[] { 1, 2, 3 };
            // var krsha = new int[] { 1, 2, 3 };
            var krsha = new[] { 5, 2, 3 , 1 , 5 , 6 , 9 , 8 , 7};
            var strings = new[] { "krkr", "roro", "maro", "motaz", "yukii", "krshaa" };
            var booleans = new[] {true , true , true , true , true , true };
            // foreach (var k in krsha) Console.WriteLine(k);

            // II. PROPERTIES
            //====================

            //  Length : instance member accessible by the object
            Console.WriteLine("Length is:" + krsha.Length);

            // III. STATIC METHODS which is accessible by the Array Class Itself
            //====================================================================

            // IndexOf()
            Console.WriteLine( "Required Index: " + Array.IndexOf(krsha,3) );

            // Clear()
            //Console.WriteLine("The Effect of Clear() :");
            //Array.Clear(krsha , 0 , 4); // int => 0
            //foreach (var k in krsha) Console.WriteLine(k);

            //Array.Clear(strings, 2, 3); // string => null
            //foreach (var k in strings) Console.WriteLine(k);

            //Array.Clear(booleans, 2, 3); // boolean => false
            //foreach (var k in booleans) Console.WriteLine(k);

            // Copy()
            Console.WriteLine("The effect of Copy() :");
            var numbers = new int[3];
            Array.Copy(krsha, numbers, 3);
            //foreach (var k in numbers) Console.WriteLine(k);

            // Sort()
            Console.WriteLine("The effect of Sort() :");
            Array.Sort(krsha);
            //foreach (var k in krsha) Console.WriteLine(k);

            // Reverse()
            Console.WriteLine("The effect of Reverse() :");
            Array.Reverse(krsha);
            //foreach (var k in krsha) Console.WriteLine(k);

            //==================== Generic Lists =====================//
            Console.WriteLine("//============== Working with Generic Lists =============//");
            var list = new List<int>() { 1, 2, 3};
            list.Add(4); // the size of list can be changed unlike arrays , in case of arrays we can't add an element to an array because it's size can't be changed
            list.AddRange(new int[3] {5,6,7});
            //foreach (var k in list) Console.WriteLine(k);

            var list2 = new List<int>() { 1 , 2 , 3 , 4 , 6 , 7 , 4 , 9 , 10 , 15 , 4 , 7 };
            Console.WriteLine("Index of first 4 : " + list2.IndexOf(4));  // 3 , starting search from the beginning of the list
            Console.WriteLine("Index of first 4 : " + list2.IndexOf(4, 1));  // 3 , starting search from index 1
            Console.WriteLine("Index of second 4 : " + list2.IndexOf(4, 4));  // 6 , starting search from index 4
            Console.WriteLine("Index of third 4 : " + list2.IndexOf(4, 8));  // 10 , starting search from index 5
            Console.WriteLine("Index of the last 4 : " + list2.LastIndexOf(4)); // 10 , starting search from the end of the list

            // Count : returns the number of objects in the list
            Console.WriteLine("Count : " + list2.Count); // 12
            // Note : array.Length == list.Count        similar
            list2.Remove(4); // removes the first 4 in the list

            Console.WriteLine("The effect of Remove()");
            foreach (var k in list2) Console.WriteLine(k);


            // How to remove all the 4 in the list ?
            /*
            foreach (var k in list2)
            {
                if (k == 4)
                {
                    list2.Remove(k); // there is an exception => we cannot remove an element of a collection(list) inside a foreach loop => instead use a normal for loop
                }
            }
            */
            for (var i = 0; i < list2.Count;i++)
            {
                if ( list2[i] == 4 ) list2.Remove(list2[i]);
            }
            Console.WriteLine("After removing all 4 from the list :");
            foreach (var k in list2) Console.WriteLine(k);

            Console.WriteLine("The effect of Clear Method");
            list2.Clear();
            Console.WriteLine("Count of list2:" + list2.Count);
            foreach (var k in list2) Console.WriteLine(k);
        }
    }
}