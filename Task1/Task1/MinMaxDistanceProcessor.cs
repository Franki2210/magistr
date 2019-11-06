using System;
using System.Collections.Generic;

namespace Task1 {
    
    public class MinMaxDistanceProcessor {

        public MinMaxDistance Get(string filename, string firstWord, string secondWord) {
            int pos = 0;
            MinMaxPosition firstWordPos = new MinMaxPosition();
            MinMaxPosition secondWordPos = new MinMaxPosition();
            
            MinMaxDistance minMaxDistance = new MinMaxDistance();
            
            FileHelper fileHelper = new FileHelper(filename);

            firstWord = firstWord.ToLower();
            secondWord = secondWord.ToLower();

            while (!fileHelper.IsEnd()) {
                string[] words = fileHelper.GetNextWordsInLine();

                foreach (var word in words) {
                    pos++;

                    if (word == firstWord) {
                        ProcessMinMaxDistance(ref minMaxDistance, firstWordPos, secondWordPos, pos);
                    } else if (word == secondWord) {
                        ProcessMinMaxDistance(ref minMaxDistance, secondWordPos, firstWordPos, pos);
                    }
                }
            }

            return minMaxDistance;
        }

        //Метод работает с minMaxDistance, занося туда информацию о минимальном и максимальном расстоянии
        //Запоминаем позицию первого вхождение слова, и текущую позицию
        //При нахождении одного из заданных слов:
        //    сравниваем позицию первого вхождения текущего слова и текущую позицию текущего слова
        //    с позицией первого вхождения другого слова и последней позицией другого слова
        private void ProcessMinMaxDistance(ref MinMaxDistance minMaxDistance, 
                                        MinMaxPosition wordPos, MinMaxPosition otherWordPos, 
                                        int pos) {
            if (wordPos.Min == -1) wordPos.Min = pos;
            wordPos.Max = pos;
            var currentDistances = GetMinMaxDistance(wordPos, otherWordPos);
            if (currentDistances == null) return;
            
            if (minMaxDistance.Min == -1) {
                minMaxDistance.Min = currentDistances.Min;
            } else if (currentDistances.Min < minMaxDistance.Min) {
                minMaxDistance.Min = currentDistances.Min;
            }

            if (minMaxDistance.Max == -1) {
                minMaxDistance.Max = currentDistances.Max;
            } else if (currentDistances.Max > minMaxDistance.Max) {
                minMaxDistance.Max = currentDistances.Max;
            }
        }

        private MinMaxDistance GetMinMaxDistance(MinMaxPosition firstWordPos, MinMaxPosition secondWordPos) {
            MinMaxDistance minMaxDistance = new MinMaxDistance();

            List<int> firstWordPosList = firstWordPos.getAllPos();
            List<int> secondWordPosList = secondWordPos.getAllPos();

            if (firstWordPosList.Count == 0 || secondWordPosList.Count == 0)
                return null;

            minMaxDistance.Min = GetMinDistance(firstWordPosList, secondWordPosList);
            minMaxDistance.Max = GetMaxDistance(firstWordPosList, secondWordPosList);

            return minMaxDistance;
        }

        //Нахождение минимального расстояния из списков позиций двух слов
        private int GetMinDistance(List<int> firstWordPositions, List<int> secondWordPositions) {
            int minDistance = -1;

            foreach (var firstWordPos in firstWordPositions) {
                foreach (var secondWordPos in secondWordPositions) {
                    var distance = GetDistance(firstWordPos, secondWordPos);
                    if (minDistance == -1) {
                        minDistance = distance;
                    } else if (distance < minDistance) {
                        minDistance = distance;
                    }
                }
            }
            
            return minDistance;
        }
        
        //Нахождение максимального расстояния из списков позиций двух слов
        private int GetMaxDistance(List<int> firstWordPositions, List<int> secondWordPositions) {
            int maxDistance = -1;

            foreach (var firstWordPos in firstWordPositions) {
                foreach (var secondWordPos in secondWordPositions) {
                    var distance = GetDistance(firstWordPos, secondWordPos);
                    if (maxDistance == -1) {
                        maxDistance = distance;
                    } else if (distance > maxDistance) {
                        maxDistance = distance;
                    }
                }
            }
            
            return maxDistance;
        }

        private int GetDistance(int pos1, int pos2) {
            return Math.Abs(pos1 - pos2) - 1;
        }
    }
    
}