// Перегрузка методов.

/*
namespace MyApp
{
    internal class progrsam
    {
        static void Main(string[] args)
        {
            float a = 231;
            int b = '2';
            Console.WriteLine(Do(a, b));
        }
        static int Do(int a, int b) => a * b;

        static int Do(double a, int b) => (int)(a / b);
    }
} */

/* Дана последовательность из N целых чисел и число K. Необходимо сдвинуть всю последовательность 
(сдвиг - циклический) на |K| элементов вправо, если K – положительное и влево, если отрицательное. */



// Быстрая сортировка

/*
int[] arr = {1, 5 , 3, 4 , 6, 2};
int[] res = QuickSort(arr, 0, arr.Length - 1);

Console.Write($"Итоговый массив {string.Join(",", res)}");

int[] QuickSort(int[] inputArray, int minIndex, int maxIndex)
{
    if(minIndex >= maxIndex) return inputArray;
    int pivot = GetPivotIndex(inputArray, minIndex, maxIndex );
    QuickSort(inputArray, minIndex, pivot - 1);
    QuickSort(inputArray, pivot + 1, maxIndex);
    return inputArray;
}

int GetPivotIndex(int[] inputArray, int minIndex, int maxIndex)
{
    int pivotIndex = minIndex - 1;
    for(int i = minIndex; i <= maxIndex; i++)
    {
        if(inputArray[i] < inputArray[maxIndex])
        {
            pivotIndex++;
            Swap(ref inputArray[pivotIndex], ref inputArray[i]);
        }
    }
    pivotIndex++;
    Swap(ref inputArray[pivotIndex], ref inputArray[maxIndex]);
    return pivotIndex;

}
void Swap(ref int leftValue, ref int rigthValue)
{
    int tmp = leftValue;
    leftValue = rigthValue;
    rigthValue = tmp;

}
*/

// Параллельное программирование на примере умножения матриц.
/*
const int N = 1000; // размер матрицы.
const int THREADS_NUMBER = 10;

int[,] serialMulRes = new int[N, N]; // результат умножения матриц в однопотоке.
int[,] threadMulRes = new int[N, N]; // результат параллельного умножения матриц.
int[,] parallelTask = new int[N, N];

int[,] firstMatrix = MatrixGenerator(N, N);
int[,] secondMatrix = MatrixGenerator(N, N);

SerialMatrixMul(firstMatrix, secondMatrix);
PrepareParallelMatrixMul(firstMatrix, secondMatrix, threadMulRes);
GoParallelMulTask(firstMatrix, secondMatrix, parallelTask);
Console.WriteLine(EqualityMatrix(serialMulRes, threadMulRes, parallelTask));

int[,] MatrixGenerator(int rows, int columns)
{
    Random _rand = new Random();
    int[,] res = new int[rows, columns];
    for (int i = 0; i < res.GetLength(0); i++)
    {
        for (int j = 0; j < res.GetLength(1); j++)
        {
            res[i, j] = _rand.Next(-100, 100);
        }
    }
    return res;
}

void SerialMatrixMul(int[,] a, int[,] b)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать матрицы");
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                serialMulRes[i, j] += a[i, k] * b[k, j];
            }
        }
    }
}

void PrepareParallelMatrixMul(int[,] a, int[,] b, int[,] r)
{
    if (a.GetLength(1) != b.GetLength(0)) throw new Exception("Нельзя умножать такие матрицы");
    int eachThreadCalc = N / THREADS_NUMBER;
    var threadsList = new List<Thread>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = (i + 1) * eachThreadCalc;
        // если последний поток
        if (i == THREADS_NUMBER - 1) endPos = N;
        threadsList.Add(new Thread(() => ParallelMatrixMul(a, b, r, startPos, endPos)));
        threadsList[i].Start();
    }
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
       threadsList[i].Join(); 
    }
}

void ParallelMatrixMul(int[,] a, int[,] b, int[,] resultMutrix, int startPos, int endPos)
{
    for (int i = startPos; i < endPos; i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                resultMutrix[i, j] += a[i, k] * b[k, j]; 
            }
        }
    }
}

void GoParallelMulTask(int[,] a, int[,] b, int[,] r)
{
    int eachThreadCalc = N / THREADS_NUMBER;
    var tasksParall = new List<Task>();
    for (int i = 0; i < THREADS_NUMBER; i++)
    {
        int startPos = i * eachThreadCalc;
        int endPos = i == THREADS_NUMBER - 1 ?  N :(i + 1) * eachThreadCalc;
        tasksParall.Add(new Task(() => ParallelMatrixMul(a, b, r, startPos, endPos)));
        tasksParall[i].Start();
    }
    Task.WaitAll(tasksParall.ToArray());
}

bool EqualityMatrix(int[,] fmatrix, int[,] smatrix, int[,] tmatrix)
{
    bool res = true;
    for (int i = 0; i < fmatrix.GetLength(0); i++)
    {
        for (int j = 0; j < fmatrix.GetLength(1); j++)
        {
            res =  res && ((fmatrix[i, j] == smatrix[i, j]) && (smatrix[i, j] == tmatrix[i, j]));
        }
    }
    return res;
}
*/






