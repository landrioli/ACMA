using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ACMA.Infra.Log
{
    public class TestePerformanceLog : IDisposable
    {
        private Stopwatch _sw { get; set; }
        private string _filePath { get; set; }

        public TestePerformanceLog()
        {
            this._sw = new Stopwatch();
            File.AppendAllText(@"C:\teste\medicao.txt", "Nova medição de performance" + Environment.NewLine);
        }

        public void StartCounter()
        {
            _sw.Start();
        }

        public void StopCounter()
        {
            this._sw.Stop();
            Console.WriteLine("Elapsed={0}", _sw.Elapsed);
            WriteResultOnFile();
        }

        public void WriteResultOnFile()
        {
            File.AppendAllText(@_filePath, _sw.Elapsed.ToString() + Environment.NewLine);
        }

        public void Dispose()
        {
        }
    }
}
