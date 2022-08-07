// there is enough to justify an entire file stream not just streams
// reading and writing lines of random numbers from text files
// we specifically do not say what class for file I/O to use so you can decide
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpPracticeSyntax
{
    public class FileStreamsTests
    {
        private readonly string TESTFILE_TEXT;
        private readonly string TESTFILE_BINARY;
        public FileStreamsTests()
        {
            TESTFILE_TEXT = Path.GetTempPath() + "TEST.txt";
            TESTFILE_BINARY = Path.GetTempPath() + "TEST.dat";
        }

        // write string data to a file and then read it back
        [Fact]
        public void FileStreamTextMultiline()
        { /**/
            // Create a string array that consists of three lines.
            string[] linesWritten = { "First line", "Second line", "Third line" };

            // WriteAllLines creates a file, writes a collection of strings to the file,
            // and then closes the file.  You do NOT need to call Flush() or Close().
            File.WriteAllLines(TESTFILE_TEXT, linesWritten);

            // this is how you would do it one line at a time
            // NOTE: do not use FileStream for text files because it writes bytes, but StreamWriter
            // encodes the output as text.
            //using (System.IO.StreamWriter file = new System.IO.StreamWriter(TESTFILE))
            //{
            //    foreach (string line in linesWritten)
            //    {
            //        file.WriteLine(line);
            //    }
            //}

            // declare an input file stream
            // open the file for reading
            // read the contents line by line into a vector of strings

            // Read each line of the file into a string array. Each element of the array is one line of the file.
            string[] linesRead = File.ReadAllLines(TESTFILE_TEXT);

            // compare the 2 string arrays to make sure we read back what we wrote

            for (int x = 0; x < linesRead.Count(); x++)
            {
                // Use a tab to indent each line of the file.
                Assert.True(linesWritten[x] == linesRead[x]);
            }
        }

        // write binary data to a file and then read it back
        [Fact]
        public void FileStreamBinary()
        { /**/
            // write a binary structure to a file and then read it back
            Int32 valueWritten = 1234;
            Int32 valueRead = 0;
            // open the binary file c:\temp\test.dat for writing, deleting it if it exists.
            using (System.IO.BinaryWriter writer = new System.IO.BinaryWriter(File.Open(TESTFILE_BINARY, FileMode.Create)))
            {
                writer.Write(valueWritten);
            }

            // declare an input binary file stream

            // read in the integer bytes from the file
            if (File.Exists(TESTFILE_BINARY))
            {
                using (BinaryReader reader = new BinaryReader(File.Open(TESTFILE_BINARY, FileMode.Open)))
                {
                    valueRead = reader.ReadInt32();
                }
            }
            // compare the read contents to the written contents
            Assert.Equal(valueWritten, valueRead); /**/
        } /**/
    }
}