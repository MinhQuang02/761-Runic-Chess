using UnityEngine;

namespace Data.Core
{
    /// <summary>
    /// Lớp chính để chạy chương trình hehehehe
    /// </summary>
    public static class Main
    {   
        /// <summary>
        /// Xin chào thế giới
        /// </summary>
        public static int test = 5;

        public static int b = 10;

        public static void HelloWorld()
        {
            Debug.Log(test);
            Debug.Log(b);
        }
    }

}