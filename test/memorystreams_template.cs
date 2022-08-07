using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharpPracticeSyntax
{
    public class MemoryStreamsTests
    {
        // write string data to a memory stream and then read it back
        [Fact]
        public void MemoryStreamText()
        { 
            MemoryStream ms = new MemoryStream();
            string line_written = "abcd";
            string line_read;
            using (var sw = new System.IO.StreamWriter(ms, Encoding.UTF8))
            {
                sw.Write(line_written);
                sw.Flush();
                ms.Position = 0;
                var sr = new System.IO.StreamReader(ms, Encoding.UTF8);
                line_read = sr.ReadToEnd();
            }

            Assert.Equal (line_written, line_read); 
        }

        // write binary data to a memory stream and then read it back
        [Fact]
        public void MemoryStreamBinary()
        {
            MemoryStream ms = new MemoryStream();
            Int32 valueWritten = 1234;
            Int32 valueRead = 0;
            using (var bw = new System.IO.BinaryWriter(ms))
            {
                bw.Write(valueWritten);
                bw.Flush();
                ms.Position = 0;
                var br = new System.IO.BinaryReader(ms, Encoding.UTF8);
                valueRead = br.ReadInt32();
                Assert.Equal(valueWritten, valueRead);
            }
        } /**/
    }
}