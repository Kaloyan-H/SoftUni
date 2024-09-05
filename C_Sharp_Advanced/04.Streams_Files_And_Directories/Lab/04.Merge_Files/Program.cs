using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            StreamReader reader1 = new StreamReader(firstInputFilePath);
            string[] firstFile = reader1.ReadToEnd()
                .Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            reader1.Close();

            StreamReader reader2 = new StreamReader(secondInputFilePath);
            string[] secondFile = reader2.ReadToEnd()
                .Split(new string[] { " ", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries);
            reader2.Close();

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                int counter = 0;

                for (int i = 0; i < firstFile.Length + secondFile.Length; i++)
                {
                    if (counter < firstFile.Length || counter < secondFile.Length)
                    {
                        if (counter < firstFile.Length)
                        {
                            writer.WriteLine(firstFile[counter]);
                        }

                        if (counter < firstFile.Length)
                        {
                            writer.WriteLine(secondFile[counter]);
                        }
                    }

                    counter++;
                }
            }
        }
    }
}
