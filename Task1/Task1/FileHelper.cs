using System;
using System.IO;

namespace Task1 {
    public class FileHelper {
        private StreamReader _stream;

        public FileHelper(string filename) {
            _stream = new StreamReader(filename);
        }

        public string[] GetNextWordsInLine() {
            string line = GetNextLine();
            return GetWords(ref line);
        }

        public bool IsEnd() {
            return _stream.EndOfStream;
        }

        private string GetNextLine() {
            try {
                return _stream.ReadLine();
            } catch {
                throw new Exception("Ошибка при чтении строки");
            }
        }

        private string[] GetWords(ref string line) {
            return line.ToLower().Split(" ,.?!\'()\"".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        }
    }
}