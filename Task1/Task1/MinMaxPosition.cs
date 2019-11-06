using System.Collections.Generic;

namespace Task1 {
    public class MinMaxPosition {
        public int Min { get; set; }
        public int Max { get; set; }

        public MinMaxPosition() {
            Min = -1;
            Max = -1;
        }

        public List<int> getAllPos() {
            var allPos = new List<int>();
            if (Min != -1) allPos.Add(Min);
            if (Max != -1) allPos.Add(Max);
            return allPos;
        }
    }
}