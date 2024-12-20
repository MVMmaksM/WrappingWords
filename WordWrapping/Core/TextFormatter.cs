﻿using System.Text;

namespace WordWrapping.Core
{
    /// <summary>
    /// ядро логики программы
    /// </summary>
    public class TextFormatter
    {       
        private const string _VOWELS = "аеюяиёуыоэУЕЫАОЭЯИЮЁ";
        private const string _CONSONANTS = "цкнгшщзхфвпрлджчсмтбЦКНГШЩЗХФВПРЛДЖЧСМТБ";
        private const string _CAPITAL_CHARS = "УЕЫАОЭЯИЮЁЦКНГШЩЗХФВПРЛДЖЧСМТБ";
        public static List<string> FormatText(string text, int widthRow) 
        {
            //сплитим текст на слова по пробелам
            //и выбираем только слова без пробелов
            var words = text
                .Split(' ')
                .Where(w => w != "")
                .ToList();
            var strResult = new StringBuilder();
            var textRows = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                if (words[i].Contains("\r\n"))
                {
                    var wordSplitting = words[i].Split("\r\n");
                    strResult.Append(wordSplitting[0]);

                    //добавляем текущую строку в результирующий лист
                    textRows.Add(strResult.ToString());

                    //чистим строку
                    strResult.Clear();
                    //добавляем слово в начало новой строки
                    strResult.Append(wordSplitting[1] + " ");
                    continue;
                }

                //если длина формируемой строки становится больше
                //указанной длины строки, то делим слово
                if (strResult.Length + words[i].Length > widthRow)
                {
                    //разделенное слово
                    var divideWord = (DivideWord(words[i]));
                    //сплитим слова на слоги, чтобы найти подходящий по длине слог
                    var syllables = divideWord.Split('-');

                    //если слово не разделилось 
                    if (syllables.Length == 0)
                    {
                        //добавляем текущую строку в результирующий лист
                        textRows.Add(strResult.ToString());
                        //чистим строку
                        strResult.Clear();
                        //добавляем слово в начало новой строки
                        strResult.Append(words[i]);
                    }
                    else 
                    {
                        //если слово разделилось, то пытаемся подобрать
                        //слоги по оставшейся длине пустого места
                        var tmpStr = string.Empty;
                        //длина до конца строки
                        var lengthFreeRow = widthRow - strResult.Length;

                        for (int j = 0; j < syllables.Length; j++)
                        {
                            //если строка + слог становится длиннее оставшегося места, то 
                            if ((tmpStr.Length + (syllables[j] + "-").Length) > lengthFreeRow) 
                            {
                                if (!string.IsNullOrWhiteSpace(tmpStr)) 
                                {
                                    tmpStr += "-";
                                }

                                //добавляем часть строки в результат
                                strResult.Append(tmpStr);
                                //добавляем строку в результирующий лист
                                textRows.Add(strResult.ToString());
                                //чистим строку
                                strResult.Clear();

                                //оставщуюся часть слова переносим на новую строку 
                                var otherPartWord = string.Empty;
                                for (int k = j; k < syllables.Length; k++) 
                                {
                                    otherPartWord += syllables[k];
                                }
                                strResult.Append(otherPartWord + " ");
                                break;
                            }

                            //либо добавляем слог к строке
                            tmpStr += syllables[j];
                        }
                    }                          
                }
                else 
                {
                    //просто всталяем слово в строку
                    strResult.Append(words[i] + " ");   
                }               
            }
            
            textRows.Add(strResult.ToString());

            var result = FormatTextWidthRow(textRows, widthRow);
            return result;
        }

        /// <summary>
        /// выровнять текст по ширине, добавив пробелы между словами
        /// </summary>      
        private static List<string> FormatTextWidthRow(List<string> textRows, int widthRow) 
        {
            for (int i = 0; i < textRows.Count; i++) 
            {
                //количество пробелов, которые можно добавить
                var countSpace = widthRow - textRows[i].Trim().Length;
                //сплитим строку по пробелам, чтобы составить новую, добавив лишние пробелы 
                var words = textRows[i].Trim().Split(' ');
                
                //форматированная строка, в которую будут добавлены пробелы
                var resultStr = string.Empty;                

                //если пробелов больше 0
                if (countSpace > 0)
                {
                    for (int k = 0; k < words.Count(); k++)
                    {
                        //после последнего слова пробел не добавляем
                        if (k == words.Count() - 1)
                        {
                            resultStr += words[k];
                        }
                        else
                        {
                            //добавляем по 2 пробела, пока countSpace не станет равен 0
                            if (countSpace > 0)
                            {
                                resultStr += words[k] + "  ";
                                countSpace--;
                            }
                            else
                            {
                                //если countSpace = 0, то добавлем по одному пробелу
                                resultStr += words[k] + " ";
                            }
                        }
                    }

                    textRows[i] = resultStr;
                }
            }

            return textRows;    
        }

        /// <summary>
        /// делит слова на слоги
        /// </summary>       
        private static string DivideWord(string word) 
        {
            string result = string.Empty;

            //если слово содержит "-", то не делим его на слоги
            //возвращаем как есть
            if (word.Contains("-"))
                return word;            

            //если слово длинее 1 символа и иммет больше одной заглавной
            //то предполагаем, что это не ошибка, а аббревиатура
            //и не делим такое слово, а возвращаем как есть
            if(word.Length > 1 && word.Where(ch => _CAPITAL_CHARS.Contains(ch)).Count() > 1)
                return word;

            //1 алгоритм
            result = AlgDivideTwoConsonants(word);
            //2 алгоритм
            result = AlgDivideTwoVowelsAfterConsonant(result);
            //3 алгоритм
            result = AlgDivideTwoConsonantsAfterVowel(result);
            //4 алгоритм
            result = AlgOther(result);

            return result;
        }

        /// <summary>
        /// последний алгоритм, после 3
        /// </summary>  
        private static string AlgOther(string word) 
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i + 2 > word.Length - 1)
                    break;

                if (_VOWELS.Contains(word[i]) && word.Substring(0, i + 1).Length > 1 &&
                    isVowelsStr(word.Substring(i)))
                {
                    //если идет гласная, а за ней й, то й оставляем с гласной
                    string tempDivideWord = _VOWELS.Contains(word[i]) && word[i + 1] == 'й'
                        ? word.Substring(0, i + 2) + "-" + word.Substring(i + 2)
                        : word.Substring(0, i + 1) + "-" + word.Substring(i + 1);
                    //если разделено правильно, то пишем в word
                    if (isValidDivideWord(tempDivideWord))
                        word = tempDivideWord;
                }
            }

            return word;
        }

        /// <summary>
        /// алгоритм деления 2 идущих подряд согласных после гласной, ГСС
        /// </summary>      
        private static string AlgDivideTwoConsonantsAfterVowel(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i + 2 > word.Length - 1)
                    break;
              
                //ищем в слове совпадение ГСС и подстрока ГСС не является окончанием слова
                //и подстрока после ГСС содержит хотя бы одну гласную
                if (_VOWELS.Contains(word[i]) && _CONSONANTS.Contains(word[i + 1]) && _CONSONANTS.Contains(word[i + 2]) &&
                    isVowelsStr(word.Substring(i + 3)))
                {
                    string tempDivideWord = word.Substring(0, i + 2) + "-" + word.Substring(i + 2);
                    //если разделено правильно, то пишем в word
                    if (isValidDivideWord(tempDivideWord))
                        word = tempDivideWord;
                }
            }

            return word;
        }

        /// <summary>
        /// алгоритм деления 2 идущих подряд гласных после согласной, СГГ
        /// </summary>      
        private static string AlgDivideTwoVowelsAfterConsonant(string word) 
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (i + 2 > word.Length - 1)
                    break;
               
                //ищем в слове совпадение СГГ и подстрока СГГ не является окончанием слова
                if (_CONSONANTS.Contains(word[i]) && _VOWELS.Contains(word[i + 1]) && _VOWELS.Contains(word[i + 2]) &&
                    (i + 3) < word.Length - 1)
                {
                    var tempDivideWord = word.Substring(0, i + 2) + "-" + word.Substring(i + 2);
                    //если разделено правильно, то пишем в word
                    if (isValidDivideWord(tempDivideWord))
                        word = tempDivideWord;
                }
            }

            return word;
        }

        /// <summary>
        /// алгоритм деления 2 идущих подряд согласных, СС
        /// </summary>    
        private static string AlgDivideTwoConsonants(string word) 
        {          
            for (int i = 0; i < word.Length; i++)
            {
                if (i + 2 > word.Length - 1)
                    break;

                if (word[i] == word[i + 1] && _CONSONANTS.Contains(word[i]))
                {
                    word = word.Substring(0, i + 1) + "-" + word.Substring(i + 1);
                }
            }   
            
            return word;
        }

        /// <summary>
        /// проверяет правильно ли разделено слово на подслова
        /// </summary>
        private static bool isValidDivideWord(string word)
        {
            var subWords = word.Split('-');
            //выбираем из подслов, только те, где нет ни одной гласной или нет ни одной согласной
            //если такие подслова есть, то возвращаем false, в противном true 
            return !(subWords.Where(w => !isVowelsStr(w) || !isConsonantsStr(w))
                .Count() > 0);
        }

        /// <summary>
        /// модержит ли строка хотя бы одну согласную
        /// </summary>
        private static bool isConsonantsStr(string str) =>
            str.Where(ch => _CONSONANTS.Contains(ch)).Count() > 0;

        /// <summary>
        /// содержит ли строка хотя бы одну гласную
        /// </summary>
        private static bool isVowelsStr(string str) =>
            str.Where(ch => _VOWELS.Contains(ch)).Count() > 0;
    }
}
