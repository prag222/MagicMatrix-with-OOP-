using System;

namespace 魔術方陣OOP
{
    /// <summary>
    /// 內容:魔術方陣 with 物件導向開發
    /// 作者:prag222 暱稱:人肉OOP代碼產生器
    /// 聲明:版權沒有，引用請通知
    /// 上傳時間:2022/07/03 07:38
    /// </summary>
    class Program
    {
        public static int mNum = 5;
        public static int[,] matrix = new int[mNum, mNum];
        public static MagicMatrix mgMatrix;
        static void Main(string[] args)
        {
            SetUpMaxtrixValue();
            SetUpMagicMatrix();
            ProcessMagicMatrix();
            ShowMagicMatrix(mgMatrix);
        }

        /// <summary>
        /// 設定matrix陣列的預設值
        /// </summary>
        public static void SetUpMaxtrixValue()
        {
            for(int i=0;i<mNum;i++)
            {
                for (int j = 0; j < mNum; j++)
                {
                    matrix[i, j] = 0;
                }
            }
        }
        /// <summary>
        /// 設定MagicMatrix物件的初始值
        /// </summary>
        public static void SetUpMagicMatrix()
        {
             mgMatrix = new MagicMatrix(mNum, matrix, 1);
        }
        /// <summary>
        /// 執行處理魔術方陣邏輯
        /// </summary>
        public static void ProcessMagicMatrix()
        {
            MatrixUnit unit = new MatrixUnit(mgMatrix);
            while (mgMatrix.keyValue<=mNum*mNum)
            {
                if (mgMatrix.keyValue == 1)   
                    unit.Execute();
                else
                {
                    unit.x = unit.nextX;
                    unit.y = unit.nextY;
                    unit.Execute();
                }
            }
        }
        /// <summary>
        /// 顯示魔術方陣內容
        /// </summary>
        /// <param name="mgMatrix"></param>
        public static void ShowMagicMatrix(MagicMatrix mgMatrix)
        {
            for (int i = 0; i < mgMatrix.number; i++)
            {
                for (int j = 0; j < mgMatrix.number; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }
    }

    public class MagicMatrix
    {
        public int number;
        public int[,] matrix ;
        public int keyValue;
        public MagicMatrix(int number , int[,] matrix,int keyValue)
        {
            this.number = number;
            this.matrix = matrix;
            this.keyValue = keyValue;
        }
    }
    public class MatrixUnit
    {
        public MagicMatrix mgMatrix;
        public MatrixUnit (MagicMatrix mgMatrix)
        {
            this.mgMatrix = mgMatrix;
        }
        public int x { get; set; }
        public int y { get; set; }

        public int stepX
        {
            get
            {
                if (mgMatrix.keyValue == 1)
                    return 0;
                else
                {
                    int next = (x - 1) % mgMatrix.number;
                    return next < 0 ? mgMatrix.number - 1 : next;
                }
            }
        }
        public int stepY
        {
            get
            {
                if (mgMatrix.keyValue == 1)
                    return (mgMatrix.number-1)/2;
                else
                {
                    int next= (y - 1) % mgMatrix.number;
                    return next < 0 ? mgMatrix.number - 1 : next;
                }    
            }
        }
        public int nextX { get; set; }
        public int nextY { get; set; }
        public void Execute()
        {
            if (mgMatrix.matrix[stepX, stepY] != 0)
                nextX = (nextX + 1) % mgMatrix.number;
            else
            {
                nextX = stepX;
                nextY = stepY;
            }
            mgMatrix.matrix[nextX, nextY] = mgMatrix.keyValue;
            mgMatrix.keyValue++;
        }
    }
}
