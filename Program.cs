using System;

namespace MaxHeap
{
    class Heap // class for heap : 
    {
        public int heapSize; //fields : 
        public int[] array;
        public Heap(int size) //constructor: 
        {
            heapSize = size;
            array = new int[heapSize];
        }
        public Heap()
        {

        }
        private int Parent(int i) // find parent : 
        {
            double ip = i / 2;
            int ipp = Convert.ToInt32(Math.Floor(ip));
            return ipp;
        }
        private int Left(int i) // finde left child :
        {
            int leftIndex = 2 * i + 1;
            if (leftIndex < heapSize)
                return leftIndex;
            return 0;
        }
        private int Right(int i) // find right child :
        {
            int rightIndex = 2 * i + 2;
            if (rightIndex < heapSize)
                return rightIndex;
            return 0;
        }
        public void Insert() //inserting to heap : 
        {
            for (int i = 0; i < heapSize; i++)
            {
                this.array[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public bool isHeap() // is heap ? : 
        {
            for (int i = heapSize - 1; i >= 0; i--)        // T(n) = O(n)
            {

                if (array[Parent(i)] < array[i])
                    return false;
            }
            return true;
        }
        public void delete(int value) // To delete a value : 
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++) //T(n)=
            {
                if (array[i] == value)
                {
                    index = i;
                    break;
                }
            }
            if (index == -1)
                Console.WriteLine("The Value Is Not In The Heap!!");
            else
            {
                array[index] = array[array.Length - 1];
                Array.Resize(ref array, array.Length - 1);
                heapSize--;
                MaxHeapify(array, index);
            }
        }
    
        public void printHeapSorted() // print heap sorted : 
        {
            int[] sortedArray = HeapSort(array);
            Console.WriteLine("\n Heap-sorted array:");
            foreach (int element in sortedArray)
            {
                Console.Write(element + " ");
            }
        }
        public void printKthBigNUm(int k) // print the k'th biggest number : 
        {
            int[] sortedArray = HeapSort(array); // T(n)= O(nlogn + k )

            Console.WriteLine("\nThe " + k + " biggest number is : ");
            int big = sortedArray[sortedArray.Length - k];
            Console.WriteLine(big);
        }
        public static Heap mergeHeaps(Heap heap1, Heap heap2) // merging 2 heaps : 
        {
            int[] array1Copy = new int[heap1.array.Length]; // T(n)= O(nlogn)
            heap1.array.CopyTo(array1Copy, 0);

            int[] array2Copy = new int[heap2.array.Length];
            heap2.array.CopyTo(array2Copy, 0);

            int[] mergedArray = mergedArrays(array1Copy, array2Copy);

            Heap mergedHeap = new Heap(mergedArray.Length);

            mergedHeap.array = mergedArray;

            mergedHeap.buildMaxHeap();

            return mergedHeap;
        }
        public  static int [] mergedArrays(int[] array1, int [] array2)  //T(n) = O(n+m)
        {
            int[] mergedArray = new int[array1.Length + array2.Length];
            array1.CopyTo(mergedArray, 0);
            array2.CopyTo(mergedArray, array1.Length);
            return mergedArray;
        }
      
        private int[] HeapSort(int[] array) // to make our heap's array sorted : 
        {
            buildMaxHeap();
            for (int i = array.Length - 1; i >= 1; i--)   //T(n) = O(nlogn)
            {
                SwapInts(array, 0, i);
                heapSize = heapSize - 1;
                MaxHeapify(array, 0);

            }
            return array;
        }
        public  void buildMaxHeap() // T(n) = O(n)
        {
            heapSize = array.Length;
            double a = heapSize / 2;
            int midOfArr = Convert.ToInt32(Math.Floor(a));

            for (int i = midOfArr - 1; i >= 0; i--)
                MaxHeapify(array, i);
        }
        public void MaxHeapify(int[] array, int i)  // T(n) = O(logn)
        {
            int l = Left(i);
            int r = Right(i);
            int largest = i;
            if (l != 0 && l < heapSize && array[l] > array[i])
                largest = l;
            else
                largest = i;
            if (r != 0 && r < heapSize & array[r] > array[largest])
                largest = r;
            if (largest != i)
            {
                SwapInts(array, i, largest);
                MaxHeapify(array, largest);
            }
        }
        private static void SwapInts(int[] array, int position1, int position2) // T(n) = O(1)
        {
            int temp = array[position1];
            array[position1] = array[position2];
            array[position2] = temp;
        }
        public void print()  // T(n) = O(n)
        {
            for (int i =0; i < heapSize; i++)
            {
                Console.Write( array[i] + " ");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                
                Heap heap = new Heap();
                Console.WriteLine("Welcome to MaxHeap program!");
                Console.WriteLine("Choose an operation : ");
                int operation;
                do
                {

                    Console.WriteLine("\n 1.Insert Your Elements To Heap." +
                        "\n 2.Check If Your Heap is MaxHeap or not." +
                        "\n 3.Give Us A Value And Delete it From The Heap." +
                        "\n 4.Print Heap's Elements In A Sorted Way." +
                        "\n 5.Merge 2 Heaps Into 1 Heap." +
                        "\n 6.Find The k'th Biggest Number In The Heap." +
                        "\n 7.Print Heap" +
                        "\n 8.Exit.");
                    operation = Convert.ToInt32(Console.ReadLine());
                    switch (operation)
                    {
                        case 1:
                            Console.WriteLine("Enter the Size of Your Heap: ");
                            int size = Convert.ToInt32(Console.ReadLine());
                            heap = new Heap(size);
                            Console.WriteLine("Enter Elements : ");
                            heap.Insert();
                            Console.WriteLine("Your Heap  is : ");
                            heap.print();
                            break;
                        case 2:
                            if (heap.isHeap() == true)
                                Console.WriteLine("Your Heap is MaxHeap.");
                            else
                            {
                                Console.WriteLine("Your Heap is Not MaxHeap.");
                                Console.WriteLine("The MaxHeap Of Your Heap Is : ");
                                heap.buildMaxHeap();
                                heap.print();
                            }
                            break;
                        case 3:
                            Console.WriteLine("Enter A Value To Delete : ");
                            int value = Convert.ToInt32(Console.ReadLine());
                            heap.delete(value);
                            heap.print();
                            break;
                        case 4:
                            Console.WriteLine("Your Sorted Heap : ");
                            heap.printHeapSorted();
                            break;
                        case 5:
                            Console.WriteLine("Enter The Size Of The First Array : ");
                            int size1 = Convert.ToInt32(Console.ReadLine());
                            Heap heap1 = new Heap(size1);
                            Console.WriteLine("Enter The Elements Of The First Array : ");
                            heap1.Insert();
                            heap1.buildMaxHeap();

                            Console.WriteLine("Enter The Size of The Second Array : ");
                            int size2 = Convert.ToInt32(Console.ReadLine());
                            Heap heap2 = new Heap(size2);
                            Console.WriteLine("Enter The Elements Of The second Array : ");
                            heap2.Insert();
                            heap2.buildMaxHeap();
                            Heap mergedHeap = Heap.mergeHeaps(heap2, heap1);
                            Console.WriteLine("The Heaps Are merged. Result :");
                            mergedHeap.print();
                            break;

                        case 6:
                            Console.WriteLine("Enter k : ");
                            int k = Convert.ToInt32(Console.ReadLine());
                            heap.printKthBigNUm(k);
                            break;
                        case 7:
                            Console.WriteLine(" Your Heap : ");
                            heap.print();
                            break;
                        
                        case 8:
                            Console.WriteLine("Exiting Program!");
                            break;

                    }
                }
                while (operation != 8);
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
