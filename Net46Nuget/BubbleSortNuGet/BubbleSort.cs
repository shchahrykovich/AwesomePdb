namespace DotNextPdbDemo
{
    //https://en.wikipedia.org/wiki/Bubble_sort
    public static class BubbleSort
    {
        public static void Sort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                for (int j = 0; j < elements.Length - 1; j++)
                {
                    if (elements[j] > elements[j + 1])
                    {
                        int temp = elements[j];
                        elements[j] = elements[j + 1];
                        elements[j + 1] = temp;
                    }
                }
            }
        }
    }
}
