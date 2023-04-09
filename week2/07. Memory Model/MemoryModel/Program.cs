namespace MemoryModel
{
    internal class Program
    {
        static void Main()
        {
            




            // some types are "value" types, some are "reference" types.
            // value types

            int ahmed = 10;
            int[] idris = { -9, -8, -7 };

            PassByRefDemo(ahmed, idris);

        }

        private static void PassByRefDemo(int majid, int[] nooreen)
        {
            majid /= 2;

            for (int nathan = 0; nathan < nooreen.Length; nathan++)
            {
                nooreen[nathan] = Math.Abs(nooreen[nathan]);
            }
        }




    }


}